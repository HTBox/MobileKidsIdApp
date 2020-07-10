namespace MobileKidsIdApp.Models
{
    public class Person : NotifyPropertyChanged
    {
        private string _familyName;
        public string FamilyName
        {
            get => _familyName;
            set => SetProperty(ref _familyName, value);
        }

        private string _givenName;
        public string GivenName
        {
            get => _givenName;
            set => SetProperty(ref _givenName, value);
        }

        private string _additionalName;
        public string AdditionalName
        {
            get => _additionalName;
            set => SetProperty(ref _additionalName, value);
        }
    }
}
