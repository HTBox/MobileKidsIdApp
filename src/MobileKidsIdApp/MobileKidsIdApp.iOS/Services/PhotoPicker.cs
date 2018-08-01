using Foundation;
using MobileKidsIdApp.Services;
using System;
using System.Threading.Tasks;
using UIKit;

[assembly: Xamarin.Forms.Dependency(typeof(MobileKidsIdApp.iOS.Services.PhotoPicker))]
namespace MobileKidsIdApp.iOS.Services
{
    public class PhotoPicker : IPhotoPicker
    {
        TaskCompletionSource<string> TaskCompletionSource { get; set; }
        UIImagePickerController ImagePicker { get; set; }
        string CopyToDirectory { get; set; }
        string FileNameWithoutExtension { get; set; }

        public Task<string> GetCopiedFilePath(string copyToDirectory, string fileNameWithoutExtension)
        {
            CopyToDirectory = copyToDirectory;
            FileNameWithoutExtension = fileNameWithoutExtension;
            TaskCompletionSource = new TaskCompletionSource<string>();

            // Create and define UIImagePickerController
            ImagePicker = new UIImagePickerController
            {
                SourceType = UIImagePickerControllerSourceType.PhotoLibrary,
                MediaTypes = UIImagePickerController.AvailableMediaTypes(UIImagePickerControllerSourceType.PhotoLibrary)
            };

            // Set event handlers
            ImagePicker.FinishedPickingMedia += OnImagePickerFinishedPickingMedia;
            ImagePicker.Canceled += OnImagePickerCancelled;
            TaskCompletionSource.Task.ContinueWith(t =>
            {
                ImagePicker.FinishedPickingMedia -= OnImagePickerFinishedPickingMedia;
                ImagePicker.Canceled -= OnImagePickerCancelled;
            });

            // Present UIImagePickerController;
            UIWindow window = UIApplication.SharedApplication.KeyWindow;
            var viewController = window.RootViewController;
            viewController.PresentModalViewController(ImagePicker, true);

            return TaskCompletionSource.Task;
        }

        private void OnImagePickerCancelled(object sender, EventArgs args)
        {
            TaskCompletionSource.SetResult(null);
            ImagePicker.DismissModalViewController(true);
        }

        private void OnImagePickerFinishedPickingMedia(object sender, UIImagePickerMediaPickedEventArgs args)
        {
            string targetPath = null;
            UIImage image = args.EditedImage ?? args.OriginalImage;

            if (image != null)
            {
                // Convert UIImage to .NET Stream object
                NSData data = image.AsJPEG(1);
                using (System.IO.Stream stream = data.AsStream())
                {
                    string extension = ".jpg";
                    targetPath = System.IO.Path.Combine(CopyToDirectory, FileNameWithoutExtension + extension);

                    // copy the file to the destination and set the completion of the Task
                    using (var copiedFileStream = new System.IO.FileStream(targetPath, System.IO.FileMode.OpenOrCreate))
                    {
                        stream.CopyTo(copiedFileStream);
                    }
                    TaskCompletionSource.SetResult(targetPath);
                } 
            }
            else
            {
                TaskCompletionSource.SetResult(null);
            }
            ImagePicker.DismissModalViewController(true);
        }
    }
}
