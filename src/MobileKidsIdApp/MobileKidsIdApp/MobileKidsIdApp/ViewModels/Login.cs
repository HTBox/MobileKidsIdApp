using MobileKidsIdApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MobileKidsIdApp.ViewModels
{
    public class Login
    {
        public ICommand FacebookLoginCommand { get; private set; }
        public ICommand MicrosoftLoginCommand { get; private set; }
        public ICommand GoogleLoginCommand { get; private set; }
        public ICommand TestLoginCommand { get; private set; }

        public Login()
        {
            FacebookLoginCommand = new Command(async () => { await DoAuthentication(LoginProviders.Facebook); });
            MicrosoftLoginCommand = new Command(async () => { await DoAuthentication(LoginProviders.Microsoft); });
            GoogleLoginCommand = new Command(async () => { await DoAuthentication(LoginProviders.Google); });
#if DEBUG
            TestLoginCommand = new Command(async () => { await DoAuthentication(LoginProviders.Test); });
#endif
        }

        private async Task DoAuthentication(LoginProviders provider)
        {
            var identity = await App.Authenticator.Authenticate(provider);
            Csla.ApplicationContext.User = new Models.AppPrincipal(identity);
            if (Csla.ApplicationContext.User.Identity.IsAuthenticated)
                await App.RootPage.Navigation.PopModalAsync();
        }
    }
}
