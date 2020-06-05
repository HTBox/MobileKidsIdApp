using System;
using System.Collections.Generic;

namespace MobileKidsIdApp.Models
{
    public partial class Child : NotifyPropertyChanged
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string ContactID { get; set; } // TODO: What's the use of the contact IDs? 

        private string _givenName;
        public string GivenName
        {
            get => _givenName;
            set => SetProperty(ref _givenName, value);
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


        private string _familyName;
        public string FamilyName
        {
            get => _familyName;
            set => SetProperty(ref _familyName, value);
        }


        private DateTime _birthday;
        public DateTime Birthday
        {
            get => _birthday;
            set => SetProperty(ref _birthday, value);
        }

        // TODO: Is this property needed?
        private string _contactNameManual;
        public string ContactNameManual
        {
            get => _contactNameManual;
            set => SetProperty(ref _contactNameManual, value);
        }

        // TODO: Is this proeprty needed? 
        private string _contactPhoneManual;
        public string ContactPhoneManual
        {
            get => _contactPhoneManual;
            set => SetProperty(ref _contactPhoneManual, value);
        }


        public List<DistinguishingFeature> DistinguishingFeatures { get; set; } = new List<DistinguishingFeature>();

        public List<CareProvider> ProfessionalCareProviders { get; set; } = new List<CareProvider>();

        public List<FamilyMember> FamilyMembers { get; set; } = new List<FamilyMember>();

        public List<Friend> Friends { get; set; } = new List<Friend>();

        public List<FileReference> Documents { get; set; } = new List<FileReference>();

        public List<FileReference> Photos { get; set; } = new List<FileReference>();
    }
}
