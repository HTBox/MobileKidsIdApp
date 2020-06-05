using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MobileKidsIdApp
{
    public abstract class ViewModelBase : NotifyPropertyChanged
    {
        public virtual void OnAppearing() { }
        public virtual void OnDisappearing() { }

        public virtual async Task Initialize(Dictionary<string, object> navigationsParams = null) => await Task.CompletedTask;
        public virtual async Task PoppingTo(Dictionary<string, object> navigationsParams = null) => await Task.CompletedTask;

        private WeakReference<ContentPageBase> _page;
        public ContentPageBase Page => _page.TryGetTarget(out ContentPageBase target) ? target : null;
        public void SetWeakPage(ContentPageBase page) => _page = new WeakReference<ContentPageBase>(page);

        protected ApplicationBase CurrentApplication => Application.Current as ApplicationBase;
        protected INavigation Navigation => Page?.Navigation ?? Application.Current.MainPage.Navigation;

        protected Messaging Messaging => Messaging.Instance;

        public Task DisplayAlert(string title, string message, string cancel)
            => Page?.DisplayAlert(title, message, cancel);

        public Task<bool> DisplayAlert(string title, string message, string accept, string cancel)
            => Page?.DisplayAlert(title, message, accept, cancel);

        public Task<string> DisplayActionSheet(string title, string cancel, string destruction, params string[] buttons)
            => Page?.DisplayActionSheet(title, cancel, destruction, buttons);

        public IReadOnlyList<Page> ModalStack => Navigation.ModalStack;
        public IReadOnlyList<Page> NavigationStack => Navigation.NavigationStack;

        public Task<Page> PopAsync(Dictionary<string, object> navigationParams = null, bool animated = true) => PopAsyncInternal(navigationParams, animated);
        public Task<Page> PopModalAsync(bool animated = true) => Navigation.PopModalAsync(animated);
        public Task<Page> PopModalAsync(Dictionary<string, object> navigationParams, bool animated = true) => PopModalAsyncInternal(navigationParams, animated);
        public Task PopToRootAsync(bool animated = true) => Navigation.PopToRootAsync(animated);
        public void RemovePage(Page page = null) => Navigation.RemovePage(page ?? Page);

        public async Task InsertPageBefore<TPage, TViewModel>(Dictionary<string, object> navigationParams = null)
            where TPage : ContentPageBase
            where TViewModel : ViewModelBase
        {
            Page page = await CurrentApplication.CreatePage<TPage, TViewModel>(navigationParams);

            Navigation.InsertPageBefore(page, Page);
        }

        public Task ReplaceMainPageAsync<TPage, TViewModel>(Dictionary<string, object> navigationParams)
            where TPage : ContentPageBase
            where TViewModel : ViewModelBase
            => ReplaceMainPageAsync<TPage, TViewModel>(true, navigationParams);

        public async Task ReplaceMainPageAsync<TPage, TViewModel>(bool wrapInNavigationPage = true, Dictionary<string, object> navigationParams = null)
            where TPage : ContentPageBase
            where TViewModel : ViewModelBase
        {
            Page page = await CurrentApplication.CreatePage<TPage, TViewModel>(navigationParams);

            CurrentApplication.MainPage = wrapInNavigationPage ? new NavigationPage(page) : page;
        }

        public async Task PopToPageAsync<TPage>(Dictionary<string, object> navigationParams = null, bool animated = true)
            where TPage : ContentPageBase
        {
            var navList = NavigationStack.ToList();
            Page headersPage = navList.FirstOrDefault(p => p.GetType() == typeof(TPage));
            int idx = navList.IndexOf(headersPage);
            if (idx != -1)
            {
                for (int i = idx + 1; i < navList.Count - 1; i++)
                {
                    RemovePage(navList[i]);
                }
                await PopAsync(navigationParams, animated);
            }
        }
        public Task PushAsync<TPage, TViewModel>(bool animated = true)
            where TPage : ContentPageBase
            where TViewModel : ViewModelBase
            => PushAsyncInternal<TPage, TViewModel>(null, animated);

        public Task PushAsync<TPage, TViewModel>(Dictionary<string, object> navigationParams, bool animated = true)
            where TPage : ContentPageBase
            where TViewModel : ViewModelBase
            => PushAsyncInternal<TPage, TViewModel>(navigationParams, animated);

        public Task PushModalAsync<TPage, TViewModel>(bool wrapInNavigationPage = true, bool animated = true)
            where TPage : ContentPageBase
            where TViewModel : ViewModelBase
            => PushModalAsyncInternal<TPage, TViewModel>(null, wrapInNavigationPage, animated);

        public Task PushModalAsync<TPage, TViewModel>(Dictionary<string, object> navigationParams, bool wrapInNavigationPage = true, bool animated = true)
            where TPage : ContentPageBase
            where TViewModel : ViewModelBase
            => PushModalAsyncInternal<TPage, TViewModel>(navigationParams, wrapInNavigationPage, animated);

        private async Task PushAsyncInternal<TPage, TViewModel>(Dictionary<string, object> navigationParams, bool animated)
            where TPage : ContentPageBase
            where TViewModel : ViewModelBase
        {
            Page page = await CurrentApplication.CreatePage<TPage, TViewModel>(navigationParams);
            await Navigation.PushAsync(page, animated);
        }

        private async Task PushModalAsyncInternal<TPage, TViewModel>(Dictionary<string, object> navigationParams, bool wrapInNavigationPage, bool animated)
            where TPage : ContentPageBase
            where TViewModel : ViewModelBase
        {
            Page page = await CurrentApplication.CreatePage<TPage, TViewModel>(wrapInNavigationPage, navigationParams);
            await Navigation.PushModalAsync(page, animated);
        }

        private async Task<Page> PopAsyncInternal(Dictionary<string, object> navigationParams = null, bool animated = true)
        {
            if (NavigationStack.Count > 1)
            {
                var vm = NavigationStack[NavigationStack.Count - 2].BindingContext as ViewModelBase;
                vm?.PoppingTo(navigationParams);
            }

            Page popped = await Navigation.PopAsync(animated);

            return popped;
        }

        private async Task<Page> PopModalAsyncInternal(Dictionary<string, object> navigationParams, bool animated = true)
        {
            if (ModalStack.Count == 1 || navigationParams == null || navigationParams.Count == 0)
            {
                return await Navigation.PopModalAsync(animated);
            }
            else
            {
                Page page = ModalStack[ModalStack.Count - 2];
                ViewModelBase vm;

                if (page is NavigationPage navPage)
                {
                    vm = navPage.CurrentPage.BindingContext as ViewModelBase;
                }
                else
                {
                    vm = page.BindingContext as ViewModelBase;
                }

                vm?.PoppingTo(navigationParams);

                Page popped = await PopModalAsync(animated);

                return popped;
            }
        }
    }
}
