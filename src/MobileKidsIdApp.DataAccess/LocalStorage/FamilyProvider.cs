using System;
using MobileKidsIdApp.DataAccess.DataModels;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO.IsolatedStorage;
using System.IO;

namespace MobileKidsIdApp.DataAccess.LocalStorage
{
    public class FamilyProvider : IFamilyProvider
    {
        private static readonly string FileName = "Family.txt";
        private static readonly string BackupFileName = "Family.bak";
        private static readonly IsolatedStorageScope FileScope = IsolatedStorageScope.User | IsolatedStorageScope.Assembly | IsolatedStorageScope.Roaming;

        public async Task<Family> Get()
        {
            Family result = null;
            using (var isoStore = IsolatedStorageFile.GetStore(FileScope, null))
            {
                if (isoStore.FileExists(FileName))
                {
                    using (var isoStream = new IsolatedStorageFileStream(FileName, FileMode.Open, FileAccess.Read))
                    {
                        using (var reader = new StreamReader(isoStream))
                        {
                            var json = await reader.ReadLineAsync();
                            var dataBlob = Encryption.Decrypt(Csla.ApplicationContext.User.Identity.Name, json);
                            result = JsonConvert.DeserializeObject<Family>(dataBlob);
                        }
                    }
                }
                else
                {
                    result = new Family();
                }
            }
            return result;
        }

        public async Task Save(Family data)
        {
            using (var isoStore = IsolatedStorageFile.GetStore(FileScope, null))
            {
                if (isoStore.FileExists(FileName))
                {
                    if (isoStore.FileExists(BackupFileName))
                        isoStore.DeleteFile(BackupFileName);
                    isoStore.CopyFile(FileName, BackupFileName);
                }
                using (var isoStream = new IsolatedStorageFileStream(FileName, FileMode.Create, FileAccess.Write))
                {
                    using (var writer = new StreamWriter(isoStream))
                    {
                        var json = JsonConvert.SerializeObject(data);
                        var dataBlob = Encryption.Encrypt(Csla.ApplicationContext.User.Identity.Name, json);
                        await writer.WriteLineAsync(dataBlob);
                    }
                }
            }
        }
    }
}
