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

        public Landing()
        {
            DisplayContentMenuCommand = new Command<string>((text) => 
            {
                App.RootPage.Navigation.PushAsync(new Views.StaticContent { BindingContext = new StaticContent() });
            });
        }
    }
}
