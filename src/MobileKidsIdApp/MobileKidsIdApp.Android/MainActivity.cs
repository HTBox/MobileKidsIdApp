using System;

using Android.App;
using Android.Content.PM;
using Android.OS;
using System.Threading.Tasks;
using MobileKidsIdApp.Models;
using MobileKidsIdApp.Services;
using MobileKidsIdApp.Droid.Services;
using Android.Content;

namespace MobileKidsIdApp.Droid
{
    [Activity(Label = "MobileKidsIdApp", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            Instance = this;

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            if (ContactPicker.IsShowContactPickerIntent(requestCode))
            {
                if (ShowContactPicker != null)
                {
                    var args = new ActivityResultEventArgs
                    {
                        data = data,
                        requestCode = requestCode,
                        resultCode = resultCode
                    };
                    ShowContactPicker(null, args);
                }
            }
        }

        internal static MainActivity Instance { get; private set; }

        public event EventHandler<ActivityResultEventArgs> ShowContactPicker;
    }
}

