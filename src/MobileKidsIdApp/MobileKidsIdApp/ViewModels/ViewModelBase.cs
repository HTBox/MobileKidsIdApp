using System;
using System.Threading.Tasks;

namespace MobileKidsIdApp.ViewModels
{
    public interface IViewModel
    {
        void SetActiveView();
        Task CloseView(bool withoutSave);
        Task CloseView();
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

        public void SetActiveView()
        {
            _forwardNavigation = false;
        }

        public async Task CloseView(bool withoutSave)
        {
            if (_forwardNavigation) return;
            if (withoutSave)
                Model = default(T);
            else
                await CloseView();
        }

        public async Task CloseView()
        {
            if (_forwardNavigation) return;
            // save data
            await App.CurrentFamily.SaveFamilyAsync();
            // release event handlers from model
            Model = default(T);
        }
    }
}
