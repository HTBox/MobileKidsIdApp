using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Csla; 

namespace MobileKidsIdApp.Models
{
    [Serializable]
    public class FamilyMember : BusinessBase<FamilyMember>
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

        public static readonly PropertyInfo<string> RelationProperty = RegisterProperty<string>(c => c.Relation);
        public string Relation
        {
            get { return GetProperty(RelationProperty); }
            set { SetProperty(RelationProperty, value); }
        }

        private void Child_Fetch(DataAccess.DataModels.FamilyMember member)
        {
            using (BypassPropertyChecks)
            {
                Id = member.Id;
                ContactId = member.ContactReference.ContactId;
                Relation = member.Relation;
            }
        }
    }
}
