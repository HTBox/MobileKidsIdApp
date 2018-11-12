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
    public class FamilyMemberList : ViewModelBase<Models.FamilyMemberList>
    {
        public ICommand NewItemCommand { get; private set; }

        public FamilyMemberList(Models.FamilyMemberList list)
        {
            NewItemCommand = new Command(() => BeginAddNew());

            Model = list;
        }

        public async Task SaveDataAsync()
        {
            await App.CurrentFamily.SaveFamilyAsync();
            Model = null;
        }
    }
}
