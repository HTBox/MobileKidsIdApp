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
        private static readonly string LocalFolder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        public async Task<Family> Get()
        {
            Family result = null;
            if(File.Exists(Path.Combine(LocalFolder,FileName)))
            {
                try
                {
                    var json = File.ReadAllText(Path.Combine(LocalFolder, FileName));
                    var dataBlob = Encryption.Decrypt(Csla.ApplicationContext.User.Identity.Name, json);
                    result = JsonConvert.DeserializeObject<Family>(dataBlob);
                         
                }
                catch
                {
                    if(File.Exists(Path.Combine(LocalFolder,BackupFileName)))
                    {
                        File.Delete(Path.Combine(LocalFolder, FileName));
                        File.Copy(Path.Combine(LocalFolder, BackupFileName), Path.Combine(LocalFolder, FileName));
                        result = await Get();
                    }
                }
            }
            else
            {
                result = new Family();
            }
            return result;
        }

        public async Task Save(Family data)
        {
            if(File.Exists(Path.Combine(LocalFolder,FileName)))
            {
                if(File.Exists(Path.Combine(LocalFolder,BackupFileName)))
                {
                    await Task.Run(()=>File.Delete(Path.Combine(LocalFolder, BackupFileName)));

                }
                File.Copy(Path.Combine(LocalFolder, FileName), Path.Combine(LocalFolder, BackupFileName));
            }
            var json = JsonConvert.SerializeObject(data);
            var dataBlob = Encryption.Encrypt(Csla.ApplicationContext.User.Identity.Name, json);
            await Task.Run(()=> File.WriteAllText(Path.Combine(LocalFolder, FileName), dataBlob));

        }
    }
}
