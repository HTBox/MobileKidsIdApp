using System;
using System.Threading.Tasks;
using Android.Content;
using MobileKidsIdApp.Platform;

namespace MobileKidsIdApp.Droid.Platform
{
    public class PhotoPicker : Java.Lang.Object, IPhotoPicker
    {
        private MainActivity MainActivity => Xamarin.Essentials.Platform.CurrentActivity as MainActivity;

        private readonly int PhotoPickerRequestCode = 32767;

        public Task<string> GetCopiedFilePath(string copyToDirectory, string fileNameWithoutExtension)
        {
            var imageIntent = new Intent();
            imageIntent.SetType("image/*");
            imageIntent.SetAction(Intent.ActionGetContent);

            var tcs = new TaskCompletionSource<string>();
            EventHandler<ActivityResultEventArgs> handler = (sender, e) => OnActivityResult(copyToDirectory, fileNameWithoutExtension, e, tcs);
            
            MainActivity.ActivityResult += handler;
            tcs.Task.ContinueWith(t => MainActivity.ActivityResult -= handler);
            
            try
            {
                MainActivity.StartActivityForResult(Intent.CreateChooser(imageIntent, "Select Photo"), PhotoPickerRequestCode);
            }
            catch (Exception ex)
            {
                tcs.SetException(ex);
            }
            return tcs.Task;
        }

        protected void OnActivityResult(string copyToDirectory, string fileNameWithoutExtension, ActivityResultEventArgs e, TaskCompletionSource<string> tcs)
        {
            if (e.requestCode == PhotoPickerRequestCode)
            {
                if (e.resultCode == Android.App.Result.Ok)
                {
                    var sourceFile = e.data.DataString;
                    var extension = System.IO.Path.GetExtension(e.data.DataString);
                    if (e.data.Data == null)
                    {
                        tcs.SetResult(null);
                    }
                    else
                    {
                        var fullFileName = fileNameWithoutExtension + extension;
                        var copiedPath = System.IO.Path.Combine(copyToDirectory, fullFileName);
                        using (var stream = MainActivity.ContentResolver.OpenInputStream(e.data.Data))
                        {
                            using (var copiedFileStream = new System.IO.FileStream(copiedPath, System.IO.FileMode.OpenOrCreate))
                            {
                                stream.CopyTo(copiedFileStream);
                            }
                        }
                        tcs.SetResult(fullFileName); // we'll reconstruct the path at runtime
                    }
                    return;
                }
            }

            tcs.SetResult(null);
        }
    }
}
