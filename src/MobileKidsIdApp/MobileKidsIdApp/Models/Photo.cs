using System;
using System.IO;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MobileKidsIdApp.Models
{
    public class Photo : NotifyPropertyChanged
    {
        // TODO: Replace with a PhotoRepository
        public Photo(FileReference fileReference)
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

            byte[] fileBytes;
            string fileName = FileReference.FileName;
            // we need to reconstruct the path at runtime because on iOS when rebuilding/redeploying the debug
            // app due to an actual source change, the OS renames the directory, specifically changing the application GUID part of the directory name. 
            // So the photo files are there, but nested inside an applicaton directory with a new name.  
            // Upon starting the new deployment of the rebuilt app, the saved pictures cannot be found and displayed by the app 
            // using the old directory path because the application directory has changed.
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            var fullPath = Path.Combine(documentsPath, fileName);
            using (var fileStream = await Task.Run(() => File.OpenRead(fullPath)))
            {
                fileBytes = new byte[fileStream.Length];
                fileStream.Read(fileBytes, 0, (int)(fileStream.Length));
            }
            Func<System.Threading.CancellationToken, Task<Stream>> getStreamFunc =
                ct => Task.FromResult((Stream)(new MemoryStream(fileBytes)));
            ImageSource = new StreamImageSource() { Stream = getStreamFunc };
        }

        public FileReference FileReference { get; private set; }

        private ImageSource _imageSource;
        public ImageSource ImageSource
        {
            get => _imageSource;
            set => SetProperty(ref _imageSource, value);
        }
    }
}
