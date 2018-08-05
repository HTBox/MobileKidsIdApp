using System;
using Csla;
using System.Collections.Generic;
using System.Linq;

namespace MobileKidsIdApp.Models
{
    [Serializable]
    public class CareProviderList : BusinessListBase<CareProviderList, CareProvider>
    {
        protected override CareProvider AddNewCore()
        {
            var nextId = 0;
            if (this.Count > 0)
                nextId = this.Max(r => r.Id) + 1;

            var result = DataPortal.CreateChild<CareProvider>(nextId);
            Add(result);
            return result;
        }

        private void Child_Fetch(List<DataAccess.DataModels.CareProvider> list)
        {
            foreach (var item in list)
                Add(DataPortal.FetchChild<CareProvider>(item));
        }
    }
}