using Csla;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace MobileKidsIdApp.Models.Test
{
    [TestClass]
    public class FamilyTests
    {
        [AssemblyInitialize]
        public static void AssemblyInitialize(TestContext context)
        {
            ApplicationContext.ContextManager = new ApplicationContextManager();
            ApplicationContext.User = new AppPrincipal(new AppIdentity(true));
        }

        [TestCleanup]
        public async Task TestCleanup()
        {
            var family = await Csla.DataPortal.FetchAsync<Models.Family>();
            family.Clear();
            await family.SaveAsync();
        }

        [TestMethod]
        public void UsingCorrectApplicationContextManager()
        {
            Assert.IsInstanceOfType(Csla.ApplicationContext.ContextManager, typeof(MobileKidsIdApp.Models.ApplicationContextManager));
        }

        [TestMethod]
        public async Task LoadFamily()
        {
            var family = await Csla.DataPortal.FetchAsync<Models.Family>();
            Assert.IsNotNull(family, "family null");
        }

        [TestMethod]
        public async Task AddChild()
        {
            var family = await Csla.DataPortal.FetchAsync<Models.Family>();

            var child = DataPortal.CreateChild<Child>();
            family.Add(child);
            var newFamily = await family.SaveAsync();
            new Csla.Core.GraphMerger().MergeBusinessListGraph<Family, Child>(family, newFamily);

            Assert.AreNotSame(child, family[0]);
        }

        [TestMethod]
        public async Task ClearFamily()
        {
            var family = await Csla.DataPortal.FetchAsync<Models.Family>();
            var child = DataPortal.CreateChild<Child>();
            family.Add(child);
            await family.SaveAsync();

            family = await Csla.DataPortal.FetchAsync<Models.Family>();
            family.Clear();
            await family.SaveAsync();

            family = await Csla.DataPortal.FetchAsync<Models.Family>();
            Assert.IsTrue(family.Count == 0);
        }
    }
}
