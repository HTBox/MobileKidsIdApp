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
        public static readonly PropertyInfo<string> ProviderIdProperty = RegisterProperty<string>(c => c.ProviderId);
        public string ProviderId
        {
            get { return GetProperty(ProviderIdProperty); }
            private set { LoadProperty(ProviderIdProperty, value); }
        }

        public static readonly PropertyInfo<string> ProviderTokenProperty = RegisterProperty<string>(c => c.ProviderToken);
        public string ProviderToken
        {
            get { return GetProperty(ProviderTokenProperty); }
            private set { LoadProperty(ProviderTokenProperty, value); }
        }

        public static async Task<AppIdentity> GetAppIdentityAsync(string providerId, string providerToken)
        {
            return await DataPortal.FetchAsync<AppIdentity>(
                new AppIdentityCriteria { ProviderId = providerId, ProviderToken = providerToken });
        }

        private void DataPortal_Fetch(AppIdentityCriteria criteria)
        {
            ProviderId = criteria.ProviderId;
            Name = ProviderId;
            ProviderToken = criteria.ProviderToken;
            IsAuthenticated = true;
        }

        public static async Task<AppIdentity> CreateIdentity(string providerId, string providerToken)
        {
            return await DataPortal.FetchAsync<AppIdentity>(
                new AppIdentityCriteria { ProviderId = providerId, ProviderToken = providerToken });
        }

        [Serializable]
        public class AppIdentityCriteria : CriteriaBase<AppIdentityCriteria>
        {
            public static readonly PropertyInfo<string> ProviderIdProperty = RegisterProperty<string>(c => c.ProviderId);
            public string ProviderId
            {
                get { return ReadProperty(ProviderIdProperty); }
                set { LoadProperty(ProviderIdProperty, value); }
            }

            public static readonly PropertyInfo<string> ProviderTokenProperty = RegisterProperty<string>(c => c.ProviderToken);
            public string ProviderToken
            {
                get { return ReadProperty(ProviderTokenProperty); }
                set { LoadProperty(ProviderTokenProperty, value); }
            }
        }
    }
}
