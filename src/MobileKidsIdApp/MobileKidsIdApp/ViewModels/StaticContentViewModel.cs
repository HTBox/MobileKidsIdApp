using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using MobileKidsIdApp.Platform;
using Xamarin.Forms;

namespace MobileKidsIdApp.ViewModels
{
    public class StaticContentViewModel : ViewModelBase
    {
        // TODO: Rework to use Label. It supports HTML Content. 
        private readonly IWebViewContentHelper _contentHelper;

        private string _title;
        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        private HtmlWebViewSource _htmlSource = new HtmlWebViewSource();
        public HtmlWebViewSource HtmlSource
        {
            get => _htmlSource;
            set => SetProperty(ref _htmlSource, value);
        }

        public StaticContentViewModel(IWebViewContentHelper contentHelper)
        {
            _contentHelper = contentHelper;
            HtmlSource.BaseUrl = _contentHelper.GetBaseUrl();
        }

        public async override Task Initialize(Dictionary<string, object> navigationsParams = null)
        {
            navigationsParams.TryGetValue("contentName", out object contentName);

            try
            {
                HtmlSource.Html = _contentHelper.LoadContentString((string)contentName);
            }
            catch (FileNotFoundException)
            {
                HtmlSource.Html = "<html><body><div><h1>Topic Not Found</h1><p>The requested topic was not found.</p></div></body></html>";
            }

            await Task.CompletedTask;
        }
    }
}