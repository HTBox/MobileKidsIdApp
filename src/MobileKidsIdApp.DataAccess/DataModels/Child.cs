using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileKidsIdApp.DataAccess.DataModels
{
    public class Child
    {
        public int Id { get; set; }
        public ChildDetails ChildDetails { get; set; } 
            = new ChildDetails();
        public PhysicalDetails PhysicalDetails { get; set; } 
            = new PhysicalDetails();
        public List<DistinguishingFeature> DistinguishingFeatures { get; set; }
            = new List<DistinguishingFeature>();
        public List<CareProvider> ProfessionalCareProviders { get; set; }
            = new List<CareProvider>();
        public List<FamilyMember> FamilyMembers { get; set; }
            = new List<FamilyMember>();
        public List<Person> Friends { get; set; }
            = new List<Person>();
        public MedicalNotes MedicalNotes { get; set; }
            = new MedicalNotes();
        public PreparationChecklist Checklist { get; set; }
            = new PreparationChecklist();
        public List<FileReference> Documents { get; set; }
            = new List<FileReference>();
        public List<FileReference> Photos { get; set; }
            = new List<FileReference>();
    }
}
