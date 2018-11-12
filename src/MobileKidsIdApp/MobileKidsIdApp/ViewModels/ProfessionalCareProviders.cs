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
    public class ProfessionalCareProviders : ViewModelBase<Models.CareProviderList>
    {
        public ICommand NewItemCommand { get; private set; }

        public ProfessionalCareProviders(Models.CareProviderList list)
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
