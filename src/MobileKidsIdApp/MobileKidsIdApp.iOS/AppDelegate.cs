using Foundation;
using MobileKidsIdApp.iOS.Platform;
using MobileKidsIdApp.Platform;
using Security;
using UIKit;
using Unity;
using Xamarin.Essentials;

namespace MobileKidsIdApp.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            SecureStorage.DefaultAccessible = SecAccessible.WhenUnlockedThisDeviceOnly;

            global::Xamarin.Forms.Forms.Init();

            var formsApp = new App();
            formsApp.Init(PlatformInitializeContainer);

            LoadApplication(formsApp);
            return base.FinishedLaunching(app, options);
        }

        private void PlatformInitializeContainer(UnityContainer container)
        {
            container.RegisterType<IContactPicker, ContactPicker>();
            container.RegisterType<IWebViewContentHelper, WebViewContentHelper>();
            container.RegisterType<IPhotoPicker, PhotoPicker>();
        }
    }
}
