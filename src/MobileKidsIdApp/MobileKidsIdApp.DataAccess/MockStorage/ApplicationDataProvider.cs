using System;
using MobileKidsIdApp.DataAccess.DataModels;
using PCLStorage;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MobileKidsIdApp.DataAccess.MockStorage
{
    public class ApplicationDataProvider : IApplicationDataProvider
    {
        public async Task<ApplicationData> Get()
        {
            await MockDb.Init();
            var json = Encryption.Decrypt(Csla.ApplicationContext.User.Identity.Name, MockDb.ApplicationDataFile);
            var result = JsonConvert.DeserializeObject<ApplicationData>(json);
            return result;
        }

        public async Task Save(ApplicationData data)
        {
            await MockDb.Init();
            var json = JsonConvert.SerializeObject(data);
            var dataBlob = Encryption.Encrypt(Csla.ApplicationContext.User.Identity.Name, json);
            MockDb.ApplicationDataFile = dataBlob;
        }
    }
}
