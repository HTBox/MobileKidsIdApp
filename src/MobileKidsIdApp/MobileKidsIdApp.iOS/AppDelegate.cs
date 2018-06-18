using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Foundation;
using MobileKidsIdApp.Models;
using MobileKidsIdApp.Services;
using UIKit;

namespace MobileKidsIdApp.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate, MobileKidsIdApp.Services.IAuthenticate
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
            global::Xamarin.Forms.Forms.Init();
            LoadApplication(new App());

            MobileKidsIdApp.App.Init(this);

            return base.FinishedLaunching(app, options);
        }

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
                //TODO: switch to latest authentication model
                //var client = new MobileServiceClient("https://mobilekidsidapp.azurewebsites.net");
                //MobileServiceUser authnResult = null;
                //switch (provider)
                //{
                //    case MobileKidsIdApp.Services.LoginProviders.Google:
                //        authnResult = await client.LoginAsync(UIApplication.SharedApplication.KeyWindow.RootViewController, MobileServiceAuthenticationProvider.Google);
                //        break;
                //    case MobileKidsIdApp.Services.LoginProviders.Microsoft:
                //        authnResult = await client.LoginAsync(UIApplication.SharedApplication.KeyWindow.RootViewController, MobileServiceAuthenticationProvider.MicrosoftAccount);
                //        break;
                //    case MobileKidsIdApp.Services.LoginProviders.Facebook:
                //        authnResult = await client.LoginAsync(UIApplication.SharedApplication.KeyWindow.RootViewController, MobileServiceAuthenticationProvider.Facebook);
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
