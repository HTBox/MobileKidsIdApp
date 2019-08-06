using System;
using MobileKidsIdApp.DataAccess.DataModels;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using System.Diagnostics;

namespace MobileKidsIdApp.DataAccess.LocalStorage
{
    public class FamilyProvider : IFamilyProvider
    {
        private static readonly string FileName = "Family.txt";
        private static readonly string BackupFileName = "Family.bak";
        private static readonly string LocalFolder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

        private static string PrimaryPath
        { get { return Path.Combine(LocalFolder, FileName); } }

        private static string BackupPath
        { get { return Path.Combine(LocalFolder, BackupFileName); } }

        public bool DataExists()
        {
            return (File.Exists(PrimaryPath));
        }

        public async Task<bool> VerifyPasswordAsync(string password)
        {
            return await TestGetAsync(password, FileName);
        }

        private async Task<bool> TestGetAsync(string password, string fileName)
        {
            bool result = false;
            if (File.Exists(PrimaryPath))
            {
                try
                {
                    var json = File.ReadAllText(PrimaryPath);
                    var dataBlob = Encryption.Decrypt(password, json);
                    // read and decrypted file, pw is good
                    result = true;

                }
                catch(Exception e)
                {
                    Debug.WriteLine($"Exception caught in FamilyProvider.TestGetAsync(): {e}");
                    if (BackupPath != PrimaryPath)
                    {
                        // see if pw works on backup file
                        if (File.Exists(BackupPath))
                            result = await TestGetAsync(password, BackupFileName);
                    }
                }
            }
            else
            {
                // no file means new user, any pw is good
                result = true;
            }
            return result;
        }

        public async Task<Family> GetAsync()
        {
            Family result = null;
            if (File.Exists(PrimaryPath))
            {
                try
                {
                    var json = File.ReadAllText(PrimaryPath);
                    var dataBlob = Encryption.Decrypt(Csla.ApplicationContext.User.Identity.Name, json);
                    result = JsonConvert.DeserializeObject<Family>(dataBlob);
                         
                }
                catch(Exception e)
                {
                    Debug.WriteLine($"Exception caught in FamilyProvider.GetAsync(): {e}");
                    // if we can't read primary file, restore last backup
                    // and try again
                    if (File.Exists(BackupPath))
                    {
                        File.Copy(BackupPath, PrimaryPath, true);
                        File.Delete(BackupPath);
                        result = await GetAsync();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            else
            {
                result = new Family();
            }
            return result;
        }

        public Task SaveAsync(Family data)
        {
            if (File.Exists(PrimaryPath))
            {
                File.Copy(PrimaryPath, BackupPath, true);
            }
            var json = JsonConvert.SerializeObject(data);
            var dataBlob = Encryption.Encrypt(Csla.ApplicationContext.User.Identity.Name, json);
            File.WriteAllText(PrimaryPath, dataBlob);

            return Task.CompletedTask;
        }

        public Task ResetData()
        {
            if (File.Exists(BackupPath))
                File.Delete(BackupPath);
            if (File.Exists(PrimaryPath))
                File.Delete(PrimaryPath);

            return Task.CompletedTask;
        }
    }
}
