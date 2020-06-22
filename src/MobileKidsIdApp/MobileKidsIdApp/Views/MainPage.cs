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

            BarBackgroundColor = Color.White;
            SelectedTabColor = AppColors.MCMDarkTeal;
            UnselectedTabColor = AppColors.MCMBlack4;

            Page childListPage = CurrentApp.CreatePage<ChildProfileListPage, ChildProfileListViewModel>(true).Result;
            Page instructionsPage = CurrentApp.CreatePage<InstructionIndexPage, InstructionIndexViewModel>(true).Result;

            if (childListPage is NavigationPage childNavPage)
            {
                childNavPage.Title = "My Kids";
                childNavPage.IconImageSource = new FontImageSource()
                {
                    FontFamily = "FASolid",
                    Glyph = SolidGlyphs.IdCard,
                    Size = 20
                };
            }

            if (instructionsPage is NavigationPage instructionNavPage)
            {
                instructionNavPage.Title = "Information";
                instructionNavPage.IconImageSource = new FontImageSource()
                {
                    FontFamily = "FASolid",
                    Glyph = SolidGlyphs.BookOpen,
                    Size = 20
                };
            }


            Children.Add(childListPage);
            Children.Add(instructionsPage);
            // TODO: Add "logout" ability
        }
    }
}

