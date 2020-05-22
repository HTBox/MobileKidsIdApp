using System;
using MobileKidsIdApp.Models;
using MobileKidsIdApp.ViewModels;

namespace MobileKidsIdApp.Views
{
    public partial class ChildProfileListPage : ContentPageBase
    {
        protected new ChildProfileListViewModel ViewModel => BindingContext as ChildProfileListViewModel;

        public ChildProfileListPage() => InitializeComponent();

        private async void ShowChild(object sender, EventArgs e)
        {
            // TODO: this will go away with a collection view
            // normally, we would use a behavior called "event to command"

            var child = childList.SelectedItem as Child;
            await ViewModel.ChildTapped(child);
        }
    }
}
