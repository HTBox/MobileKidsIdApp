using System;
using System.Threading.Tasks;
using MobileKidsIdApp.Models;
using System.Windows.Input;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace MobileKidsIdApp.ViewModels
{
    public class ChildProfileList : ViewModelBase<Models.Family>
    {
        public ICommand NewItemCommand { get; private set; }
        public ICommand RemoveItemCommand { get; private set; }
        public Command LoadCommand { get; private set; }
        public ObservableCollection<Family> Kids { get; set; }

        public ChildProfileList()
        {
            App.CurrentFamily = this;
            NewItemCommand = new Command(() => BeginAddNew());
            RemoveItemCommand = new Command(async (item) => { DoRemove(item); await SaveFamilyAsync(); });
            LoadCommand = new Command(async () => await ExecuteLoadCommand(), () => !IsBusy);
        }

        private async Task ExecuteLoadCommand()
        {
            if (IsBusy)
            {
                return;
            }

            IsBusy = true;
            try
            {
                await InitAsync();
            }
            catch(Exception e)
            {
                Debug.WriteLine($"Exception in ChildProfileList.ExecuteLoadCommand(): {e}");
            }
            finally
            {
                IsBusy = false;
            }

            LoadCommand.ChangeCanExecute();
        }

        protected override Task<Family> DoInitAsync()
        {
            return Csla.DataPortal.FetchAsync<Models.Family>();
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

        public static Child CurrentChild { get; set; }

        public async Task ShowChild(Child child, bool? isNew = false)
        {
            CurrentChild = child;
            var childProfileItemVM = new ChildProfileItem(child);
            if (isNew.Value)
                childProfileItemVM.FirstAdd = true;
            await ShowPage(typeof(Views.ChildProfileItem), childProfileItemVM);
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

                // reset CurrentChild
                if (CurrentChild != null)
                {
                    foreach (var item in Model)
                    {
                        var itemDetails = item.ChildDetails;
                        var curDetails = CurrentChild.ChildDetails;
                        if (itemDetails.GivenName == curDetails.GivenName &&
                            itemDetails.FamilyName == curDetails.FamilyName &&
                            itemDetails.Birthday == curDetails.Birthday)
                        {
                            CurrentChild = item;
                            break;
                        }
                    }
                }

                IsBusy = false;
                OnSaved();
            }
            catch (Exception ex)
            {
                IsBusy = false;
                Error = ex;
                Console.WriteLine("Error while saving family.");
                Console.WriteLine(ex);
                OnSaved();
            }
        }
    }
}
