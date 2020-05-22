namespace MobileKidsIdApp.Models
{
    public class ContactInfo : NotifyPropertyChanged
    {
        public string Id { get; set; } // TODO: Platform specific identifier. should we be storing this? 

        private string _familyName;
        public string FamilyName
        {
            get => _familyName;
            set => SetProperty(ref _familyName, value);
        }

        private string _nickName;
        public string NickName
        {
            get => _nickName;
            set => SetProperty(ref _nickName, value);
        }

        private string _additionalName;
        public string AdditionalName
        {
            get => _additionalName;
            set => SetProperty(ref _additionalName, value);
        }

        private string _givenName;
        public string GivenName
        {
            get => _givenName;
            set => SetProperty(ref _givenName, value);
        }

        private string _contactNameManual;
        public string ContactNameManual
        {
            get => _contactNameManual;
            set => SetProperty(ref _contactNameManual, value);
        }

        private string _contactPhoneManual;
        public string ContactPhoneManual
        {
            get => _contactPhoneManual;
            set => SetProperty(ref _contactPhoneManual, value);
        }
    }
}
