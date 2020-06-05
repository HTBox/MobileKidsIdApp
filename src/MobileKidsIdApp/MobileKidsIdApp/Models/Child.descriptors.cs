using System;

namespace MobileKidsIdApp.Models
{
    public partial class Child
    {
        private string _height;
        public string Height
        {
            get => _height;
            set => SetProperty(ref _height, value);
        }

        private string _weight;
        public string Weight
        {
            get => _weight;
            set => SetProperty(ref _weight, value);
        }

        private DateTime _measurementDate;
        public DateTime MeasurementDate
        {
            get => _measurementDate;
            set => SetProperty(ref _measurementDate, value);
        }

        private string _hairColor;
        public string HairColor
        {
            get => _hairColor;
            set => SetProperty(ref _hairColor, value);
        }

        private string _hairStyle;
        public string HairStyle
        {
            get => _hairStyle;
            set => SetProperty(ref _hairStyle, value);
        }

        private string _eyeColor;
        public string EyeColor
        {
            get => _eyeColor;
            set => SetProperty(ref _eyeColor, value);
        }

        private bool _eyeContacts;
        public bool EyeContacts
        {
            get => _eyeContacts;
            set => SetProperty(ref _eyeContacts, value);
        }

        private bool _eyeGlasses;
        public bool EyeGlasses
        {
            get => _eyeGlasses;
            set => SetProperty(ref _eyeGlasses, value);
        }

        private string _skinTone;
        public string SkinTone
        {
            get => _skinTone;
            set => SetProperty(ref _skinTone, value);
        }

        private string _racialEthnicIdentity;
        public string RacialEthnicIdentity
        {
            get => _racialEthnicIdentity;
            set => SetProperty(ref _racialEthnicIdentity, value);
        }

        private string _gender;
        public string Gender
        {
            get => _gender;
            set => SetProperty(ref _gender, value);
        }

        private string _genderIdentity;
        public string GenderIdentity
        {
            get => _genderIdentity;
            set => SetProperty(ref _genderIdentity, value);
        }
    }
}
