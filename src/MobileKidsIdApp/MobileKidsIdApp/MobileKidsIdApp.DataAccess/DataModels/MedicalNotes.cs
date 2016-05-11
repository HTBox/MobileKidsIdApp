using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileKidsIdApp.DataAccess.DataModels
{
    public class MedicalNotes
    {
        public string MedicAlertInfo { get; set; }
        public string Allergies { get; set; }
        public string RegularMedications { get; set; }
        public string PsychMedications { get; set; }
        public string Notes { get; set; }
        public bool? Inhaler { get; set; }
        public bool? Diabetic { get; set; }
    }
}
