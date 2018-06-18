using Android.Content;
using MobileKidsIdApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Xamarin.Forms.Dependency(typeof(MobileKidsIdApp.Droid.Services.PhotoPicker))]

namespace MobileKidsIdApp.Droid.Services
{
    public class PhotoPicker : Java.Lang.Object, IPhotoPicker
    {

        public Task<string> GetCopiedFilePath(string copyToDirectory, string fileNameWithoutExtension)
        {
            var imageIntent = new Intent();
            imageIntent.SetType("image/*");
            imageIntent.SetAction(Intent.ActionGetContent);
            var tcs = new TaskCompletionSource<string>();
            //TODO: needs updating to work with Xamarin Forms 3.0
            //EventHandler<ActivityResultEventArgs> handler = null;
            //handler = (sender, e) =>
            //{
            //    MainActivity.Instance.ActivityResult -= handler;
            //    if (e.resultCode == Android.App.Result.Ok)
            //    {
            //        var sourceFile = e.data.DataString;
            //        var extension = System.IO.Path.GetExtension(e.data.DataString);
            //        if (e.data.Data == null)
            //        {
            //            tcs.SetResult(null);
            //        }
            //        else
            //        {
            //            var copiedPath = System.IO.Path.Combine(copyToDirectory, fileNameWithoutExtension, extension);
            //            using (var stream = Forms.Context.ContentResolver.OpenInputStream(e.data.Data))
            //            using (var copiedFileStream = new System.IO.FileStream(copiedPath, System.IO.FileMode.OpenOrCreate))
            //            {
            //                stream.CopyTo(copiedFileStream);
            //            }
            //            tcs.SetResult(copiedPath);
            //        }
            //    }
            //    else
            //        tcs.SetResult(null);
            //};
            //MainActivity.Instance.ActivityResult += handler;
            //tcs.Task.ContinueWith(t => MainActivity.Instance.ActivityResult -= handler);
            //const int photoPickerCode = 82372;
            //try
            //{
            //    MainActivity.Instance.StartActivityForResult(Intent.CreateChooser(imageIntent, "Select photo"), photoPickerCode);
            //}
            //catch (Exception ex)
            //{
            //    tcs.SetException(ex);
            //}
            return tcs.Task;
        }


    }
    
}
