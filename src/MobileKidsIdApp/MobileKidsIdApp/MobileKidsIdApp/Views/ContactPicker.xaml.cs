using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace MobileKidsIdApp.Views
{
    public partial class ContactPicker : ContentPage
    {
        public ContactPicker()
        {
            InitializeComponent();
        }

        private async void PickContact(object sender, EventArgs e)
        {
            var vm = (ViewModels.ContactPicker)BindingContext;
            vm.PickContact(((ListView)sender).SelectedItem);
            await App.RootPage.Navigation.PopModalAsync();
        }
    }
}
