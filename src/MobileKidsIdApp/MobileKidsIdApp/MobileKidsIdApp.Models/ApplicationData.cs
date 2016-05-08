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

        public static readonly PropertyInfo<List<UserIdentity>> PermittedLoginIdentitiesProperty = RegisterProperty<List<UserIdentity>>(c => c.PermittedLoginIdentities);
        public List<UserIdentity> PermittedLoginIdentities
        {
            get { return GetProperty(PermittedLoginIdentitiesProperty); }
            private set { LoadProperty(PermittedLoginIdentitiesProperty, value); }
        }

        protected override void DataPortal_Create()
        {
            UserApplicationProfile = new UserApplicationProfile();
            PermittedLoginIdentities = new List<UserIdentity>();
        }
    }
}
