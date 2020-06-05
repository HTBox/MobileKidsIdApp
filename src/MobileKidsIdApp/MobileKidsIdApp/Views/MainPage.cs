using MobileKidsIdApp.ViewModels;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;

namespace MobileKidsIdApp.Views
{
    public class MainPage : Xamarin.Forms.TabbedPage
    {
        private ApplicationBase CurrentApp => Xamarin.Forms.Application.Current as ApplicationBase;

        public MainPage()
        {
            On<Android>().SetToolbarPlacement(ToolbarPlacement.Bottom);

            Xamarin.Forms.Page childListPage = CurrentApp.CreatePage<ChildProfileListPage, ChildProfileListViewModel>(true).Result;
            Xamarin.Forms.Page instructionsPage = CurrentApp.CreatePage<InstructionIndexPage, InstructionIndexViewModel>(true).Result;

            if (childListPage is Xamarin.Forms.NavigationPage childNavPage)
            {
                childNavPage.Title = "My Kids";
                // TODO: set icon
            }

            if (instructionsPage is Xamarin.Forms.NavigationPage instructionNavPage)
            {
                instructionNavPage.Title = "Content";
                // TODO: set icon
            }


            Children.Add(childListPage);
            Children.Add(instructionsPage);
            // TODO: Add "logout" ability
        }
    }
}

