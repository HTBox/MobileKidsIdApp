﻿using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Csla;

namespace MobileKidsIdApp.Models
{
    [Serializable]
    public class Family : BusinessListBase<Family, Child>
    {
        private async Task DataPortal_Fetch()
        {
            try
            {
                var provider = new DataAccess.DataProviderFactory().GetDataProvider();
                var dal = provider.GetFamilyProvider();
                var data = await dal.GetAsync();
                foreach (var item in data.Children)
                    Add(DataPortal.FetchChild<Child>(item));
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Exception in Family.DataPortal_Fetch(): {e}");
                throw;
            }
        }

        private new async Task DataPortal_Update()
        {
            try
            {
                var provider = new DataAccess.DataProviderFactory().GetDataProvider();
                var dal = provider.GetFamilyProvider();
                var dtoRoot = new DataAccess.DataModels.Family();
                Child_Update(dtoRoot.Children);
                await dal.SaveAsync(dtoRoot);
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Exception in Family.DataPortal_Update(): {e}");
                throw;
            }
        }
    }
}
