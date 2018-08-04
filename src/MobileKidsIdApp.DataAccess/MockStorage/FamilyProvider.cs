using System;
using MobileKidsIdApp.DataAccess.DataModels;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MobileKidsIdApp.DataAccess.MockStorage
{
    public class FamilyProvider : IFamilyProvider
    {
        public async Task<bool> TestGetAsync(string password)
        {
            await Task.Delay(0);
            return true;
        }

        public async Task<Family> GetAsync()
        {
            await MockDb.Init();
            var json = Encryption.Decrypt(Csla.ApplicationContext.User.Identity.Name, MockDb.FamilyFile);
            var result = JsonConvert.DeserializeObject<Family>(json);
            return result;
        }

        public async Task SaveAsync(Family data)
        {
            await MockDb.Init();
            var json = JsonConvert.SerializeObject(data);
            var dataBlob = Encryption.Encrypt(Csla.ApplicationContext.User.Identity.Name, json);
            MockDb.FamilyFile = dataBlob;
        }
    }
}
