using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileKidsIdApp.Model
{
    public class PreparationChecklist
    {
        public bool ChildPhoto { get; set; }
        public bool BirthCertificate { get; set; }
        public bool SocialSecurityCard { get; set; }
        public bool PhysicalDetails { get; set; }
        public bool distinguishingFeatures { get; set; }
        public bool Friends { get; set; }
        public bool DNA { get; set; }
        public bool Mementos { get; set; }
        public bool DivorceCustodyPapers { get; set; }
        public bool OtherParentsAndFamily { get; set; }
    }
}
