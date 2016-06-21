using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Csla; 

namespace MobileKidsIdApp.Models
{
    [Serializable]
    public class FamilyMember : BaseTypes.BusinessBase<FamilyMember>
    {
        public static readonly PropertyInfo<int> IdProperty = RegisterProperty<int>(c => c.Id);
        public int Id
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
                ContactId = member.ContactId;
                Relation = member.Relation;
            }
        }

        private void Child_Insert(List<DataAccess.DataModels.FamilyMember> list)
        {
            Id = ((FamilyMemberList)Parent).Max(_ => _.Id) + 1;
            Child_Update(list);
        }

        private void Child_Update(List<DataAccess.DataModels.FamilyMember> list)
        {
            using (BypassPropertyChecks)
            {
                var member = new DataAccess.DataModels.FamilyMember();
                member.Id = Id;
                member.ContactId = ContactId;
                member.Relation = Relation;
                list.Add(member);
            }
        }
    }
}
