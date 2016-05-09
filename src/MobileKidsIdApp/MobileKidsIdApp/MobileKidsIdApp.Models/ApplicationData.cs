using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Csla;

namespace MobileKidsIdApp.Models
{
    [Serializable]
    public class ApplicationData : BusinessBase<ApplicationData>
    {
        public static readonly PropertyInfo<UserApplicationProfile> UserApplicationProfileProperty = RegisterProperty<UserApplicationProfile>(c => c.UserApplicationProfile);
        public UserApplicationProfile UserApplicationProfile
        {
            get { return GetProperty(UserApplicationProfileProperty); }
            private set { LoadProperty(UserApplicationProfileProperty, value); }
        }

        public static readonly PropertyInfo<UserIdentityList> PermittedLoginIdentitiesProperty = RegisterProperty<UserIdentityList>(c => c.PermittedLoginIdentities);
        public UserIdentityList PermittedLoginIdentities
        {
            get { return GetProperty(PermittedLoginIdentitiesProperty); }
            private set { LoadProperty(PermittedLoginIdentitiesProperty, value); }
        }

        protected override void DataPortal_Create()
        {
            UserApplicationProfile = DataPortal.CreateChild<UserApplicationProfile>();
            PermittedLoginIdentities = DataPortal.CreateChild<UserIdentityList>();
        }

        private async Task DataPortal_Fetch()
        {
            var provider = new DataAccess.DataProviderFactory().GetDataProvider();
            var dal = provider.GetApplicationDataProvider();
            var data = await dal.Get();
            using (BypassPropertyChecks)
            {
                UserApplicationProfile = DataPortal.FetchChild<UserApplicationProfile>(data.UserApplicationProfile);
                PermittedLoginIdentities = DataPortal.FetchChild<UserIdentityList>(data.PermittedLoginIdentities);
            }
        }

        private new async Task DataPortal_Update()
        {
            var provider = new DataAccess.DataProviderFactory().GetDataProvider();
            var dal = provider.GetApplicationDataProvider();
            var dtoRoot = new DataAccess.DataModels.ApplicationData();
            DataPortal.UpdateChild(UserApplicationProfile, dtoRoot.UserApplicationProfile);
            DataPortal.UpdateChild(PermittedLoginIdentities, dtoRoot.PermittedLoginIdentities);
            await dal.Save(dtoRoot);
        }
    }
}
