using System.Collections.ObjectModel;
using MobileKidsIdApp.Models;
using MobileKidsIdApp.Services;
using Xamarin.Forms;

namespace MobileKidsIdApp.ViewModels
{
    public class ProfessionalCareProvidersViewModel : ViewModelBase
    {
        private readonly FamilyRepository _family;

        public ObservableCollection<CareProvider> CareProviders { get; private set; } = new ObservableCollection<CareProvider>();

        public Command AddProviderCommand { get; private set; }

        public ProfessionalCareProvidersViewModel(FamilyRepository family)
        {
            _family = family;

            family.CurrentChild.ProfessionalCareProviders.ForEach(_ => CareProviders.Add(_));

            AddProviderCommand = new Command(AddProvider);
        }

        private void AddProvider()
        {
            var provider = new CareProvider();
            _family.CurrentChild.ProfessionalCareProviders.Add(provider);
            CareProviders.Add(provider);
        }
    }
}
