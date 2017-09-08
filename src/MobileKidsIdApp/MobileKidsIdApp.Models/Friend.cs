using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Csla;

namespace MobileKidsIdApp.Models
{
    [Serializable]
    public class Friend : BaseTypes.BusinessBase<Friend>
    {
        public Friend()
        {
            MarkAsChild();
        }

        public static readonly PropertyInfo<int> IdProperty = RegisterProperty<int>(c => c.Id);
        public int Id
        {
            get { return GetProperty(IdProperty); }
            set { LoadProperty(IdProperty, value); }
        }

        public static readonly PropertyInfo<string> ContactIdProperty = RegisterProperty<string>(c => c.ContactId);
        public string ContactId
        {
            get { return GetProperty(ContactIdProperty); }
            set { SetProperty(ContactIdProperty, value); }
        }

        private void Child_Fetch(DataAccess.DataModels.Person person)
        {
            using (BypassPropertyChecks)
            {
                Id = person.Id;
                ContactId = person.ContactId;
            }
        }

        private void Child_Insert(List<DataAccess.DataModels.Person> list)
        {
            Id = ((FriendList)Parent).Max(_ => _.Id) + 1;
            Child_Update(list);
        }

        private void Child_Update(List<DataAccess.DataModels.Person> list)
        {
            using (BypassPropertyChecks)
            {
                var person = new DataAccess.DataModels.Person();
                person.Id = Id;
                person.ContactId = ContactId;
                list.Add(person);
            }
        }
    }
}
