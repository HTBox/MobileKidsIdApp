using MobileKidsIdApp.Services;
using System;
using System.Threading.Tasks;

[assembly: Xamarin.Forms.Dependency(typeof(MobileKidsIdApp.UWP.Services.PhotoPicker))]

namespace MobileKidsIdApp.UWP.Services
{
    public class PhotoPicker : IPhotoPicker
    {
        public async Task<string> GetCopiedFilePath(string copyToDirectory, string fileNameWithoutExtension)
        {
            var picker = new Windows.Storage.Pickers.FileOpenPicker();
            picker.ViewMode = Windows.Storage.Pickers.PickerViewMode.Thumbnail;
            picker.SuggestedStartLocation =
                Windows.Storage.Pickers.PickerLocationId.PicturesLibrary;
            picker.FileTypeFilter.Add(".jpg");
            picker.FileTypeFilter.Add(".jpeg");
            picker.FileTypeFilter.Add(".png");

            Windows.Storage.StorageFile file = await picker.PickSingleFileAsync();
            if (file == null)
                return null;

            //We only have temporary access to the file we get from the file picker, so need to copy it to
            //our new location inside this method instead of doing it later in the shared code.
            var copyToFolder = await Windows.Storage.StorageFolder.GetFolderFromPathAsync(copyToDirectory);
            string fullFileName = fileNameWithoutExtension + System.IO.Path.GetExtension(file.Path);
            var copiedFile = await file.CopyAsync(copyToFolder, fullFileName, Windows.Storage.NameCollisionOption.ReplaceExisting);
            var listToken = Windows.Storage.AccessCache.StorageApplicationPermissions.FutureAccessList.Add(copiedFile);
            return fullFileName;
        }
    }
}
