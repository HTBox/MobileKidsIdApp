using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using Xamarin.Forms;

namespace MobileKidsIdApp.ViewModels
{
    public class InstructionIndex
    {
        public ICommand AbductionsCommand { get; private set; }
        public ICommand AmberAlertsCommand { get; private set; }
        public ICommand DisasterPrepCommand { get; private set; }
        public ICommand DNACommand { get; private set; }
        public ICommand InternationalCommand { get; private set; }
        public ICommand MissingCommand { get; private set; }
        public ICommand RunawaysCommand { get; private set; }
        public ICommand ChildSafetyCommand { get; private set; }
        public ICommand HTBoxCommand { get; private set; }
        public ICommand MCMCommand { get; private set; }

        public InstructionIndex()
        {
            AbductionsCommand = new Command(() => ShowContent("abduction"));
            AmberAlertsCommand = new Command(() => ShowContent("amberalert"));
            DisasterPrepCommand = new Command(() => ShowContent("disasterprep"));
            DNACommand = new Command(() => ShowContent("dna"));
            InternationalCommand = new Command(() => ShowContent("international"));
            MissingCommand = new Command(() => ShowContent("missing"));
            RunawaysCommand = new Command(() => ShowContent("runaway"));
            ChildSafetyCommand = new Command(() => ShowContent("safety"));
            HTBoxCommand = new Command(() => ShowContent("abouthtbox"));
            MCMCommand = new Command(() => ShowContent("aboutmcm"));
        }

        private void ShowContent(string contentLabel)
        {
            App.RootPage.Navigation.PushAsync(new Views.StaticContent { BindingContext = new StaticContent(contentLabel) });
        }
    }
}
