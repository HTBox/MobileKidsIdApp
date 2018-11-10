using System;
using Csla;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace MobileKidsIdApp.Models.Test
{
    [TestClass]
    public class FamilyMembersTests
    {
        [TestCleanup]
        public async Task TestCleanup()
        {
            var family = await Csla.DataPortal.FetchAsync<Models.Family>();
            family.Clear();
            await family.SaveAsync();
        }

        [TestMethod]
        public async Task FamilyMembersPersistence()
        {
            var family = await Csla.DataPortal.FetchAsync<Models.Family>();

            var child = family.AddNew();
            var members = child.FamilyMembers;
            var member = members.AddNew();

            member.ContactId = "id";
            member.Relation = "relation";

            var newFamily = await family.SaveAsync();
            family = await Csla.DataPortal.FetchAsync<Models.Family>();

            child = family[0];
            member = child.FamilyMembers[0];
            Assert.AreEqual("id", member.ContactId, "ContactId");
            Assert.AreEqual("relation", member.Relation, "Relation");

        }
    }
}
