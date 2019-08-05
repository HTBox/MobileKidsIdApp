using MobileKidsIdApp.Services;
using System;

using Xamarin.Forms;

namespace MobileKidsIdApp.Views
{
    public partial class Documents : ContentPage
    {
        IDownloader downloader = DependencyService.Get<IDownloader>();
        public Documents()
        {
            InitializeComponent();
            downloader.OnFileDownloaded += OnFileDownloaded;
        }
        private void OnFileDownloaded(object sender, DownloadEventArgs e)
        {
            if (e.FileSaved)
            {
                DisplayAlert("Downloader", "File Saved Successfully", "Close");
            }
            else
            {
                DisplayAlert("Downloader", "Error while saving the file", "Close");
            }
        }

        private void DownloadClicked(object sender, EventArgs e)
        {
            //This is hard coded for IIS and will be replaced with a service mock and proper dependency injection 
            downloader.DownloadFile($"http://192.168.192.49/api/JsonToPdf/GetMissingChildProfilePdf?missingChildJson=", "Downloads");
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ((ViewModels.IViewModel)BindingContext).SetActiveView();
        }

        protected override async void OnDisappearing()
        {
            base.OnDisappearing();
            await ((ViewModels.IViewModel)BindingContext).CloseView();
        }
    }
}
