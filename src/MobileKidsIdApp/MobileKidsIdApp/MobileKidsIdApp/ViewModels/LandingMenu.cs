using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MobileKidsIdApp.ViewModels
{
    public class LandingMenu
    {
        public ICommand DisplayMainMenu { protected set; get; }

        public LandingMenu()
        {
            DisplayMainMenu = new Command<string>((text) => { });
        }
    }
}
