namespace MobileKidsIdApp.Models
{
    public class Friend : NotifyPropertyChanged
    {
        public string ContactId { get; set; } // TODO: Revise use of these

        public Friend() { }

        public Friend(ContactInfo contact) => UpdateFromContact(contact);

        private string _familyName;
        public string FamilyName
        {
            get => _familyName;
            set
            {
                SetProperty(ref _familyName, value);
                UpdateDisplay();
            }
        }

        private string _givenName;
        public string GivenName
        {
            get => _givenName;
            set
            {
                SetProperty(ref _givenName, value);
                UpdateDisplay();
            }
        }

        private string _additionalName;
        public string AdditionalName
        {
            get => _additionalName;
            set => SetProperty(ref _additionalName, value);
        }

        private string _display;
        public string Display 
        {
            get => _display;
            set => SetProperty(ref _display, value);
        }

        public void UpdateFromContact(ContactInfo contact)
        {
            ContactId = contact.Id;
            FamilyName = contact.FamilyName;
            GivenName = contact.GivenName;
            AdditionalName = contact.AdditionalName;

            UpdateDisplay();
        }

        // TODO: Rework to use Span in view
        private void UpdateDisplay() => Display = $"{GivenName} {FamilyName}";
    }
}
