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

        private bool _invalidPassword;
        public bool InvalidPassword
        {
            get => _invalidPassword;
            set => SetProperty(ref _invalidPassword, value);
        }

        public Command SignInCommand { get; private set; }

        public LoginViewModel(AuthenticationService auth)
        {
            _auth = auth;
            SignInCommand = new Command(async () => await SignIn());
        }

        private async Task SignIn()
        {
            // Password is null if password field is blank
            if (Password != null && await _auth.VerifyAppPassword(Password))
            {
                CurrentApplication.MainPage = new MainPage();
            }
            else
            {
                InvalidPassword = true;
            }
        }
    }
}
