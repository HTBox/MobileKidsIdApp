using System;
using MobileKidsIdApp.DataAccess.DataModels;
using PCLStorage;
using System.Threading.Tasks;

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
                var data = file.ReadAllTextAsync();
                // TODO: deserialize data here
                result = new ApplicationData();
            }
            else
            {
                result = new ApplicationData();
            }
            return result;
        }

        public async Task Save(ApplicationData data)
        {
            var fileSystem = FileSystem.Current;
            var rootFolder = fileSystem.LocalStorage;
            var file = await rootFolder.CreateFileAsync("ApplicationData.txt", CreationCollisionOption.ReplaceExisting);
            // TODO: serialize data here
            await file.WriteAllTextAsync("");
        }
    }
}
