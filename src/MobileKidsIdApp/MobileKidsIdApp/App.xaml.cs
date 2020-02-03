using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace MobileKidsIdApp
{
    public partial class App : Application
    {
        public static Page RootPage { private set; get; }
        public static ViewModels.ChildProfileList CurrentFamily { get; set; }

        public App()
        {
            InitializeComponent();

            Csla.ApplicationContext.ContextManager = new Models.ApplicationContextManager();

            if (Csla.ApplicationContext.User == null)
                Csla.ApplicationContext.User = new Csla.Security.UnauthenticatedPrincipal();

            SetRootPage();
        }

        private void SetRootPage()
        {
            if (RootPage is Views.Login page && page.BindingContext is ViewModels.Login vm)
            {
                vm.SetRootPage = null;
            }

            if (!Csla.ApplicationContext.User.Identity.IsAuthenticated)
            {
                ViewModels.Login loginViewModel = new ViewModels.Login
                {
                    SetRootPage = () => SetRootPage()
                };
                RootPage = new Views.Login { BindingContext = loginViewModel };
            }
            else
            {
                RootPage = new AppShell { BindingContext = new ViewModels.Landing() };
            }

            MainPage = RootPage;
        }

        public void Logout()
        {
            ViewModels.Login loginViewModel = new ViewModels.Login
            {
                SetRootPage = () => SetRootPage()
            };
            MainPage = RootPage = new Views.Login { BindingContext = loginViewModel };
        }
    }
}
