using MobileKidsIdApp.Services;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MobileKidsIdApp.ViewModels
{
    public class Login : INotifyPropertyChanged
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
            //TestLoginCommand = new Command(async () =>
            //{
            //    var identity = await Models.AppIdentity.GetAppIdentityAsync("test:1", "blahblahblah");
            //    Csla.ApplicationContext.User = new Models.AppPrincipal(identity);
            //    if (Csla.ApplicationContext.User.Identity.IsAuthenticated)
            //        await App.RootPage.Navigation.PopModalAsync();
            //});
#endif
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
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
