using System.Collections.Generic;
using System.Threading.Tasks;

namespace MobileKidsIdApp.ViewModels
{
    public class StaticContentViewModel : ViewModelBase
    {
        private string _title;
        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        private string _htmlSource;
        public string HtmlSource
        {
            get => _htmlSource;
            set => SetProperty(ref _htmlSource, value);
        }

        public async override Task Initialize(Dictionary<string, object> navigationsParams = null)
        {
            navigationsParams.TryGetValue("contentName", out object contentName);
            HtmlSource = Documents.LoadContentString((string)contentName);
            await Task.CompletedTask;
        }
    }
}