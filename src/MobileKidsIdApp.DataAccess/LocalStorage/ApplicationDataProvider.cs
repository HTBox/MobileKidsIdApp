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
        private static readonly string LocalFolder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

        public async Task<ApplicationData> Get()
        {
            ApplicationData result = null;
            if (File.Exists(Path.Combine(LocalFolder, FileName)))
            {
                try
                {
                    var json = File.ReadAllText(Path.Combine(LocalFolder, FileName));
                    var dataBlob = Encryption.Decrypt(Csla.ApplicationContext.User.Identity.Name, json);
                    result = JsonConvert.DeserializeObject<ApplicationData>(dataBlob);

                }
                catch
                {
                    if (File.Exists(Path.Combine(LocalFolder, BackupFileName)))
                    {
                        File.Delete(Path.Combine(LocalFolder, FileName));
                        File.Copy(Path.Combine(LocalFolder, BackupFileName), Path.Combine(LocalFolder, FileName));
                        result = await Get();
                    }
                }
            }
            else
            {
                result = new ApplicationData();
            }
            return result;
        }

        public async Task Save(ApplicationData data)
        {
            if (File.Exists(Path.Combine(LocalFolder, FileName)))
            {
                if (File.Exists(Path.Combine(LocalFolder, BackupFileName)))
                {
                    await Task.Run(() => File.Delete(Path.Combine(LocalFolder, BackupFileName)));

                }
                File.Copy(Path.Combine(LocalFolder, FileName), Path.Combine(LocalFolder, BackupFileName));
            }
            var json = JsonConvert.SerializeObject(data);
            var dataBlob = Encryption.Encrypt(Csla.ApplicationContext.User.Identity.Name, json);
            await Task.Run(() => File.WriteAllText(Path.Combine(LocalFolder, FileName), dataBlob));

        }
    }
}
