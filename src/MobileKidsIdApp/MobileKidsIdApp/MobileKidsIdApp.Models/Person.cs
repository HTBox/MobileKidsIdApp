using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Csla;

namespace MobileKidsIdApp.Models
{
    [Serializable]
    public class Person : BusinessBase<Person>
    {
        public static readonly PropertyInfo<string> IdProperty = RegisterProperty<string>(c => c.Id);
        public string Id
        {
            get { return GetProperty(IdProperty); }
            private set { LoadProperty(IdProperty, value); }
        }

        public static readonly PropertyInfo<string> ContactIdProperty = RegisterProperty<string>(c => c.ContactId);
        public string ContactId
        {
            get { return GetProperty(ContactIdProperty); }
            private set { LoadProperty(ContactIdProperty, value); }
        }

        public static int LastId = -1;
        protected override void Child_Create()
        {
            using (BypassPropertyChecks)
            {
                LastId++;
                Id = LastId.ToString();
            }
            base.Child_Create();
        }

        private void Child_Fetch(DataAccess.DataModels.Person person)
        {
            using (BypassPropertyChecks)
            {
                Id = person.Id;
                ContactId = person.ContactId;
            }
        }

        private void Child_Update(List<DataAccess.DataModels.Person> list)
        {
            var person = new DataAccess.DataModels.Person();
            using (BypassPropertyChecks)
            {
                person.Id = Id;
                person.ContactId = ContactId;
            }
            list.Add(person);
        }
    }
}
