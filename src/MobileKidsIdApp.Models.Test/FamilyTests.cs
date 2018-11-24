using Csla;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
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
            ApplicationContext.User = new AppPrincipal(new AppIdentity("test"));
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

            var child = family.AddNew();
            Assert.IsTrue(((Csla.Core.IBusinessObject)child).Identity > 0);

            var newFamily = await family.SaveAsync();
            //Assert.AreEqual(((Csla.Core.IBusinessObject)child).Identity, ((Csla.Core.IBusinessObject)newFamily[0]).Identity);

            new Csla.Core.GraphMerger().MergeBusinessListGraph<Family, Child>(family, newFamily);

            //Assert.AreEqual(((Csla.Core.IBusinessObject)child).Identity, ((Csla.Core.IBusinessObject)family[0]).Identity);
            //Assert.IsTrue(ReferenceEquals(child, family[0]));
        }

        [TestMethod]
        public async Task ClearFamily()
        {
            var family = await Csla.DataPortal.FetchAsync<Models.Family>();
            var child = family.AddNew();
            family.Add(child);
            await family.SaveAsync();

            family = await Csla.DataPortal.FetchAsync<Models.Family>();
            family.Clear();
            await family.SaveAsync();

            family = await Csla.DataPortal.FetchAsync<Models.Family>();
            Assert.IsTrue(family.Count == 0);
        }

        [TestMethod]
        public async Task VerifyNewPassword()
        {
            var provider = new DataAccess.DataProviderFactory().GetDataProvider();
            var dal = provider.GetFamilyProvider();
            // reset data to make sure there's no existing data file
            await dal.ResetData();
            // this should always be true b/c there's no existing file
            var verified = await dal.VerifyPasswordAsync("abcdef");
            Assert.IsTrue(verified);
        }

        [TestMethod]
        public async Task VerifyBadPassword()
        {
            var provider = new DataAccess.DataProviderFactory().GetDataProvider();
            var dal = provider.GetFamilyProvider();
            await dal.ResetData();
            var family = await Csla.DataPortal.FetchAsync<Models.Family>();
            family.AddNew().ChildDetails.FamilyName = "Smith";
            await family.SaveAsync();
            var verified = await dal.VerifyPasswordAsync("abcdef");
            Assert.IsFalse(verified);
        }

        [TestMethod]
        public async Task VerifyBackup()
        {
            var provider = new DataAccess.DataProviderFactory().GetDataProvider();
            var dal = provider.GetFamilyProvider();
            try
            {
                string FileName = "Family.txt";
                string BackupFileName = "Family.bak";
                string LocalFolder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                string PrimaryPath = Path.Combine(LocalFolder, FileName);
                string BackupPath = Path.Combine(LocalFolder, BackupFileName);

                await dal.ResetData();
                var family = await Csla.DataPortal.FetchAsync<Models.Family>();
                family.AddNew().ChildDetails.FamilyName = "Smith";
                family = await family.SaveAsync();
                family[0].ChildDetails.FamilyName = "Jones";
                family = await family.SaveAsync();

                Assert.IsTrue(File.Exists(PrimaryPath));
                Assert.IsTrue(File.Exists(BackupPath));

                family = await Csla.DataPortal.FetchAsync<Models.Family>();
                Assert.AreEqual("Jones", family[0].ChildDetails.FamilyName);

                // corrupt primary file
                File.WriteAllText(PrimaryPath, "foobar");

                // now backup file should be restored
                family = await Csla.DataPortal.FetchAsync<Models.Family>();
                Assert.AreEqual("Smith", family[0].ChildDetails.FamilyName);

            }
            finally
            {
                await dal.ResetData();
            }
        }
    }
}
