using System.Collections.ObjectModel;
using MobileKidsIdApp.Models;
using Xamarin.Forms;

namespace MobileKidsIdApp.ViewModels
{
    public class CareProvidersViewModel : CurrentChildViewModel
    {
        public ObservableCollection<CareProvider> CareProviders { get; private set; } = new ObservableCollection<CareProvider>();

        public Command AddProviderCommand { get; private set; }

        public CareProvidersViewModel()
        {
            CurrentChild.ProfessionalCareProviders.ForEach(_ => CareProviders.Add(_));

            AddProviderCommand = new Command(AddProvider);
        }

        private void AddProvider()
        {
            var provider = new CareProvider();
            CurrentChild.ProfessionalCareProviders.Add(provider);
            CareProviders.Add(provider);
        }
    }
}
