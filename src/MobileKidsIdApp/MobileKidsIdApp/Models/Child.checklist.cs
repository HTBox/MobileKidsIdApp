namespace MobileKidsIdApp.Models
{
    public partial class Child
    {
        // TODO: Review the usage of these proeprties.

        private bool _childPhotoComplete;
        public bool ChildPhotoComplete
        {
            get => _childPhotoComplete;
            set => SetProperty(ref _childPhotoComplete, value);
        }

        private bool _birthCertificateComplete;
        public bool BirthCertificateComplete
        {
            get => _birthCertificateComplete;
            set => SetProperty(ref _birthCertificateComplete, value);
        }

        private bool _socialSecurityCardComplete;
        public bool SocialSecurityCardComplete
        {
            get => _socialSecurityCardComplete;
            set => SetProperty(ref _socialSecurityCardComplete, value);
        }

        private bool _physicalDetailsComplete;
        public bool PhysicalDetailsComplete
        {
            get => _physicalDetailsComplete;
            set => SetProperty(ref _physicalDetailsComplete, value);
        }

        private bool _distinguishingFeaturesComplete;
        public bool DistinguishingFeaturesComplete
        {
            get => _distinguishingFeaturesComplete;
            set => SetProperty(ref _distinguishingFeaturesComplete, value);
        }

        private bool _friendsComplete;
        public bool FriendsComplete
        {
            get => _friendsComplete;
            set => SetProperty(ref _friendsComplete, value);
        }

        private bool _dnaComplete;
        public bool DNAComplete
        {
            get => _childPhotoComplete;
            set => SetProperty(ref _dnaComplete, value);
        }

        private bool _mementosComplete;
        public bool MementosComplete
        {
            get => _mementosComplete;
            set => SetProperty(ref _mementosComplete, value);
        }

        private bool _divorceCustodyPapersComplete;
        public bool DivorceCustodyPapersComplete
        {
            get => _divorceCustodyPapersComplete;
            set => SetProperty(ref _divorceCustodyPapersComplete, value);
        }

        private bool _otherParentsAndFamilyComplete;
        public bool OtherParentsAndFamilyComplete
        {
            get => _otherParentsAndFamilyComplete;
            set => SetProperty(ref _otherParentsAndFamilyComplete, value);
        }
    }
}
