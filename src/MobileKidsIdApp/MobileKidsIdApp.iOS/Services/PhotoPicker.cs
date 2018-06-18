using MobileKidsIdApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Xamarin.Forms.Dependency(typeof(MobileKidsIdApp.iOS.Services.PhotoPicker))]

namespace MobileKidsIdApp.iOS.Services
{
    public class PhotoPicker : IPhotoPicker
    {
        public async Task<string> GetCopiedFilePath(string copyToDirectory, string fileNameWithoutExtension)
        {
            string targetPath = null;
            var originalPath = await GetPhotoPath();
            if (!string.IsNullOrWhiteSpace(originalPath))
            {
                var extension = System.IO.Path.GetExtension(originalPath);
                targetPath = System.IO.Path.Combine(copyToDirectory, fileNameWithoutExtension) + extension;
                System.IO.File.Copy(originalPath, targetPath);
            }
            return targetPath;
        }

        private async Task<string> GetPhotoPath()
        {
            string result = null;
            //TODO: plugin no longer supported - needs to be updated
            //var picker = CrossMedia.Current;
            //if (picker.IsPickPhotoSupported)
            //{
            //    var photo = await picker.PickPhotoAsync();
            //    if (photo != null)
            //        result = photo.Path;
            //}
            return result;
        }
    }
}
