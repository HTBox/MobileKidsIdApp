using System.Collections.Generic;
using System.Threading.Tasks;
using MobileKidsIdApp.Views;
using Xamarin.Forms;

namespace MobileKidsIdApp.ViewModels
{
    public class InstructionIndexViewModel : ViewModelBase
    {
        public Command AbductionsCommand { get; private set; }
        public Command AmberAlertsCommand { get; private set; }
        public Command DisasterPrepCommand { get; private set; }
        public Command DNACommand { get; private set; }
        public Command InternationalCommand { get; private set; }
        public Command MissingCommand { get; private set; }
        public Command RunawaysCommand { get; private set; }
        public Command ChildSafetyCommand { get; private set; }
        public Command HTBoxCommand { get; private set; }
        public Command MCMCommand { get; private set; }

        public InstructionIndexViewModel()
        {
            AbductionsCommand = new Command(async () => await ShowContent("abduction"));
            AmberAlertsCommand = new Command(async () => await ShowContent("amberalert"));
            DisasterPrepCommand = new Command(async () => await ShowContent("disasterprep"));
            DNACommand = new Command(async () => await ShowContent("dna"));
            InternationalCommand = new Command(async () => await ShowContent("international"));
            MissingCommand = new Command(async () => await ShowContent("missing"));
            RunawaysCommand = new Command(async () => await ShowContent("runaway"));
            ChildSafetyCommand = new Command(async () => await ShowContent("safety"));
            HTBoxCommand = new Command(async () => await ShowContent("abouthtbox"));
            MCMCommand = new Command(async () => await ShowContent("aboutmcm"));
        }

        private async Task ShowContent(string contentLabel)
        {
            var p = new Dictionary<string, object>()
            {
                ["contentName"] = contentLabel
            };

            await PushAsync<StaticContentPage, StaticContentViewModel>(p);
        }
    }
}
