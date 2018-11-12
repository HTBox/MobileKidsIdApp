using System;
using Csla;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using System.Linq;

namespace MobileKidsIdApp.Models.Test
{
    [TestClass]
    public class MedicalNotesTests
    {
        [TestCleanup]
        public async Task TestCleanup()
        {
            var family = await Csla.DataPortal.FetchAsync<Models.Family>();
            family.Clear();
            await family.SaveAsync();
        }

        [TestMethod]
        public async Task MedicalNotesPersistence()
        {
            var family = await Csla.DataPortal.FetchAsync<Models.Family>();

            var child = family.AddNew();
            var medical = child.MedicalNotes;

            medical.Allergies = "some";
            medical.Diabetic = true;
            medical.Inhaler = true;
            medical.MedicalAlertInfo = "yes";
            medical.Notes = "some notes";
            medical.PsychMedications = "psych";
            medical.RegularMedications = "regular";

            var newFamily = await family.SaveAsync();
            family = await Csla.DataPortal.FetchAsync<Models.Family>();

            child = family[0];
            medical = child.MedicalNotes;

            Assert.AreEqual("some", medical.Allergies, "Allergies");
            Assert.AreEqual(true, medical.Diabetic, "Diabetic");
            Assert.AreEqual(true, medical.Inhaler, "Inhaler");
            Assert.AreEqual("yes", medical.MedicalAlertInfo, "MedicalAlertInfo");
            Assert.AreEqual("some notes", medical.Notes, "Notes");
            Assert.AreEqual("psych", medical.PsychMedications, "PsychMedications");
            Assert.AreEqual("regular", medical.RegularMedications, "RegularMedications");
        }

        [TestMethod]
        public async Task MedicalNotesAddEditSave()
        {
            var family = await Csla.DataPortal.FetchAsync<Models.Family>();

            var child = family.AddNew();
            child.ChildDetails.GivenName = "a";
            child.ChildDetails.FamilyName = "z";
            await family.SaveAsync();

            family = await Csla.DataPortal.FetchAsync<Models.Family>();
            child = family.First();
            var med = child.MedicalNotes;
            med.Allergies = "bad";

            await family.SaveAsync();

            family = await Csla.DataPortal.FetchAsync<Models.Family>();
            child = family.First();
            med = child.MedicalNotes;
            Assert.AreEqual("bad", med.Allergies);
        }
    }
}
