using System;
using Csla;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace MobileKidsIdApp.Models.Test
{
    [TestClass]
    public class DocumentsTests
    {
        [TestCleanup]
        public async Task TestCleanup()
        {
            var family = await Csla.DataPortal.FetchAsync<Models.Family>();
            family.Clear();
            await family.SaveAsync();
        }

        [TestMethod]
        public async Task DocumentsPersistence()
        {
            var family = await Csla.DataPortal.FetchAsync<Models.Family>();

            var child = family.AddNew();
            var docs = child.Documents;
            var doc = docs.AddNew();

            doc.Description = "desc";
            doc.FileName = "file";

            var newFamily = await family.SaveAsync();
            family = await Csla.DataPortal.FetchAsync<Models.Family>();

            child = family[0];
            doc = child.Documents[0];
            Assert.AreEqual("desc", doc.Description, "Description");
            Assert.AreEqual("file", doc.FileName, "FileName");

        }
    }
}
