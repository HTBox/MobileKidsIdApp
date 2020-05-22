using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity;
using Xamarin.Forms;

namespace MobileKidsIdApp
{
    public abstract class ApplicationBase : Application
    {
        private Lazy<UnityContainer> _container = new Lazy<UnityContainer>(() => new UnityContainer());
        public UnityContainer Container => _container.Value;

        public void Init(Action<UnityContainer> platformInitializeContainer = null)
        {
            platformInitializeContainer?.Invoke(Container);
            InitializeContainer();

            Page mainPage = null;
            Task.Run(async () => mainPage = await CreateMainPage()).Wait();

            MainPage = mainPage;
        }

        protected abstract void InitializeContainer();
        protected abstract Task<Page> CreateMainPage();

        public Task<Page> CreatePage<TPage, TViewModel>(Dictionary<string, object> navigationParams = null)
            where TPage : ContentPageBase
            where TViewModel : ViewModelBase
            => CreatePage<TPage, TViewModel>(false, navigationParams);

        public async Task<Page> CreatePage<TPage, TViewModel>(bool wrapInNavigationPage, Dictionary<string, object> navigationParams = null)
            where TPage : ContentPageBase
            where TViewModel : ViewModelBase
        {
            var vm = Container.Resolve<TViewModel>();
            var page = Container.Resolve<TPage>();

            vm.SetWeakPage(page);
            await vm.Initialize(navigationParams);

            page.BindingContext = vm;
            page.Initialize();

            if (wrapInNavigationPage)
            {
                return new NavigationPage(page)
                {
                    Title = nameof(TPage) // HACK: Bug in Forms where even a Nav page needs a title in the master pane
                };
            }

            return page;
        }

        public async Task<Page> CreateTab<TView, TViewModel>(
            Dictionary<string, object> navigationParams = null,
            bool wrapInNavigationPage = false,
            Style navigationStyle = null)
            where TView : ContentPageBase
            where TViewModel : ViewModelBase
        {
            var page = Container.Resolve<TView>();
            var vm = Container.Resolve<TViewModel>();
            await vm.Initialize(navigationParams);

            vm.SetWeakPage((ContentPageBase)page);
            page.BindingContext = vm;
            ((ContentPageBase)page).Initialize();

            if (wrapInNavigationPage)
            {
                if (navigationStyle == null)
                {
                    return new NavigationPage(page)
                    {
                        Title = page.Title,
                        IconImageSource = page.IconImageSource,
                    };
                }
                else
                {
                    return new NavigationPage(page)
                    {
                        Title = page.Title,
                        IconImageSource = page.IconImageSource,
                        Style = navigationStyle
                    };
                }

            }
            return page;
        }
    }
}
