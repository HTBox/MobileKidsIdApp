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

        public static readonly PropertyInfo<List<DistinguishingFeature>> DistinguishingFeaturesProperty = RegisterProperty<List<DistinguishingFeature>>(c => c.DistinguishingFeatures);
        public List<DistinguishingFeature> DistinguishingFeatures
        {
            get { return GetProperty(DistinguishingFeaturesProperty); }
            private set { LoadProperty(DistinguishingFeaturesProperty, value); }
        }

        public static readonly PropertyInfo<List<CareProvider>> ProfessionalCareProvidersProperty = RegisterProperty<List<CareProvider>>(c => c.ProfessionalCareProviders);
        public List<CareProvider> ProfessionalCareProviders
        {
            get { return GetProperty(ProfessionalCareProvidersProperty); }
            private set { LoadProperty(ProfessionalCareProvidersProperty, value); }
        }

        public static readonly PropertyInfo<List<FamilyMember>> FamilyMembersProperty = RegisterProperty<List<FamilyMember>>(c => c.FamilyMembers);
        public List<FamilyMember> FamilyMembers
        {
            get { return GetProperty(FamilyMembersProperty); }
            private set { LoadProperty(FamilyMembersProperty, value); }
        }

        public static readonly PropertyInfo<List<Person>> FriendsProperty = RegisterProperty<List<Person>>(c => c.Friends);
        public List<Person> Friends
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

        public static readonly PropertyInfo<List<FileReference>> DocumentsProperty = RegisterProperty<List<FileReference>>(c => c.Documents);
        public List<FileReference> Documents
        {
            get { return GetProperty(DocumentsProperty); }
            private set { LoadProperty(DocumentsProperty, value); }
        }

        public static readonly PropertyInfo<List<FileReference>> PhotosProperty = RegisterProperty<List<FileReference>>(c => c.Photos);
        public List<FileReference> Photos
        {
            get { return GetProperty(PhotosProperty); }
            private set { LoadProperty(PhotosProperty, value); }
        }
    }
}
