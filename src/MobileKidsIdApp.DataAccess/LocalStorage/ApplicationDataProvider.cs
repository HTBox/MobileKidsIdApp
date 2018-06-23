using System;
using MobileKidsIdApp.DataAccess.DataModels;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO.IsolatedStorage;
using System.IO;

namespace MobileKidsIdApp.DataAccess.LocalStorage
{
    public class ApplicationDataProvider : IApplicationDataProvider
    {
        private static readonly string FileName = "ApplicationData.txt";
        private static readonly string BackupFileName = "ApplicationData.bak";
        private static readonly IsolatedStorageScope FileScope = IsolatedStorageScope.User | IsolatedStorageScope.Assembly | IsolatedStorageScope.Roaming;

        public async Task<ApplicationData> Get()
        {
            ApplicationData result = null;
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
                            result = JsonConvert.DeserializeObject<ApplicationData>(dataBlob);
                        }
                    }
                }
                else
                {
                    result = new ApplicationData();
                }
            }
            return result;
        }

        public async Task Save(ApplicationData data)
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
