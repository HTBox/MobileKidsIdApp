using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace MobileKidsIdApp
{
    public abstract class ContentPageBase : ContentPage
    {
        public ContentPageBase()
        {
            Visual = VisualMarker.Material;
            On<iOS>().SetUseSafeArea(true);
        }

        protected ViewModelBase ViewModel => BindingContext as ViewModelBase;

        protected override void OnAppearing() => ViewModel?.OnAppearing();

        protected override void OnDisappearing() => ViewModel?.OnDisappearing();

        public virtual void Initialize() { }
    }
}
