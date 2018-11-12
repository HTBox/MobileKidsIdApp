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
    public class ChildProfileList : ViewModelBase<Models.Family>
    {
        public ICommand NewItemCommand { get; private set; }
        public ICommand RemoveItemCommand { get; private set; }
        public ChildProfileList()
        {
            App.CurrentFamily = this;
            NewItemCommand = new Command(() => BeginAddNew());
            RemoveItemCommand = new Command(async (item) => { DoRemove(item); await SaveFamilyAsync();  });

        }

        protected async override Task<Family> DoInitAsync()
        {
            return await Csla.DataPortal.FetchAsync<Models.Family>();
        }

        protected override void OnModelChanged(Family oldValue, Family newValue)
        {
            //TODO: remove this OnPropertyChanged call when updating CSLA -
            // it is a workaround for a bug that's fixed in future versions
            // 2-11-2017 : Still necessary.
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
            if (isNew == true)
            {
                //Go directly to the basic details page for a new child.
                childProfileItemVM.EditChildDetailsCommand.Execute(null);
            }
            else
            {
                await ShowPage(typeof(Views.ChildProfileItem), childProfileItemVM);
            }
        }

        public async Task SaveFamilyAsync()
        {
            try
            {
                var savable = Model as Csla.Core.ISavable;

                Error = null;
                IsBusy = true;
                OnSaving(Model);

                var saved = (Family)await savable.SaveAsync();
                var merger = new Csla.Core.GraphMerger();
                merger.MergeBusinessListGraph<Family, Child>(Model, saved);

                IsBusy = false;
                OnSaved();
            }
            catch (Exception ex)
            {
                IsBusy = false;
                Error = ex;
                OnSaved();
            }
        }
    }
}
