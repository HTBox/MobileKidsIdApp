using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MobileKidsIdApp.ViewModels
{
    public class Login : BindableObject
    {
        public ICommand SigninCommand { get; private set; }
        public string Password { get; set; }
        public string PasswordConfirm { get; set; }
        public bool FirstRun { get; set; }
        public bool InvalidPassword { get; set; }
        public bool PasswordsMustMatch { get; set; }

        public Action SetRootPage { get; set; }

        public Login()
        {
            SigninCommand = new Command(async () => { await DoAuthentication(); });
            if (!DesignMode.IsDesignModeEnabled)
            {
                SetFirstRun();
            }
        }

        private void SetFirstRun()
        {
            var cmd = Csla.DataPortal.Fetch<Models.FamilyExists>();
            FirstRun = !cmd.Exists;
            OnPropertyChanged("FirstRun");
        }

        private async Task DoAuthentication()
        {
            if (FirstRun)
            {
                if (Password != PasswordConfirm)
                {
                    PasswordsMustMatch = true;
                    OnPropertyChanged("PasswordsMustMatch");
                    return;
                }
                else
                {
                    PasswordsMustMatch = true;
                    OnPropertyChanged("PasswordsMustMatch");
                }
            }
            var identity = await Models.AppIdentity.LoginAsync(Password);
            Csla.ApplicationContext.User = new Models.AppPrincipal(identity);
            if (Csla.ApplicationContext.User.Identity.IsAuthenticated)
            {
                SetRootPage?.Invoke();
            }
            else
            {
                InvalidPassword = true;
                OnPropertyChanged("InvalidPassword");
            }
        }
    }
}
