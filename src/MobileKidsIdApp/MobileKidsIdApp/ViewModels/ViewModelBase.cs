using System;
using System.Threading.Tasks;

namespace MobileKidsIdApp.ViewModels
{
    public interface IViewModel
    {
        void SetActiveView();
        Task CloseView(bool withoutSave);
        Task CloseView();
        void PrepareToShowModal();
    }

    public class ViewModelBase<T> : Csla.Xaml.ViewModelBase<T>, IViewModel
    {
        private bool _forwardNavigation;

        public async Task ShowPage(Type pageType, object viewModel)
        {
            _forwardNavigation = true;
            var page = (Xamarin.Forms.ContentPage)Activator.CreateInstance(pageType);
            page.BindingContext = viewModel;
            await App.RootPage.Navigation.PushAsync(page);
        }

        public virtual void SetActiveView()
        {
            _forwardNavigation = false;
        }

        public virtual async Task CloseView(bool withoutSave)
        {
            if (_forwardNavigation) return;
            if (!withoutSave)
                await App.CurrentFamily.SaveFamilyAsync();
            Model = default(T);
        }

        public virtual async Task CloseView()
        {
            await CloseView(false);
        }

        /// <summary>
        /// When we want to display some view (a picker via the OS, for example) 
        /// but we don't want to (or can't) push it on to the navigation stack ourselves, and we also don't want to trigger a save 
        /// upon leaving the current view via CloseView() being called. 
        /// </summary>
        public void PrepareToShowModal()
        {
            _forwardNavigation = true;
        }
    }
}
