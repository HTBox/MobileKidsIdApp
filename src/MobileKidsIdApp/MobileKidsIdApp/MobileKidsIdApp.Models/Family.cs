using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Csla;

namespace MobileKidsIdApp.Models
{
    [Serializable]
    public class Family : BusinessListBase<Family, Child>
    {
        private void DataPortal_Fetch()
        {
            var provider = new DataAccess.DataProviderFactory().GetDataProvider();
            var dal = provider.GetFamilyProvider();
            var data = dal.Get();
            foreach (var item in data.Children)
                Add(DataPortal.FetchChild<Child>(item));
        }
    }
}
