using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using MobileKidsIdApp.Models;

namespace MobileKidsIdApp.Services
{
    public partial class FamilyRepository
    {
        private readonly string FileName = "f.htbox";
        private string BasePath => Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        private string FilePath => Path.Combine(BasePath, FileName);

        private List<Child> LoadChildren()
        {
            if (File.Exists(FilePath))
            {
                byte[] encrypted = File.ReadAllBytes(FilePath);
                byte[] decrypted = Decrypt(encrypted);
                string json = Encoding.UTF8.GetString(decrypted);
                return DeserializeChildren(json);
            }

            return new List<Child>();
        }

        private void StoreChildren()
        { 
            File.WriteAllText(FilePath, SerializeChildren(Children));

            string json = SerializeChildren(Children);
            byte[] decrypted = Encoding.UTF8.GetBytes(json);
            byte[] encrypted = Encrypt(decrypted);
            if (File.Exists(FilePath)) File.Delete(FilePath);
            File.WriteAllBytes(FilePath, encrypted);
        }

        private string SerializeChildren(List<Child> children)
            => JsonSerializer.Serialize(children);

        private List<Child> DeserializeChildren(string json)
            => JsonSerializer.Deserialize<List<Child>>(json);
    }
}
