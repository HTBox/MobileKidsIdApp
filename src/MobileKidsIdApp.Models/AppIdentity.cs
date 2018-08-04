using Csla;
using Csla.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileKidsIdApp.Models
{
    [Serializable]
    public class AppIdentity : CslaIdentityBase<AppIdentity>
    {
        public static async Task<AppIdentity> LoginAsync(string password)
        {
            return await DataPortal.FetchAsync<AppIdentity>(password);
        }

#pragma warning disable CSLA0010 // Find Operation Arguments That Are Not Serializable
        private async Task DataPortal_Fetch(string password)
#pragma warning restore CSLA0010 // Find Operation Arguments That Are Not Serializable
        {
            var provider = new DataAccess.DataProviderFactory().GetDataProvider();
            var dal = provider.GetFamilyProvider();
            var verified = await dal.TestGetAsync(password);
            if (verified)
            {
                Name = password;
                IsAuthenticated = true;
            }
        }
    }
}
