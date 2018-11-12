using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MobileKidsIdApp.Views
{
    public partial class ChildProfileList : ContentPage
    {
        public ChildProfileList()
        {
            InitializeComponent();
        }

        private async void ShowChild(object sender, EventArgs e)
        {
            var child = (Models.Child)((ListView)sender).SelectedItem;
            await ((ViewModels.ChildProfileList)BindingContext).ShowChild(child);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ((ViewModels.IViewModel)BindingContext).SetActiveView();
        }

        protected override async void OnDisappearing()
        {
            base.OnDisappearing();
            await ((ViewModels.IViewModel)BindingContext).CloseView(true);
        }
    }
}
