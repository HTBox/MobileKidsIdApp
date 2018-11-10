using System;
using Csla;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace MobileKidsIdApp.Models.Test
{
    [TestClass]
    public class FriendsTests
    {
        [TestCleanup]
        public async Task TestCleanup()
        {
            var family = await Csla.DataPortal.FetchAsync<Models.Family>();
            family.Clear();
            await family.SaveAsync();
        }

        [TestMethod]
        public async Task FriendsPersistence()
        {
            var family = await Csla.DataPortal.FetchAsync<Models.Family>();

            var child = family.AddNew();
            var friends = child.Friends;
            var friend = friends.AddNew();

            friend.ContactId = "id";

            var newFamily = await family.SaveAsync();
            family = await Csla.DataPortal.FetchAsync<Models.Family>();

            child = family[0];
            friend = child.Friends[0];
            Assert.AreEqual("id", friend.ContactId, "ContactId");

        }
    }
}
