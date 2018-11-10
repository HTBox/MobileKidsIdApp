using MobileKidsIdApp.Services;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace MobileKidsIdApp
{
	public partial class App : Application
	{
        public static NavigationPage RootPage { private set; get; }
        public static ViewModels.ChildProfileList CurrentFamily { get; set; }


        public App ()
		{
			InitializeComponent();

            Csla.ApplicationContext.ContextManager = new Models.ApplicationContextManager();

            if (Csla.ApplicationContext.User == null)
                Csla.ApplicationContext.User = new Csla.Security.UnauthenticatedPrincipal();

            if (!Csla.ApplicationContext.User.Identity.IsAuthenticated)
            {
                RootPage = new NavigationPage(new Views.Login { BindingContext = new ViewModels.Login() });
            }
            else
            {
                RootPage = new NavigationPage(new Views.Landing { BindingContext = new ViewModels.Landing() });
            }

            MainPage = RootPage;
        }


        internal static async Task Logout()
        {
            RootPage.Navigation.InsertPageBefore(new NavigationPage(new Views.Login { BindingContext = new ViewModels.Login() }),
                                                 RootPage.Navigation.NavigationStack.First());
            await RootPage.Navigation.PopAsync();
        }
    }
}
