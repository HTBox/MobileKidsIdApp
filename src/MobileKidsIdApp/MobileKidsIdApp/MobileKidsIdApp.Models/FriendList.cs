using System;
using Csla;
using System.Collections.Generic;

namespace MobileKidsIdApp.Models
{
    [Serializable]
    public class FriendList : BusinessListBase<FriendList, Friend>
    {
        private void Child_Fetch(List<DataAccess.DataModels.Person> list)
        {
            foreach (var item in list)
                Add(DataPortal.FetchChild<Friend>(item));
        }
    }
}