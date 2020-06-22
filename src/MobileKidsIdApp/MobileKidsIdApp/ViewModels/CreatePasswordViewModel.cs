using System.Threading.Tasks;
using MobileKidsIdApp.Services;
using MobileKidsIdApp.Views;
using Xamarin.Forms;

namespace MobileKidsIdApp.ViewModels
{
    public class CreatePasswordViewModel : ViewModelBase
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

        private bool _passwordMustMatch;
        public bool PasswordsMustMatch
        {
            get => _passwordMustMatch;
            set => SetProperty(ref _passwordMustMatch, value);
        }

        public Command SignInCommand { get; private set; }

        public CreatePasswordViewModel(AuthenticationService auth)
        {
            _auth = auth;
            SignInCommand = new Command(async () => await SignIn());
        }

        private async Task SignIn()
        {
            if (Password == PasswordConfirm)
            {
                await _auth.SetAppPassword(Password);
                CurrentApplication.MainPage = new MainPage();
            }
            else
            {
                PasswordsMustMatch = true;
            }
        }
    }
}
