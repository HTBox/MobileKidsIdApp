namespace MobileKidsIdApp.Models
{
    public class FamilyMember : Person
    {
        private string _relation;
        public string Relation
        {
            get => _relation;
            set => SetProperty(ref _relation, value);
        }
    }
}
