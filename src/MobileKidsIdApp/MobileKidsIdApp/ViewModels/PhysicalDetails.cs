using Csla.Xaml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileKidsIdApp.ViewModels
{
    public class PhysicalDetails : ViewModelBase<Models.PhysicalDetails>
    {
        public PhysicalDetails(Models.PhysicalDetails physicalDetails)
        {
            Model = physicalDetails;
        }

        public async Task SaveDataAsync()
        {
            await App.CurrentFamily.SaveFamilyAsync();
        }
    }
}
