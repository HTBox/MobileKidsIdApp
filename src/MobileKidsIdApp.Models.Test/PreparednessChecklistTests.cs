using System;
using Csla;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace MobileKidsIdApp.Models.Test
{
    [TestClass]
    public class PreparednessChecklistTests
    {
        [TestCleanup]
        public async Task TestCleanup()
        {
            var family = await Csla.DataPortal.FetchAsync<Models.Family>();
            family.Clear();
            await family.SaveAsync();
        }

        [TestMethod]
        public async Task PreparednessChecklistPersistence()
        {
            var family = await Csla.DataPortal.FetchAsync<Models.Family>();

            var child = family.AddNew();
            family.Add(child);
            var list = child.Checklist;

            list.BirthCertificate = true;
            list.ChildPhoto = true;
            list.DistinguishingFeatures = true;
            list.DivorceCustodyPapers = true;
            list.DNA = true;
            list.Friends = true;
            list.Mementos = true;
            list.OtherParentsAndFamily = true;
            list.PhysicalDetails = true;
            list.SocialSecurityCard = true;

            await family.SaveAsync();
            family = await Csla.DataPortal.FetchAsync<Models.Family>();
            child = family[0];
            list = child.Checklist;

            Assert.AreEqual(true, list.BirthCertificate, "BirthCertificate");
            Assert.AreEqual(true, list.ChildPhoto, "ChildPhoto");
            Assert.AreEqual(true, list.DistinguishingFeatures, "DistinguishingFeatures");
            Assert.AreEqual(true, list.DivorceCustodyPapers, "DivorceCustodyPapers");
            Assert.AreEqual(true, list.DNA, "DNA");
            Assert.AreEqual(true, list.Friends, "Friends");
            Assert.AreEqual(true, list.Mementos, "Mementos");
            Assert.AreEqual(true, list.OtherParentsAndFamily, "OtherParentsAndFamily");
            Assert.AreEqual(true, list.PhysicalDetails, "PhysicalDetails");
            Assert.AreEqual(true, list.SocialSecurityCard, "SocialSecurityCard");
        }
    }
}
