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
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity, MobileKidsIdApp.Services.IAuthenticate
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            Instance = this;

            MobileKidsIdApp.App.Init(this);

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

        public async Task<AppIdentity> Authenticate(LoginProviders provider)
        {
            Models.AppIdentity result = null;
            try
            {
#if DEBUG
                if (provider == MobileKidsIdApp.Services.LoginProviders.Test)
                {
                    result = await Models.AppIdentity.GetAppIdentityAsync("test:1", "blahblahblah");
                    return result;
                }
#endif
                //TODO: update authentication implementation
                //var client = new MobileServiceClient("https://mobilekidsidapp.azurewebsites.net");
                //MobileServiceUser authnResult = null;
                //switch (provider)
                //{
                //    case MobileKidsIdApp.Services.LoginProviders.Google:
                //        authnResult = await client.LoginAsync(this, MobileServiceAuthenticationProvider.Google);
                //        break;
                //    case MobileKidsIdApp.Services.LoginProviders.Microsoft:
                //        authnResult = await client.LoginAsync(this, MobileServiceAuthenticationProvider.MicrosoftAccount);
                //        break;
                //    case MobileKidsIdApp.Services.LoginProviders.Facebook:
                //        authnResult = await client.LoginAsync(this, MobileServiceAuthenticationProvider.Facebook);
                //        break;
                //    default:
                //        throw new ArgumentException("LoginProvider");
                //}
                //result = await Models.AppIdentity.GetAppIdentityAsync(authnResult.UserId, authnResult.MobileServiceAuthenticationToken);
            }
            catch
            {
                result = new Models.AppIdentity();
            }
            return result;
        }
    }
}

