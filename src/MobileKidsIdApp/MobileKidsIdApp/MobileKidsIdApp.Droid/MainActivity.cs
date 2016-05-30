using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Content;

namespace MobileKidsIdApp.Droid
{
    [Activity(Label = "MobileKidsIdApp", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
    {

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            Instance = this;

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());
        }
        

        public event EventHandler<ActivityResultEventArgs> ActivityResult;

        //There must be a better way to be able to use StartActivityForResult for
        //photo picking without needing this ugly static variable...
        public static MainActivity Instance;

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            if (ActivityResult != null)
            {
                ActivityResult(this, new ActivityResultEventArgs()
                {
                    requestCode = requestCode,
                    resultCode = resultCode,
                    data = data
                });
            }
        }
    }
}

