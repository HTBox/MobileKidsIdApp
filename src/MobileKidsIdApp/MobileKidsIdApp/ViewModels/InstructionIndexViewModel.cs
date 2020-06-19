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
            AbductionsCommand = new Command(async () => await ShowContent(Documents.Abduction));
            AmberAlertsCommand = new Command(async () => await ShowContent(Documents.AmberAlert));
            DisasterPrepCommand = new Command(async () => await ShowContent(Documents.DisasterPrep));
            DNACommand = new Command(async () => await ShowContent(Documents.DNA));
            InternationalCommand = new Command(async () => await ShowContent(Documents.International));
            MissingCommand = new Command(async () => await ShowContent(Documents.Missing));
            RunawaysCommand = new Command(async () => await ShowContent(Documents.Runaway));
            ChildSafetyCommand = new Command(async () => await ShowContent(Documents.Safety));
            HTBoxCommand = new Command(async () => await ShowContent(Documents.AboutHTBox));
            MCMCommand = new Command(async () => await ShowContent(Documents.AboutMCM));
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
