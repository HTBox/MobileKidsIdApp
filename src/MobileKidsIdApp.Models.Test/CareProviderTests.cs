using System;
using Csla;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace MobileKidsIdApp.Models.Test
{
    [TestClass]
    public class CareProviderTests
    {
        [TestCleanup]
        public async Task TestCleanup()
        {
            var family = await Csla.DataPortal.FetchAsync<Models.Family>();
            family.Clear();
            await family.SaveAsync();
        }

        [TestMethod]
        public async Task CareProviderPersistence()
        {
            var family = await Csla.DataPortal.FetchAsync<Models.Family>();

            var child = family.AddNew();
            var providers = child.ProfessionalCareProviders;
            var care = providers.AddNew();

            care.Address = "address";
            care.CareRoleDescription = "desc";
            care.ClinicName = "clinic";
            care.Phone = "phone";
            care.ProviderName = "name";

            var newFamily = await family.SaveAsync();
            new Csla.Core.GraphMerger().MergeBusinessListGraph<Family, Child>(family, newFamily);

            child = family[0];
            providers = child.ProfessionalCareProviders;
            care = providers[0];

            Assert.AreEqual("address", care.Address, "Address");
            Assert.AreEqual("desc", care.CareRoleDescription, "CareRoleDescription");
            Assert.AreEqual("clinic", care.ClinicName, "ClinicName");
            Assert.AreEqual("phone", care.Phone, "Phone");
            Assert.AreEqual("name", care.ProviderName, "ProviderName");
        }
    }
}
