using System.Collections.ObjectModel;
using MobileKidsIdApp.Models;
using MobileKidsIdApp.Services;
using Xamarin.Forms;

namespace MobileKidsIdApp.ViewModels
{
    public class DistinguishingFeaturesViewModel : ViewModelBase
    {
        private readonly FamilyRepository _family;

        public ObservableCollection<DistinguishingFeature> Features { get; private set; } = new ObservableCollection<DistinguishingFeature>();

        public Command AddFeatureCommand { get; private set; }

        public DistinguishingFeaturesViewModel(FamilyRepository family)
        {
            _family = family;

            family.CurrentChild.DistinguishingFeatures.ForEach(_ => Features.Add(_));

            AddFeatureCommand = new Command(AddFeature);
        }

        private void AddFeature()
        {
            var feature = new DistinguishingFeature();
            _family.CurrentChild.DistinguishingFeatures.Add(feature);
            Features.Add(feature);
        }
    }
}
