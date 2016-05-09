using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobileKidsIdApp.Models;

namespace MobileKidsIdApp.ViewModels
{
    public class ChildProfileList : Csla.Xaml.ViewModelBase<Models.Family>
    {
        protected async override Task<Family> DoInitAsync()
        {
            return await Csla.DataPortal.FetchAsync<Models.Family>();
        }
    }
}
