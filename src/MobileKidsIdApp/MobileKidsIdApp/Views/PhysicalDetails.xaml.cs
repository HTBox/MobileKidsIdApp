using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace MobileKidsIdApp.Views
{
    public partial class PhysicalDetails : ContentPage
    {
        public PhysicalDetails()
        {
            InitializeComponent();
        }

        protected override async void OnDisappearing()
        {
            base.OnDisappearing();
            await ((ViewModels.PhysicalDetails)BindingContext).SaveDataAsync();
        }
    }
}
