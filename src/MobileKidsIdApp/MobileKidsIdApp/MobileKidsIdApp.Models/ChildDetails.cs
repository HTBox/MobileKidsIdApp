using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Csla; 

namespace MobileKidsIdApp.Models
{
        [Serializable]
    public class ChildDetails : BusinessBase<ChildDetails>
    {
        public static readonly PropertyInfo<string> GivenNameProperty = RegisterProperty<string>(c => c.GivenName);
        public string GivenName
        {
            get { return GetProperty(GivenNameProperty); }
            set { SetProperty(GivenNameProperty, value); }
        }

        public static readonly PropertyInfo<string> AdditionalNameProperty = RegisterProperty<string>(c => c.AdditionalName);
        public string AdditionalName
        {
            get { return GetProperty(AdditionalNameProperty); }
            set { SetProperty(AdditionalNameProperty, value); }
        }

        public static readonly PropertyInfo<string> FamilyNameProperty = RegisterProperty<string>(c => c.FamilyName);
        public string FamilyName
        {
            get { return GetProperty(FamilyNameProperty); }
            set { SetProperty(FamilyNameProperty, value); }
        }

        public static readonly PropertyInfo<DateTime?> BirthdayProperty = RegisterProperty<DateTime?>(c => c.Birthday);
        public DateTime? Birthday
        {
            get { return GetProperty(BirthdayProperty); }
            set { SetProperty(BirthdayProperty, value); }
        }

        public static readonly PropertyInfo<string> ContactReferenceProperty = RegisterProperty<string>(c => c.ContactReference);
        public string ContactReference
        {
            get { return GetProperty(ContactReferenceProperty); }
            set { SetProperty(ContactReferenceProperty, value); }
        }
    }
}
