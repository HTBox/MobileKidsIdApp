using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Csla;

namespace MobileKidsIdApp.Models
{
    [Serializable]
    public class CareProvider : BaseTypes.BusinessBase<CareProvider>
    {
        public static readonly PropertyInfo<string> ClinicNameProperty = RegisterProperty<string>(c => c.ClinicName);
        public string ClinicName
        {
            get { return GetProperty(ClinicNameProperty); }
            set { SetProperty(ClinicNameProperty, value); }
        }

        public static readonly PropertyInfo<string> CareRoleDescriptionProperty = RegisterProperty<string>(c => c.CareRoleDescription);
        public string CareRoleDescription
        {
            get { return GetProperty(CareRoleDescriptionProperty); }
            set { SetProperty(CareRoleDescriptionProperty, value); }
        }

        private void Child_Fetch(DataAccess.DataModels.CareProvider provider)
        {
            using (BypassPropertyChecks)
            {
                ClinicName = provider.ClinicName;
                CareRoleDescription = provider.CareRoleDescription;
            }
        }

        private void Child_Update(List<DataAccess.DataModels.CareProvider> list)
        {
            var provider = new DataAccess.DataModels.CareProvider();
            using (BypassPropertyChecks)
            {
                provider.ClinicName = ClinicName;
                provider.CareRoleDescription = CareRoleDescription;
            }
            list.Add(provider);
        }
    }
}
