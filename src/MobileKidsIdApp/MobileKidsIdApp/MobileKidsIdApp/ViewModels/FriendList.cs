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
    public class FriendList : ViewModelBase<Models.FriendList>
    {
        public ICommand NewItemCommand { get; private set; }

        public FriendList(Models.FriendList list)
        {
            NewItemCommand = new Command(() => BeginAddNew());

            Model = list;
        }
    }
}
