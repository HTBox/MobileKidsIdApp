using System;
using Csla;
using System.Collections.Generic;
using System.Linq;

namespace MobileKidsIdApp.Models
{
    [Serializable]
    public class FriendList : BusinessListBase<FriendList, Friend>
    {
        protected override Friend AddNewCore()
        {
            var nextId = 0;
            if (this.Count > 0)
            {
                nextId = this.Max(r => r.Id) + 1;
            }

            var newFriend = DataPortal.CreateChild<Friend>(nextId);
            Add(newFriend);
            OnAddedNew(newFriend);
            return newFriend;
        }

        private void Child_Fetch(List<DataAccess.DataModels.Person> list)
        {
            foreach (var item in list)
            {
                Add(DataPortal.FetchChild<Friend>(item));
            }
        }
    }
}