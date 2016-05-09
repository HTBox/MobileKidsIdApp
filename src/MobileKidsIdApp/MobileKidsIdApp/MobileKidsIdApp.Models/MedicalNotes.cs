using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Csla;

namespace MobileKidsIdApp.Models
{
    [Serializable]
    public class MedicalNotes : BusinessBase<MedicalNotes>
    {
        public static readonly PropertyInfo<string> MedicalAlertInfoProperty = RegisterProperty<string>(c => c.MedicalAlertInfo);
        public string MedicalAlertInfo
        {
            get { return GetProperty(MedicalAlertInfoProperty); }
            set { SetProperty(MedicalAlertInfoProperty, value); }
        }

        public static readonly PropertyInfo<string> AllergiesProperty = RegisterProperty<string>(c => c.Allergies);
        public string Allergies
        {
            get { return GetProperty(AllergiesProperty); }
            set { SetProperty(AllergiesProperty, value); }
        }

        public static readonly PropertyInfo<string> RegularMedicationsProperty = RegisterProperty<string>(c => c.RegularMedications);
        public string RegularMedications
        {
            get { return GetProperty(RegularMedicationsProperty); }
            set { SetProperty(RegularMedicationsProperty, value); }
        }

        public static readonly PropertyInfo<string> PsychMedicationsProperty = RegisterProperty<string>(c => c.PsychMedications);
        public string PsychMedications
        {
            get { return GetProperty(PsychMedicationsProperty); }
            set { SetProperty(PsychMedicationsProperty, value); }
        }

        public static readonly PropertyInfo<string> NotesProperty = RegisterProperty<string>(c => c.Notes);
        public string Notes
        {
            get { return GetProperty(NotesProperty); }
            set { SetProperty(NotesProperty, value); }
        }

        public static readonly PropertyInfo<bool?> InhalerProperty = RegisterProperty<bool?>(c => c.Inhaler);
        public bool? Inhaler
        {
            get { return GetProperty(InhalerProperty); }
            set { SetProperty(InhalerProperty, value); }
        }

        public static readonly PropertyInfo<bool?> DiabeticProperty = RegisterProperty<bool?>(c => c.Diabetic);
        public bool? Diabetic
        {
            get { return GetProperty(DiabeticProperty); }
            set { SetProperty(DiabeticProperty, value); }
        }

        private void Child_Fetch(DataAccess.DataModels.MedicalNotes notes)
        {
            using (BypassPropertyChecks)
            {
                MedicalAlertInfo = notes.MedicAlertInfo;
                Allergies = notes.Allergies;
                RegularMedications = notes.RegularMedications;
                PsychMedications = notes.PsychMedications;
                Notes = notes.Notes;
                Inhaler = notes.Inhaler;
                Diabetic = notes.Diabetic;
            }
        }
    }
}
