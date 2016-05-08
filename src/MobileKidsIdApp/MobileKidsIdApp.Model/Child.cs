using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileKidsIdApp.Model
{
    public class Child
    {
        public Child()
        {
            DistinguishingFeatures = Enumerable.Empty<DistinguishingFeature>();
            ProfessionalCareProviders = Enumerable.Empty<CareProvider>();
            FamilyMembers = Enumerable.Empty<FamilyMember>();
            Friends = Enumerable.Empty<Person>();
            Documents = Enumerable.Empty<FileReference>();
            Photos = Enumerable.Empty<FileReference>();
        }

        public string Id { get; set; }
        public ChildDetails ChildDetails { get; set; }
        public PhysicalDetails PhysicalDetails { get; set; }
        public IEnumerable<DistinguishingFeature> DistinguishingFeatures { get; set; }
        public IEnumerable<CareProvider> ProfessionalCareProviders { get; set; }
        public IEnumerable<FamilyMember> FamilyMembers { get; set; }
        public IEnumerable<Person> Friends { get; set; }
        public MedicalNotes MedicalNotes { get; set; }
        public PreparationChecklist Checklist { get; set; }
        public IEnumerable<FileReference> Documents { get; set; }
        public IEnumerable<FileReference> Photos { get; set; }
    }
}
