using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Csla;

namespace MobileKidsIdApp.Models
{
    [Serializable]
    public class Child : BusinessBase<Child>
    {
        public static readonly PropertyInfo<string> IdProperty = RegisterProperty<string>(c => c.Id);
        public string Id
        {
            get { return GetProperty(IdProperty); }
            private set { LoadProperty(IdProperty, value); }
        }

        public static readonly PropertyInfo<ChildDetails> ChildDetailsProperty = RegisterProperty<ChildDetails>(c => c.ChildDetails);
        public ChildDetails ChildDetails
        {
            get { return GetProperty(ChildDetailsProperty); }
            private set { LoadProperty(ChildDetailsProperty, value); }
        }

        public static readonly PropertyInfo<PhysicalDetails> PhysicalDetailsProperty = RegisterProperty<PhysicalDetails>(c => c.PhysicalDetails);
        public PhysicalDetails PhysicalDetails
        {
            get { return GetProperty(PhysicalDetailsProperty); }
            private set { LoadProperty(PhysicalDetailsProperty, value); }
        }

        public static readonly PropertyInfo<DistinguishingFeatureList> DistinguishingFeaturesProperty = RegisterProperty<DistinguishingFeatureList>(c => c.DistinguishingFeatures);
        public DistinguishingFeatureList DistinguishingFeatures
        {
            get { return GetProperty(DistinguishingFeaturesProperty); }
            private set { LoadProperty(DistinguishingFeaturesProperty, value); }
        }

        public static readonly PropertyInfo<CareProviderList> ProfessionalCareProvidersProperty = RegisterProperty<CareProviderList>(c => c.ProfessionalCareProviders);
        public CareProviderList ProfessionalCareProviders
        {
            get { return GetProperty(ProfessionalCareProvidersProperty); }
            private set { LoadProperty(ProfessionalCareProvidersProperty, value); }
        }

        public static readonly PropertyInfo<FamilyMemberList> FamilyMembersProperty = RegisterProperty<FamilyMemberList>(c => c.FamilyMembers);
        public FamilyMemberList FamilyMembers
        {
            get { return GetProperty(FamilyMembersProperty); }
            private set { LoadProperty(FamilyMembersProperty, value); }
        }

        public static readonly PropertyInfo<FriendList> FriendsProperty = RegisterProperty<FriendList>(c => c.Friends);
        public FriendList Friends
        {
            get { return GetProperty(FriendsProperty); }
            private set { LoadProperty(FriendsProperty, value); }
        }

        public static readonly PropertyInfo<MedicalNotes> MedicalNotesProperty = RegisterProperty<MedicalNotes>(c => c.MedicalNotes);
        public MedicalNotes MedicalNotes
        {
            get { return GetProperty(MedicalNotesProperty); }
            private set { LoadProperty(MedicalNotesProperty, value); }
        }

        public static readonly PropertyInfo<PreparationChecklist> ChecklistProperty = RegisterProperty<PreparationChecklist>(c => c.Checklist);
        public PreparationChecklist Checklist
        {
            get { return GetProperty(ChecklistProperty); }
            private set { LoadProperty(ChecklistProperty, value); }
        }

        public static readonly PropertyInfo<FileReferenceList> DocumentsProperty = RegisterProperty<FileReferenceList>(c => c.Documents);
        public FileReferenceList Documents
        {
            get { return GetProperty(DocumentsProperty); }
            private set { LoadProperty(DocumentsProperty, value); }
        }

        public static readonly PropertyInfo<FileReferenceList> PhotosProperty = RegisterProperty<FileReferenceList>(c => c.Photos);
        public FileReferenceList Photos
        {
            get { return GetProperty(PhotosProperty); }
            private set { LoadProperty(PhotosProperty, value); }
        }

        public static int LastId = -1;
        protected override void Child_Create()
        {
            using (BypassPropertyChecks)
            {
                LastId++;
                Id = LastId.ToString();
            }
            base.Child_Create();
        }

        private void Child_Fetch(DataAccess.DataModels.Child child)
        {
            using (BypassPropertyChecks)
            {
                Id = child.Id;
                ChildDetails = DataPortal.FetchChild<ChildDetails>(child.ChildDetails);
                PhysicalDetails = DataPortal.FetchChild<PhysicalDetails>(child.PhysicalDetails);
                DistinguishingFeatures = DataPortal.FetchChild<DistinguishingFeatureList>(child.DistinguishingFeatures);
                ProfessionalCareProviders = DataPortal.FetchChild<CareProviderList>(child.ProfessionalCareProviders);
                FamilyMembers = DataPortal.FetchChild<FamilyMemberList>(child.FamilyMembers);
                Friends = DataPortal.FetchChild<FriendList>(child.Friends);
                MedicalNotes = DataPortal.FetchChild<MedicalNotes>(child.MedicalNotes);
                Checklist = DataPortal.FetchChild<PreparationChecklist>(child.Checklist);
                Documents = DataPortal.FetchChild<FileReferenceList>(child.Documents);
                Photos = DataPortal.FetchChild<FileReferenceList>(child.Photos);
            }
        }

        private void Child_Update(List<DataAccess.DataModels.Child> list)
        {
            var child = new DataAccess.DataModels.Child();
            using (BypassPropertyChecks)
            {
                child.Id = Id;
                DataPortal.UpdateChild(ChildDetails, child.ChildDetails);
                DataPortal.UpdateChild(PhysicalDetails, child.PhysicalDetails);
                DataPortal.UpdateChild(DistinguishingFeatures, child.DistinguishingFeatures);
                DataPortal.UpdateChild(ProfessionalCareProviders, child.ProfessionalCareProviders);
                DataPortal.UpdateChild(FamilyMembers, child.FamilyMembers);
                DataPortal.UpdateChild(Friends, child.Friends);
                DataPortal.UpdateChild(MedicalNotes, child.MedicalNotes);
                DataPortal.UpdateChild(Checklist, child.Checklist);
                DataPortal.UpdateChild(Documents, child.Documents);
                DataPortal.UpdateChild(Photos, child.Photos);
            }
            list.Add(child);
        }
    }
}
