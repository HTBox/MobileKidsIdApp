namespace MobileKidsIdApp.Models
{
    public class CareProvider : NotifyPropertyChanged
    {
        private string _providerName;
        public string ProviderName
        {
            get => _providerName;
            set => SetProperty(ref _providerName, value);
        }

        private string _clinicName;
        public string ClinicName
        {
            get => _clinicName;
            set => SetProperty(ref _clinicName, value);
        }

        private string _careRoleDescription;
        public string CareRoleDescription
        {
            get => _careRoleDescription;
            set => SetProperty(ref _careRoleDescription, value);
        }

        private string _address;
        public string Address
        {
            get => _address;
            set => SetProperty(ref _address, value);
        }

        private string _phone;
        public string Phone
        {
            get => _phone;
            set => SetProperty(ref _phone, value);
        }
    }
}
