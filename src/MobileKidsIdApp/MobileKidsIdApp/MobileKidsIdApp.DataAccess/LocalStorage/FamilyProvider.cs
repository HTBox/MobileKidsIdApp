using System;
using MobileKidsIdApp.DataAccess.DataModels;
using System.Threading.Tasks;
using PCLStorage;
using Newtonsoft.Json;

namespace MobileKidsIdApp.DataAccess.LocalStorage
{
    public class FamilyProvider : IFamilyProvider
    {
        public async Task<Family> Get()
        {
            Family result;
            var fileSystem = FileSystem.Current;
            var rootFolder = fileSystem.LocalStorage;
            var file = await rootFolder.GetFileAsync("Family.txt");
            if (file != null)
            {
                await file.OpenAsync(FileAccess.Read);
                var json = await file.ReadAllTextAsync();
                result = JsonConvert.DeserializeObject<Family>(json);
            }
            else
            {
                result = new Family();
            }
            return result;
        }

        public async Task Save(Family data)
        {
            var json = JsonConvert.SerializeObject(data);
            var fileSystem = FileSystem.Current;
            var rootFolder = fileSystem.LocalStorage;
            var file = await rootFolder.CreateFileAsync("Family.txt", CreationCollisionOption.ReplaceExisting);
            await file.WriteAllTextAsync(json);
        }
    }
}
