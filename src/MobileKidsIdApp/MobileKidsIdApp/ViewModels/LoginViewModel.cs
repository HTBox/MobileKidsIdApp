using System.Threading.Tasks;
using MobileKidsIdApp.Services;
using MobileKidsIdApp.Views;
using Xamarin.Forms;

namespace MobileKidsIdApp.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private readonly AuthenticationService _auth;

        private string _password;
        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }

        private string _passwordConfirm;
        public string PasswordConfirm
        {
            get => _passwordConfirm;
            set => SetProperty(ref _passwordConfirm, value);
        }

        private bool _firstRun;
        public bool SetPassword
        {
            get => _firstRun;
            set => SetProperty(ref _firstRun, value);
        }

        private bool _invalidPassword;
        public bool InvalidPassword
        {
            get => _invalidPassword;
            set => SetProperty(ref _invalidPassword, value);
        }

        private bool _passwordMustMatch;
        public bool PasswordsMustMatch
        {
            get => _passwordMustMatch;
            set => SetProperty(ref _passwordMustMatch, value);
        }

        public Command SignInCommand { get; private set; }

        public LoginViewModel(AuthenticationService auth, SettingsRepository settings)
        {
            _auth = auth;

            SignInCommand = new Command(async () => await SignIn());

            SetPassword = settings.AllowPasswordSetup;
        }

        private async Task SignIn()
        {
            bool passwordValid = false;

            if (SetPassword && Password == PasswordConfirm)
            {
                await _auth.SetAppPassword(Password);
                passwordValid = true;
            }
            else if (SetPassword)
            {
                PasswordsMustMatch = true;
            }
            else // Confirm password
            {
                passwordValid = await _auth.VerifyAppPassword(Password);

                if (!passwordValid)
                {
                    InvalidPassword = true;
                }
            }

            if (passwordValid)
            {
                await ReplaceMainPageAsync<ChildProfileListPage, ChildProfileListViewModel>();
            }
        }
    }
}
