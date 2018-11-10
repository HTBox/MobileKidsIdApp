using System;
using Csla;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace MobileKidsIdApp.Models.Test
{
    [TestClass]
    public class DistinguishingFeaturesTests
    {
        [TestCleanup]
        public async Task TestCleanup()
        {
            var family = await Csla.DataPortal.FetchAsync<Models.Family>();
            family.Clear();
            await family.SaveAsync();
        }

        [TestMethod]
        public async Task DistinguishingFeaturesPersistence()
        {
            var family = await Csla.DataPortal.FetchAsync<Models.Family>();

            var child = family.AddNew();
            family.Add(child);
            var features = child.DistinguishingFeatures;
            var feature = features.AddNew();

            feature.Description = "desc";
            feature.FileReference.Description = "file desc";
            feature.FileReference.FileName = "file";

            var newFamily = await family.SaveAsync();
            new Csla.Core.GraphMerger().MergeBusinessListGraph<Family, Child>(family, newFamily);

            features = family[0].DistinguishingFeatures;
            feature = features[0];

            Assert.AreEqual("desc", feature.Description, "Description");
            Assert.AreEqual("file desc", feature.FileReference.Description, "FileReference.Description");
            Assert.AreEqual("file", feature.FileReference.FileName, "FileReference.FileName");

        }
    }
}
