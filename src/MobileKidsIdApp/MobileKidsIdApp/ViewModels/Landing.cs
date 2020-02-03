using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MobileKidsIdApp.ViewModels
{
    public class Landing
    {
        public ICommand DisplayContentMenuCommand { get; private set; }
        public ICommand OptionsCommand { get; private set; }
        public ICommand LogoutCommand { get; private set; }

        public Landing()
        {
            DisplayContentMenuCommand = new Command(async () =>
            {
                Shell.Current.FlyoutIsPresented = false;
                await NavigateTo(new Views.InstructionIndex { BindingContext = new InstructionIndex() });
            });
            OptionsCommand = new Command(async () =>
            {
                Shell.Current.FlyoutIsPresented = false;
                // TODO: Settings VM needs to be fleshed out before we can call InitAsync()
                //var vm = await new Settings().InitAsync();
                await NavigateTo(new Views.Settings { BindingContext = new Settings() });
            });
            LogoutCommand = new Command(() =>
            {
                Shell.Current.FlyoutIsPresented = false;
                ((App)Application.Current).Logout();
            });
        }

        private async Task NavigateTo(Page view)
        {
            await Shell.Current.Navigation.PushAsync(view);
        }
    }
}
