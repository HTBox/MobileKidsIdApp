using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MobileKidsIdApp.ViewModels
{
    public class Landing
    {
        public ICommand DisplayContentMenuCommand { get; private set; }
        public ICommand ChildProfileListCommand { get; private set; }
        public ICommand OptionsCommand { get; private set; }
        public ICommand LogoutCommand { get; private set; }

        public Landing()
        {
            DisplayContentMenuCommand = new Command(async () =>
            {
                await NavigateTo(new Views.InstructionIndex { BindingContext = new InstructionIndex() });
            });
            ChildProfileListCommand = new Command(async () =>
            {
                var vm = await new ChildProfileList().InitAsync();
                await NavigateTo(new Views.ChildProfileList { BindingContext = vm });
            });
            OptionsCommand = new Command(async () =>
            {
                var vm = await new Settings().InitAsync();
                await NavigateTo(new Views.Settings { BindingContext = vm });
            });
            LogoutCommand = new Command(async () =>
            {
                await App.Logout();
            });
        }

        private async Task NavigateTo(Page view)
        {
            await App.RootPage.Navigation.PushAsync(view);
        }
    }
}
