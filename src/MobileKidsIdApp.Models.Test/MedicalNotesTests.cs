using System;
using Csla;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

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
        public async Task AddChild()
        {
            var family = await Csla.DataPortal.FetchAsync<Models.Family>();

            var child = DataPortal.CreateChild<Child>();
            family.Add(child);
            var medical = child.MedicalNotes;

            medical.Allergies = "some";
            medical.Diabetic = true;
            medical.Inhaler = true;
            medical.MedicalAlertInfo = "yes";
            medical.Notes = "some notes";
            medical.PsychMedications = "psych";
            medical.RegularMedications = "regular";

            var newFamily = await family.SaveAsync();
            new Csla.Core.GraphMerger().MergeBusinessListGraph<Family, Child>(family, newFamily);

            Assert.AreEqual("some", medical.Allergies, "Allergies");
            Assert.AreEqual(true, medical.Diabetic, "Diabetic");
            Assert.AreEqual(true, medical.Inhaler, "Inhaler");
            Assert.AreEqual("yes", medical.MedicalAlertInfo, "MedicalAlertInfo");
            Assert.AreEqual("some notes", medical.Notes, "Notes");
            Assert.AreEqual("psych", medical.PsychMedications, "PsychMedications");
            Assert.AreEqual("regular", medical.RegularMedications, "RegularMedications");
        }
    }
}
