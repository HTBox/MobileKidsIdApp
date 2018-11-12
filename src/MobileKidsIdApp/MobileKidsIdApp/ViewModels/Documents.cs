using Csla.Xaml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileKidsIdApp.ViewModels
{
    public class Documents : ViewModelBase<object>
    {
        public string MainText
        { get { return "Coming Soon"; }}

        internal async Task SaveDataAsync()
        {
            await App.CurrentFamily.SaveFamilyAsync();
            Model = null;
        }
    }
}
