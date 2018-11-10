using System;
using Csla;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace MobileKidsIdApp.Models.Test
{
    [TestClass]
    public class BasicDetailsTests
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
            var details = child.ChildDetails;

            details.GivenName = "Johan";
            details.FamilyName = "Zang";
            details.AdditionalName = "Harry";
            details.Birthday = DateTime.Parse("10/5/2012");
            
            var newFamily = await family.SaveAsync();
            new Csla.Core.GraphMerger().MergeBusinessListGraph<Family, Child>(family, newFamily);

            child = family[0];
            details = child.ChildDetails;

            details = family[0].ChildDetails;
            Assert.AreEqual("Johan", details.GivenName, "GivenName");
            Assert.AreEqual("Zang", details.FamilyName, "FamilyName");
            Assert.AreEqual("Harry", details.AdditionalName, "AdditionalName");
            Assert.AreEqual(DateTime.Parse("10/5/2012"), details.Birthday, "Birthday");

        }
    }
}
