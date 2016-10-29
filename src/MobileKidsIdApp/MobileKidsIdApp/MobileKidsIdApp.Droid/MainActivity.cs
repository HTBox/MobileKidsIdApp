using System;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Content;

namespace MobileKidsIdApp.Droid
{
    [Activity(Label = "MobileKidsIdApp", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
    {

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            Instance = this;

            MobileKidsIdApp.App.Init(this);

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

        public async Task<Models.AppIdentity> Authenticate(MobileKidsIdApp.Services.LoginProviders provider)
        {
            Models.AppIdentity result = null;
            try
            {
#if DEBUG
                if (provider == MobileKidsIdApp.Services.LoginProviders.Test)
                {
                    result = await Models.AppIdentity.CreateIdentity("test:1", "blahblahblah");
                    return result;
                }
#endif
                var client = new MobileServiceClient("https://mobilekidsidapp.azurewebsites.net");
                MobileServiceUser authnResult = null;
                switch (provider)
                {
                    case MobileKidsIdApp.Services.LoginProviders.Google:
                        authnResult = await client.LoginAsync(this, MobileServiceAuthenticationProvider.Google);
                        break;
                    case MobileKidsIdApp.Services.LoginProviders.Microsoft:
                        authnResult = await client.LoginAsync(this, MobileServiceAuthenticationProvider.MicrosoftAccount);
                        break;
                    case MobileKidsIdApp.Services.LoginProviders.Facebook:
                        authnResult = await client.LoginAsync(this, MobileServiceAuthenticationProvider.Facebook);
                        break;
                    default:
                        throw new ArgumentException("LoginProvider");
                }
                result = await Models.AppIdentity.CreateIdentity(authnResult.UserId, authnResult.MobileServiceAuthenticationToken);
            }
            catch
            {
                result = new Models.AppIdentity();
            }
            return result;
        }
    }
}

