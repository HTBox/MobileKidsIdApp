using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Csla;

namespace MobileKidsIdApp.Models
{
    [Serializable]
    public class UserIdentityList : BusinessListBase<UserIdentityList, UserIdentity>
    {
        private void Child_Fetch(List<DataAccess.DataModels.UserIdentity> list)
        {
            foreach (var item in list)
                Add(DataPortal.FetchChild<UserIdentity>(item));
        }
    }
}
