using System;
using Csla;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace MobileKidsIdApp.Models.Test
{
    [TestClass]
    public class PhysicalDetailsTests
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
            var details = child.PhysicalDetails;

            details.EyeColor = "blue";
            details.EyeContacts = true;
            details.EyeGlasses = true;
            details.Gender = "gender";
            details.GenderIdentity = "gi";
            details.HairColor = "black";
            details.HairStyle = "short";
            details.Height = "5'1\"";
            details.MeasurementDate = DateTime.Today;
            details.RacialEthnicIdentity = "race";
            details.SkinTone = "orange";
            details.Weight = "103";

            var newFamily = await family.SaveAsync();
            family = await Csla.DataPortal.FetchAsync<Models.Family>();

            child = family[0];
            details = child.PhysicalDetails;

            Assert.AreEqual("blue", details.EyeColor, "EyeColor");
            Assert.AreEqual(true, details.EyeContacts, "EyeContacts");
            Assert.AreEqual(true, details.EyeGlasses, "EyeGlasses");
            Assert.AreEqual("gender", details.Gender, "Gender");
            Assert.AreEqual("gi", details.GenderIdentity, "GenderIdentity");
            Assert.AreEqual("black", details.HairColor, "HairColor");
            Assert.AreEqual("short", details.HairStyle, "HairStyle");
            Assert.AreEqual("5'1\"", details.Height, "Height");
            Assert.AreEqual(DateTime.Today, details.MeasurementDate, "MeasurementDate");
            Assert.AreEqual("race", details.RacialEthnicIdentity, "RacialEthnicIdentity");
            Assert.AreEqual("orange", details.SkinTone, "SkinTone");
            Assert.AreEqual("103", details.Weight, "Weight");
        }
    }
}
