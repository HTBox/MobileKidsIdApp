using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using MobileKidsIdApp.Droid.Services;
using MobileKidsIdApp.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(AndroidDownloader))]
namespace MobileKidsIdApp.Droid.Services
{    
    public class AndroidDownloader : IDownloader
    {
        public event EventHandler<DownloadEventArgs> OnFileDownloaded;

        /*Parts of this method will get moved into the service layer and treated as a service as a dependency injected at runtime*/
        /*The result of the file download is visible in System=> Files=> Downloads=>MissingChildProfile.pdf*/
        public void DownloadFile(string url, string folder)
        {
            var pathToNewFolder = Path.Combine(Android.OS.Environment.ExternalStorageDirectory.AbsolutePath, folder);
            if (!System.IO.Directory.Exists(pathToNewFolder))
            {
                System.IO.Directory.CreateDirectory(pathToNewFolder);
            }

            try
            {
                var webClient = new WebClient();
                webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
                var pathToNewFile = Path.Combine(pathToNewFolder, Path.GetFileName("MissingChildProfile.pdf"));
                webClient.DownloadFileAsync(new Uri(url), pathToNewFile);
            }
            catch (Exception)
            {
                if (OnFileDownloaded != null)
                    OnFileDownloaded.Invoke(this, new DownloadEventArgs(false));
            }
        }

        private void Completed(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                if (OnFileDownloaded != null)
                    OnFileDownloaded.Invoke(this, new DownloadEventArgs(false));
            }
            else
            {
                if (OnFileDownloaded != null)
                    OnFileDownloaded.Invoke(this, new DownloadEventArgs(true));
            }
        }
    }
}