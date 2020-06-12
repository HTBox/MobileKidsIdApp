using MobileKidsIdApp.ViewModels;
using Xamarin.Forms;
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

            Page childListPage = CurrentApp.CreatePage<ChildProfileListPage, ChildProfileListViewModel>(true).Result;
            Page instructionsPage = CurrentApp.CreatePage<InstructionIndexPage, InstructionIndexViewModel>(true).Result;

            if (childListPage is NavigationPage childNavPage)
            {
                childNavPage.Title = "My Kids";
                //childNavPage.IconImageSource = new FontImageSource()
                //{

                //};
                // TODO: set icon
            }

            if (instructionsPage is NavigationPage instructionNavPage)
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

