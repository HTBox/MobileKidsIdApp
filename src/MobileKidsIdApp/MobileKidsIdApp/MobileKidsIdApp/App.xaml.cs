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

        public App()
        {
            InitializeComponent();

            RootPage = new NavigationPage(new Views.Landing { BindingContext = new ViewModels.Landing() });
            MainPage = RootPage;

            CheckUserLogin();
        }

        protected override void OnStart()
        {
            CheckUserLogin();
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            CheckUserLogin();
        }

        private static async void CheckUserLogin()
        {
            if (Csla.ApplicationContext.User == null)
                Csla.ApplicationContext.User = new Csla.Security.UnauthenticatedPrincipal();

            if (!Csla.ApplicationContext.User.Identity.IsAuthenticated)
            {
                await RootPage.Navigation.PushModalAsync(new Views.Login { BindingContext = new ViewModels.Login() });
            }
        }

        internal static void Logout()
        {
            Csla.ApplicationContext.User = new Csla.Security.UnauthenticatedPrincipal();
            CheckUserLogin();
        }
    }
}
