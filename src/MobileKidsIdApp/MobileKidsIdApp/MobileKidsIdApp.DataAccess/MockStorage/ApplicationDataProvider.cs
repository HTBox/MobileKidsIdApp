using System;
using MobileKidsIdApp.DataAccess.DataModels;
using PCLStorage;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MobileKidsIdApp.DataAccess.MockStorage
{
    public class ApplicationDataProvider : IApplicationDataProvider
    {
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task<ApplicationData> Get()
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            return MockDb.ApplicationData;
        }

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task Save(ApplicationData data)
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            MockDb.ApplicationData = data;
        }
    }
}
