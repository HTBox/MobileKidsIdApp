using System;
using MobileKidsIdApp.DataAccess.DataModels;
using PCLStorage;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MobileKidsIdApp.DataAccess.LocalStorage
{
    public class ApplicationDataProvider : IApplicationDataProvider
    {
        public async Task<ApplicationData> Get()
        {
            ApplicationData result;
            var fileSystem = FileSystem.Current;
            var rootFolder = fileSystem.LocalStorage;
            var file = await rootFolder.GetFileAsync("ApplicationData.txt");
            if (file != null)
            {
                await file.OpenAsync(FileAccess.Read);
                var json = await file.ReadAllTextAsync();
                result = JsonConvert.DeserializeObject<ApplicationData>(json);
            }
            else
            {
                result = new ApplicationData();
            }
            return result;
        }

        public async Task Save(ApplicationData data)
        {
            var json = JsonConvert.SerializeObject(data);
            var fileSystem = FileSystem.Current;
            var rootFolder = fileSystem.LocalStorage;
            var file = await rootFolder.CreateFileAsync("ApplicationData.txt", CreationCollisionOption.ReplaceExisting);
            await file.WriteAllTextAsync(json);
        }
    }
}
