using Csla.Core;
using MobileKidsIdApp.Models;
using MobileKidsIdApp.Services;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MobileKidsIdApp.ViewModels
{
    public class FriendList : ViewModelBase<Models.FriendList>
    {
        public ICommand NewItemCommand { get; private set; }

        public ObservableCollection<FriendInfo> List { get; private set; }
        public FriendInfo CurrentItem { get; set; }

        public FriendList(Models.FriendList list)
        {
            List = new ObservableCollection<FriendInfo>();
            NewItemCommand = new Command(() => BeginAddNew());
            Model = list;
        }

        protected override async Task<Models.FriendList> DoInitAsync()
        {
            foreach (var item in Model)
            {
                try
                {
                    ContactInfo contact = await DependencyService.Get<IContactPicker>().GetContactInfoForId(item.ContactId);
                    if (contact != null)
                        List.Add(new FriendInfo(contact));
                }
                catch (Exception ex)
                {
                    var x = ex;
                }
            }
            return await base.DoInitAsync();
        }

        protected override void OnModelChanged(Models.FriendList oldValue, Models.FriendList newValue)
        {
            if (oldValue != null)
                oldValue.AddedNew -= Model_AddedNew;
            if (newValue != null)
                newValue.AddedNew += Model_AddedNew;

            base.OnModelChanged(oldValue, newValue);
        }

        private bool _adding = false;
        private async void Model_AddedNew(object sender, AddedNewEventArgs<Friend> e)
        {
            if (!_adding)
            {
                _adding = true;
                PrepareToShowModal();
                ContactInfo contact = await DependencyService.Get<IContactPicker>().GetSelectedContactInfo();
                if (contact == null)
                {
                    Model.Remove(e.NewObject);
                }
                else
                {
                    e.NewObject.ContactId = contact.Id;
                    List.Add(new FriendInfo(contact));
                }
                _adding = false;
            }
        }

        public async void ChangeContact()
        {
            if (CurrentItem == null) return;

            PrepareToShowModal();
            ContactInfo contact = await DependencyService.Get<IContactPicker>().GetSelectedContactInfo();
            if (contact != null && CurrentItem.ContactId != contact.Id)
            {
                var oldItem = Model.Where(m => m.ContactId == CurrentItem.ContactId).FirstOrDefault();
                if (oldItem != null)
                    oldItem.ContactId = contact.Id;
                List[List.IndexOf(CurrentItem)] = new FriendInfo(contact);
            }
        }

        public void DeleteContact()
        {
            if (CurrentItem == null) return;

            var oldItem = Model.Where(m => m.ContactId == CurrentItem.ContactId).FirstOrDefault();
            Model.Remove(oldItem);
            List.RemoveAt(List.IndexOf(CurrentItem));
        }
    }
}