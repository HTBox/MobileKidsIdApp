using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace MobileKidsIdApp.UWP
{
    public sealed partial class MainPage : MobileKidsIdApp.Services.IAuthenticate
    {
        public MainPage()
        {
            this.InitializeComponent();

            MobileKidsIdApp.App.Init(this);

            LoadApplication(new MobileKidsIdApp.App());
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
                        authnResult = await client.LoginAsync(MobileServiceAuthenticationProvider.Google);
                        break;
                    case MobileKidsIdApp.Services.LoginProviders.Microsoft:
                        authnResult = await client.LoginAsync(MobileServiceAuthenticationProvider.MicrosoftAccount);
                        break;
                    case MobileKidsIdApp.Services.LoginProviders.Facebook:
                        authnResult = await client.LoginAsync(MobileServiceAuthenticationProvider.Facebook);
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
