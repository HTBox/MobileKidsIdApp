namespace MobileKidsIdApp.Models
{
    public partial class Child
    {
        private string _medicalAlertInfo;
        public string MedicalAlertInfo
        {
            get => _medicalAlertInfo;
            set => SetProperty(ref _medicalAlertInfo, value);
        }

        private string _allergies;
        public string Allergies
        {
            get => _allergies;
            set => SetProperty(ref _allergies, value);
        }

        private string _regularMedications;
        public string RegularMedications
        {
            get => _regularMedications;
            set => SetProperty(ref _regularMedications, value);
        }

        private string _psychMedications;
        public string PsychMedications
        {
            get => _psychMedications;
            set => SetProperty(ref _psychMedications, value);
        }

        private string _notes;
        public string Notes
        {
            get => _notes;
            set => SetProperty(ref _notes, value);
        }

        private bool _inhaler;
        public bool Inhaler
        {
            get => _inhaler;
            set => SetProperty(ref _inhaler, value);
        }

        private bool _diabetic;
        public bool Diabetic
    {
            get => _diabetic;
            set => SetProperty(ref _diabetic, value);
        }
    }
}
