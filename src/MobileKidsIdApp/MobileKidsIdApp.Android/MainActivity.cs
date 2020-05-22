using System;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using MobileKidsIdApp.Droid.Platform;
using MobileKidsIdApp.Platform;
using Unity;

namespace MobileKidsIdApp.Droid
{
    [Activity(
        Label = "Kids Id Kit",
        Icon = "@mipmap/icon",
        Theme = "@style/MainTheme",
        MainLauncher = true,
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        public event EventHandler<ActivityResultEventArgs> ActivityResult;

        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);

            var formsApp = new App();
            formsApp.Init(PlatformInitializeContainer);
            LoadApplication(formsApp);
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);

            if (ActivityResult != null)
            {
                var args = new ActivityResultEventArgs
                {
                    data = data,
                    requestCode = requestCode,
                    resultCode = resultCode
                };

                ActivityResult(this, args);
            }
        }

        private void PlatformInitializeContainer(UnityContainer container)
        {
            container.RegisterType<IContactPicker, ContactPicker>();
            container.RegisterType<IWebViewContentHelper, WebViewContentHelper>();
            container.RegisterType<IPhotoPicker, PhotoPicker>();
        }
    }
}

