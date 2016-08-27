﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Csla;

namespace MobileKidsIdApp.Models
{
    [Serializable]
    public class UserApplicationProfile : BaseTypes.BusinessBase<UserApplicationProfile>
    {
        public static readonly PropertyInfo<DateTime> FirstUseProperty = RegisterProperty<DateTime>(c => c.FirstUse);
        public DateTime FirstUse
        {
            get { return GetProperty(FirstUseProperty); }
            set { SetProperty(FirstUseProperty, value); }
        }

        public static readonly PropertyInfo<bool> LegalAcknowlegeDataSecurityPolicyProperty = RegisterProperty<bool>(c => c.LegalAcknowlegeDataSecurityPolicy);
        public bool LegalAcknowlegeDataSecurityPolicy
        {
            get { return GetProperty(LegalAcknowlegeDataSecurityPolicyProperty); }
            set { SetProperty(LegalAcknowlegeDataSecurityPolicyProperty, value); }
        }

        private void Child_Fetch(DataAccess.DataModels.UserApplicationProfile profile)
        {
            using (BypassPropertyChecks)
            {
                FirstUse = profile.FirstUse;
                LegalAcknowlegeDataSecurityPolicy = profile.LegalAcknowlegeDataSecurityPolicy;
            }
        }

        private void Child_Insert(DataAccess.DataModels.UserApplicationProfile profile)
        {
            Child_Update(profile);
        }

        private void Child_Update(DataAccess.DataModels.UserApplicationProfile profile)
        {
            using (BypassPropertyChecks)
            {
                profile.FirstUse = FirstUse;
                profile.LegalAcknowlegeDataSecurityPolicy = LegalAcknowlegeDataSecurityPolicy;
            }
        }
    }
}
