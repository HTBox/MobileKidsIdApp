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

        public static readonly PropertyInfo<string> ContactReferenceProperty = RegisterProperty<string>(c => c.ContactReference);
        public string ContactReference
        {
            get { return GetProperty(ContactReferenceProperty); }
            private set { LoadProperty(ContactReferenceProperty, value); }
        }
    }
}
