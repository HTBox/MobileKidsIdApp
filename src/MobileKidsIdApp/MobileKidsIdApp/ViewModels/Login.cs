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
        public ICommand SigninCommand { get; private set; }
        public string Password { get; set; }

        public Login()
        {
            SigninCommand = new Command(async () => { await DoAuthentication(); });
        }

        private async Task DoAuthentication()
        {
            var identity = await Models.AppIdentity.LoginAsync(Password);
            Csla.ApplicationContext.User = new Models.AppPrincipal(identity);
            if (Csla.ApplicationContext.User.Identity.IsAuthenticated)
                await App.RootPage.Navigation.PopModalAsync();
        }
    }
}
