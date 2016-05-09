using System;
using Csla;
using System.Collections.Generic;

namespace MobileKidsIdApp.Models
{
    [Serializable]
    public class CareProviderList : BusinessListBase<CareProviderList, CareProvider>
    {
        private void Child_Fetch(List<DataAccess.DataModels.CareProvider> list)
        {
            foreach (var item in list)
                Add(DataPortal.FetchChild<CareProvider>(item));
        }
    }
}