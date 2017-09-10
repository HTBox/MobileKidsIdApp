using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace MobileKidsIdApp.Views
{
    public partial class DistinguishingFeatures : ContentPage
    {
        public DistinguishingFeatures()
        {
            InitializeComponent();
        }

        protected override async void OnDisappearing()
        {
            base.OnDisappearing();
            await ((ViewModels.DistinguishingFeatures)BindingContext).SaveDataAsync();
        }
    }
}
