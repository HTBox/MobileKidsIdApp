using Csla;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using System.Linq;

namespace MobileKidsIdApp.Models.Test
{
    [TestClass]
    public class PhotosTests
    {
        [TestCleanup]
        public async Task TestCleanup()
        {
            var family = await Csla.DataPortal.FetchAsync<Models.Family>();
            family.Clear();
            await family.SaveAsync();
        }

        [TestMethod]
        public async Task PhotosPersistence()
        {
            var family = await Csla.DataPortal.FetchAsync<Models.Family>();

            var child = family.AddNew();
            var photos = child.Photos;

            var photo = photos.AddNew();

            photo.Description = "desc";
            photo.FileName = "file";

            var newFamily = await family.SaveAsync();
            family = await Csla.DataPortal.FetchAsync<Models.Family>();

            child = family[0];
            photos = child.Photos;

            Assert.AreEqual("desc", photo.Description, "Description");
            Assert.AreEqual("file", photo.FileName, "FileName");
        }

        [TestMethod]
        public async Task PhotoDelete()
        {
            var family = await DataPortal.FetchAsync<Models.Family>();

            var child = family.AddNew();
            var photos = child.Photos;

            var photo = photos.AddNew();

            photo.Description = "desc";
            photo.FileName = "file";

            var newFamily = await family.SaveAsync();
            family = await Csla.DataPortal.FetchAsync<Models.Family>();
            var savedChild = family[0];
            var savedPhoto = savedChild.Photos[0];
            savedChild.Photos.Remove(savedPhoto);

            newFamily = await family.SaveAsync();
            family = await Csla.DataPortal.FetchAsync<Models.Family>();
            child = family[0];

            Assert.IsTrue(!child.Photos.Any());
        }
    }
}
