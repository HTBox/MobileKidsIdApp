using MobileKidsIdApp.ViewModels;
using Xamarin.Forms;

namespace MobileKidsIdApp.Views
{
    public class MainPage : TabbedPage
    {
        private ApplicationBase CurrentApp => Application.Current as ApplicationBase;

        public MainPage()
        {
            Page childListPage = CurrentApp.CreatePage<ChildProfileListPage, ChildProfileListViewModel>(true).Result;
            Page instructionsPage = CurrentApp.CreatePage<InstructionIndexPage, InstructionIndexViewModel>(true).Result;

            if (childListPage is NavigationPage childNavPage)
            {
                childNavPage.Title = "My Kids";
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

