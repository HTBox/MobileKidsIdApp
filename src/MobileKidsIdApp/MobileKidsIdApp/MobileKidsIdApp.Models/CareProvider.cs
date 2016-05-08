using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Csla;

namespace MobileKidsIdApp.Models
{
    [Serializable]
    public class CareProvider : BusinessBase<CareProvider>
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
    }
}
