using System;
using System.Collections.Generic;
using System.Text;
using Csla;

namespace MobileKidsIdApp.Models
{
    [Serializable]
    public class FamilyExists : ReadOnlyBase<FamilyExists>
    {
        public static readonly PropertyInfo<bool> ExistsProperty = RegisterProperty<bool>(c => c.Exists);
        public bool Exists
        {
            get { return ReadProperty(ExistsProperty); }
            private set { LoadProperty(ExistsProperty, value); }
        }

        private void DataPortal_Fetch()
        {
            var provider = new DataAccess.DataProviderFactory().GetDataProvider();
            var dal = provider.GetFamilyProvider();
            Exists = dal.DataExists();
        }
    }
}
