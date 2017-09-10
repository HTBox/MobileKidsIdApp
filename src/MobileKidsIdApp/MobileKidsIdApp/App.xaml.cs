using MobileKidsIdApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace MobileKidsIdApp
{
    public partial class App : Application
    {
        public static NavigationPage RootPage { private set; get; }
        public static ViewModels.ChildProfileList CurrentFamily { get; set; }

        public App()
        {
            InitializeComponent();

            RootPage = new NavigationPage(new Views.Landing { BindingContext = new ViewModels.Landing() });
            MainPage = RootPage;
        }

        protected override async void OnStart()
        {
            await CheckUserLogin();
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override async void OnResume()
        {
            await CheckUserLogin();
        }

        private static async Task CheckUserLogin()
        {
            if (Csla.ApplicationContext.User == null)
                Csla.ApplicationContext.User = new Csla.Security.UnauthenticatedPrincipal();

            if (!Csla.ApplicationContext.User.Identity.IsAuthenticated)
            {
				await RootPage.Navigation.PushModalAsync(new NavigationPage(new Views.Login { BindingContext = new ViewModels.Login() }));
            }
        }

        internal static async Task Logout()
        {
            Csla.ApplicationContext.User = new Csla.Security.UnauthenticatedPrincipal();
            await CheckUserLogin();
        }

        public static IAuthenticate Authenticator { get; private set; }

        public static void Init(IAuthenticate authenticator)
        {
            Authenticator = authenticator;
        }
    }
}
