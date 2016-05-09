using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileKidsIdApp.DataAccess.DataModels
{
    public class Child
    {
        public Child()
        {
            DistinguishingFeatures = new List<DistinguishingFeature>();
            ProfessionalCareProviders = new List<CareProvider>();
            FamilyMembers = new List<FamilyMember>();
            Friends = new List<Person>();
            Documents = new List<FileReference>();
            Photos = new List<FileReference>();
        }

        public string Id { get; set; }
        public ChildDetails ChildDetails { get; set; }
        public PhysicalDetails PhysicalDetails { get; set; }
        public List<DistinguishingFeature> DistinguishingFeatures { get; set; }
        public List<CareProvider> ProfessionalCareProviders { get; set; }
        public List<FamilyMember> FamilyMembers { get; set; }
        public List<Person> Friends { get; set; }
        public MedicalNotes MedicalNotes { get; set; }
        public PreparationChecklist Checklist { get; set; }
        public List<FileReference> Documents { get; set; }
        public List<FileReference> Photos { get; set; }
    }
}
