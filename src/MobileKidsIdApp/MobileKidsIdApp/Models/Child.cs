using System;
using System.Collections.Generic;

namespace MobileKidsIdApp.Models
{
    public partial class Child : Person
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        private string _nickName;
        public string NickName
        {
            get => _nickName;
            set => SetProperty(ref _nickName, value);
        }

        private DateTime _birthday;
        public DateTime Birthday
        {
            get => _birthday;
            set => SetProperty(ref _birthday, value);
        }

        public List<DistinguishingFeature> DistinguishingFeatures { get; set; } = new List<DistinguishingFeature>();

        public List<CareProvider> ProfessionalCareProviders { get; set; } = new List<CareProvider>();

        public List<FamilyMember> FamilyMembers { get; set; } = new List<FamilyMember>();

        public List<Person> Friends { get; set; } = new List<Person>();

        public List<FileReference> Documents { get; set; } = new List<FileReference>();

        public List<FileReference> Photos { get; set; } = new List<FileReference>();
    }
}
