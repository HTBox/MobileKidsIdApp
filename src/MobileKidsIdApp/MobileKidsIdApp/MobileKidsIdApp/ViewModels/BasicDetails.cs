using Csla.Xaml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MobileKidsIdApp.ViewModels
{
    public class BasicDetails : ViewModelBase<Models.ChildDetails>
    {
        public ICommand ChangeContactCommand { get; private set; }

        public BasicDetails(Models.ChildDetails details)
        {
            ChangeContactCommand = new Command(() =>
            {
                // TODO: allow user to select contact from device
            });

            Model = details;
        }
    }
}
