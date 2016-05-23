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
            FacebookLoginCommand = new Command(async () =>
            {
                //TODO: implement FB login here
                var identity = await Models.AppIdentity.GetAppIdentityAsync("FB:1", "blahblahblah");
                Csla.ApplicationContext.User = new Models.AppPrincipal(identity);
                await App.RootPage.Navigation.PopModalAsync();
            });
            MicrosoftLoginCommand = new Command(async () =>
            {
                //TODO: implement Microsoft login here
                var identity = await Models.AppIdentity.GetAppIdentityAsync("Live:1", "blahblahblah");
                Csla.ApplicationContext.User = new Models.AppPrincipal(identity);
                await App.RootPage.Navigation.PopModalAsync();
            });
            GoogleLoginCommand = new Command(async () =>
            {
                //TODO: implement Google login here
                var identity = await Models.AppIdentity.GetAppIdentityAsync("Google:1", "blahblahblah");
                Csla.ApplicationContext.User = new Models.AppPrincipal(identity);
                await App.RootPage.Navigation.PopModalAsync();
            });
#if DEBUG
            Testing = true;
            TestLoginCommand = new Command(async () =>
            {
                var identity = await Models.AppIdentity.GetAppIdentityAsync("test:1", "blahblahblah");
                Csla.ApplicationContext.User = new Models.AppPrincipal(identity);
                await App.RootPage.Navigation.PopModalAsync();
            });
#endif
        }

        public bool Testing { get; set; }
    }
}
