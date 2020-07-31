using System.Collections.ObjectModel;
using MobileKidsIdApp.Models;
using Xamarin.Forms;

namespace MobileKidsIdApp.ViewModels
{
    public class DistinguishingFeaturesViewModel : CurrentChildViewModel
    {
        public ObservableCollection<DistinguishingFeature> Features { get; private set; } = new ObservableCollection<DistinguishingFeature>();

        public Command AddFeatureCommand { get; private set; }

        public DistinguishingFeaturesViewModel()
        {
            CurrentChild.DistinguishingFeatures.ForEach(_ => Features.Add(_));

            AddFeatureCommand = new Command(AddFeature);
        }

        private void AddFeature()
        {
            var feature = new DistinguishingFeature();
            CurrentChild.DistinguishingFeatures.Add(feature);
            Features.Add(feature);
        }
    }
}
