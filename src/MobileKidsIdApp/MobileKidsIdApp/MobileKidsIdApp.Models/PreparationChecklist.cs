using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Csla;

namespace MobileKidsIdApp.Models
{
        [Serializable]
    public class PreparationChecklist : BaseTypes.BusinessBase<PreparationChecklist>
    {
        public static readonly PropertyInfo<bool> ChildPhotoProperty = RegisterProperty<bool>(c => c.ChildPhoto);
        public bool ChildPhoto
        {
            get { return GetProperty(ChildPhotoProperty); }
            set { SetProperty(ChildPhotoProperty, value); }
        }

        public static readonly PropertyInfo<bool> BirthCertificateProperty = RegisterProperty<bool>(c => c.BirthCertificate);
        public bool BirthCertificate
        {
            get { return GetProperty(BirthCertificateProperty); }
            set { SetProperty(BirthCertificateProperty, value); }
        }

        public static readonly PropertyInfo<bool> SocialSecurityCardProperty = RegisterProperty<bool>(c => c.SocialSecurityCard);
        public bool SocialSecurityCard
        {
            get { return GetProperty(SocialSecurityCardProperty); }
            set { SetProperty(SocialSecurityCardProperty, value); }
        }

        public static readonly PropertyInfo<bool> PhysicalDetailsProperty = RegisterProperty<bool>(c => c.PhysicalDetails);
        public bool PhysicalDetails
        {
            get { return GetProperty(PhysicalDetailsProperty); }
            set { SetProperty(PhysicalDetailsProperty, value); }
        }

        public static readonly PropertyInfo<bool> DistinguishingFeaturesProperty = RegisterProperty<bool>(c => c.DistinguishingFeatures);
        public bool DistinguishingFeatures
        {
            get { return GetProperty(DistinguishingFeaturesProperty); }
            set { SetProperty(DistinguishingFeaturesProperty, value); }
        }

        public static readonly PropertyInfo<bool> FriendsProperty = RegisterProperty<bool>(c => c.Friends);
        public bool Friends
        {
            get { return GetProperty(FriendsProperty); }
            set { SetProperty(FriendsProperty, value); }
        }

        public static readonly PropertyInfo<bool> DNAProperty = RegisterProperty<bool>(c => c.DNA);
        public bool DNA
        {
            get { return GetProperty(DNAProperty); }
            set { SetProperty(DNAProperty, value); }
        }

        public static readonly PropertyInfo<bool> MementosProperty = RegisterProperty<bool>(c => c.Mementos);
        public bool Mementos
        {
            get { return GetProperty(MementosProperty); }
            set { SetProperty(MementosProperty, value); }
        }

        public static readonly PropertyInfo<bool> DivorceCustodyPapersProperty = RegisterProperty<bool>(c => c.DivorceCustodyPapers);
        public bool DivorceCustodyPapers
        {
            get { return GetProperty(DivorceCustodyPapersProperty); }
            set { SetProperty(DivorceCustodyPapersProperty, value); }
        }

        public static readonly PropertyInfo<bool> OtherParentsAndFamilyProperty = RegisterProperty<bool>(c => c.OtherParentsAndFamily);
        public bool OtherParentsAndFamily
        {
            get { return GetProperty(OtherParentsAndFamilyProperty); }
            set { SetProperty(OtherParentsAndFamilyProperty, value); }
        }

        private void Child_Fetch(DataAccess.DataModels.PreparationChecklist list)
        {
            if (list == null) return;
            using (BypassPropertyChecks)
            {
                ChildPhoto = list.ChildPhoto;
                BirthCertificate = list.BirthCertificate;
                SocialSecurityCard = list.SocialSecurityCard;
                PhysicalDetails = list.PhysicalDetails;
                DistinguishingFeatures = list.DistinguishingFeatures;
                Friends = list.Friends;
                DNA = list.DNA;
                Mementos = list.Mementos;
                DivorceCustodyPapers = list.DivorceCustodyPapers;
                OtherParentsAndFamily = list.OtherParentsAndFamily;
            }
        }

        private void Child_Insert(DataAccess.DataModels.PreparationChecklist list)
        {
            Child_Update(list);
        }

        private void Child_Update(DataAccess.DataModels.PreparationChecklist list)
        {
            using (BypassPropertyChecks)
            {
                list.ChildPhoto = ChildPhoto;
                list.BirthCertificate = BirthCertificate;
                list.SocialSecurityCard = SocialSecurityCard;
                list.PhysicalDetails = PhysicalDetails;
                list.DistinguishingFeatures = DistinguishingFeatures;
                list.Friends = Friends;
                list.DNA = DNA;
                list.Mementos = Mementos;
                list.DivorceCustodyPapers = DivorceCustodyPapers;
                list.OtherParentsAndFamily = OtherParentsAndFamily;
            }
        }
    }
}
