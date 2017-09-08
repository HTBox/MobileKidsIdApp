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
        public static readonly PropertyInfo<int> IdProperty = RegisterProperty<int>(c => c.Id);
        public int Id
        {
            get { return GetProperty(IdProperty); }
            set { LoadProperty(IdProperty, value); }
        }

        public static readonly PropertyInfo<string> ProviderNameProperty = RegisterProperty<string>(c => c.ProviderName);
        public string ProviderName
        {
            get { return GetProperty(ProviderNameProperty); }
            set { SetProperty(ProviderNameProperty, value); }
        }

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

        public static readonly PropertyInfo<string> AddressProperty = RegisterProperty<string>(c => c.Address);
        public string Address
        {
            get { return GetProperty(AddressProperty); }
            set { SetProperty(AddressProperty, value); }
        }

        public static readonly PropertyInfo<string> PhoneProperty = RegisterProperty<string>(c => c.Phone);
        public string Phone
        {
            get { return GetProperty(PhoneProperty); }
            set { SetProperty(PhoneProperty, value); }
        }

        private void Child_Fetch(DataAccess.DataModels.CareProvider provider)
        {
            using (BypassPropertyChecks)
            {
                Id = provider.Id;
                ProviderName = provider.ProviderName;
                ClinicName = provider.ClinicName;
                CareRoleDescription = provider.CareRoleDescription;
                Address = provider.Address;
                Phone = provider.Phone;
            }
        }

        private void Child_Insert(List<DataAccess.DataModels.CareProvider> list)
        {
            Id = ((CareProviderList)Parent).Max(_ => _.Id) + 1;
            Child_Update(list);
        }

        private void Child_Update(List<DataAccess.DataModels.CareProvider> list)
        {
            var provider = new DataAccess.DataModels.CareProvider();
            using (BypassPropertyChecks)
            {
                provider.Id = Id;
                provider.ProviderName = ProviderName;
                provider.ClinicName = ClinicName;
                provider.CareRoleDescription = CareRoleDescription;
                provider.Address = Address;
                provider.Phone = Phone;
            }
            list.Add(provider);
        }
    }
}
