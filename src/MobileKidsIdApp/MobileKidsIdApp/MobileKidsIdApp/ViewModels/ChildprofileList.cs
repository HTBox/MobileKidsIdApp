using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobileKidsIdApp.Models;
using System.Windows.Input;
using Xamarin.Forms;

namespace MobileKidsIdApp.ViewModels
{
    public class ChildProfileList : Csla.Xaml.ViewModelBase<Models.Family>
    {
        public ICommand SaveItemCommand { get; private set; }
        public ICommand NewItemCommand { get; private set; }

        public ChildProfileList()
        {
            SaveItemCommand = new Command(async () => await SaveAsync());
            NewItemCommand = new Command(() => BeginAddNew());
        }

        protected async override Task<Family> DoInitAsync()
        {
            return await Csla.DataPortal.FetchAsync<Models.Family>();
        }

        protected override void OnModelChanged(Family oldValue, Family newValue)
        {
            //TODO: remove this OnPropertyChanged call when updating CSLA -
            // it is a workaround for a bug that's fixed in future versions
            OnPropertyChanged("Model");

            if (oldValue != null)
                oldValue.AddedNew -= Model_AddedNew;
            if (newValue != null)
                newValue.AddedNew += Model_AddedNew;
            base.OnModelChanged(oldValue, newValue);
        }

        private async void Model_AddedNew(object sender, Csla.Core.AddedNewEventArgs<Child> e)
        {
            await ShowChild(e.NewObject, true);
        }

        public async Task ShowChild(Child child, bool? isNew = false)
        {
            var childProfileItemVM = new ChildProfileItem(child);
            await childProfileItemVM.InitAsync();
            await App.RootPage.Navigation.PushAsync(new Views.ChildProfileItem { BindingContext = childProfileItemVM });
            if (isNew == true)
            {
                //Go directly to the basic details page for a new child.
                childProfileItemVM.EditChildDetailsCommand.Execute(null);
            }
        }
    }
}
