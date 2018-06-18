using MobileKidsIdApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MobileKidsIdApp.ViewModels
{
    public class PhotoViewModel
    {
        public PhotoViewModel(FileReference fileReference)
        {
            FileReference = fileReference;
        }

        public async Task InitializeAsync()
        {
            //Using the built-in FileImageSource would be much less code than manually creating
            //a StreamImageSource. However, the FileImageSource doesn't appear to release the
            //lock on the file that it displays, so attempting to delete the file causes an
            //"Access Denied" error in the UWP app. So here we copy the file into memory and
            //immediately dispose the FileStream.

            //TODO: change to use System.IO.File
            //var file = await FileSystem.Current.GetFileFromPathAsync(FileReference.FileName);
            //byte[] fileBytes;
            //using (var fileStream = await file.OpenAsync(FileAccess.Read))
            //{
            //    fileBytes = new byte[fileStream.Length];
            //    fileStream.Read(fileBytes, 0, (int)(fileStream.Length));
            //}
            //Func<System.Threading.CancellationToken, Task<System.IO.Stream>> getStreamFunc =
            //    ct => Task.FromResult((System.IO.Stream)(new System.IO.MemoryStream(fileBytes)));
            //ImageSource = new StreamImageSource() { Stream = getStreamFunc };
        }

        public FileReference FileReference { get; private set; }

        public ImageSource ImageSource { get; private set; }
    }
}
