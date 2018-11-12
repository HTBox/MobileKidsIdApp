using Csla.Xaml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Csla.Core;
using MobileKidsIdApp.Models;
using MobileKidsIdApp.Services;

namespace MobileKidsIdApp.ViewModels
{
    public class FriendList : ViewModelBase<Models.FriendList>
    {
        public ICommand NewItemCommand { get; private set; }


        public FriendList(Models.FriendList list)
        {
            NewItemCommand = new Command(() =>
            {
                BeginAddNew();
            });
            Model = list;
        }

        public async Task SaveDataAsync()
        {
            await App.CurrentFamily.SaveFamilyAsync();
            Model = null;
        }

        protected override void OnModelChanged(Models.FriendList oldValue, Models.FriendList newValue)
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

        private async void Model_AddedNew(object sender, AddedNewEventArgs<Friend> e)
        {
            // TODO : Invoke a platform specific contact picker here.
            ContactInfo contact = await DependencyService.Get<IContactPicker>().GetSelectedContactInfo();
            if (contact == null)
            {
                //Do nothing, user must have cancelled.
            }
            else
            {
                // contact
                // TODO : Add a friend view model of some sort for use in display.

                e.NewObject.ContactId = contact.Id;
                OnPropertyChanged("Model");
            }
        }
    }
}
