using System;
using MobileKidsIdApp.DataAccess.DataModels;
using System.Threading.Tasks;
using PCLStorage;
using Newtonsoft.Json;

namespace MobileKidsIdApp.DataAccess.MockStorage
{
    public class FamilyProvider : IFamilyProvider
    {
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task<Family> Get()
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            return MockDb.Family;
        }

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task Save(Family data)
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            MockDb.Family = data;
        }
    }
}
