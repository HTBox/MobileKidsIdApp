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

        public bool DataExists()
        {
            return (File.Exists(Path.Combine(LocalFolder, FileName)));
        }

        public async Task<bool> VerifyPasswordAsync(string password)
        {
            return await TestGetAsync(password, FileName);
        }

        private async Task<bool> TestGetAsync(string password, string fileName)
        {
            bool result = false;
            string filePath = Path.Combine(LocalFolder, fileName);
            if (File.Exists(filePath))
            {
                try
                {
                    var json = File.ReadAllText(filePath);
                    var dataBlob = Encryption.Decrypt(password, json);
                    // read and decrypted file, pw is good
                    result = true;

                }
                catch
                {
                    var backupPath = Path.Combine(LocalFolder, BackupFileName);
                    if (backupPath != filePath)
                    {
                        // see if pw works on backup file
                        if (File.Exists(backupPath))
                            result = await TestGetAsync(password, BackupFileName);
                    }
                }
            }
            else
            {
                // no file, new user, any pw is good
                result = true;
            }
            return result;
        }

        public async Task<Family> GetAsync()
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
                        result = await GetAsync();
                    }
                }
            }
            else
            {
                result = new Family();
            }
            return result;
        }

        public async Task SaveAsync(Family data)
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
