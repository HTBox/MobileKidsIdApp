using System.Windows.Input;
using Xamarin.Forms;
using Csla.Core;
using MobileKidsIdApp.Models;
using MobileKidsIdApp.Services;
using System.Threading.Tasks;
using System.Linq;
using System;
using System.Collections.ObjectModel;

namespace MobileKidsIdApp.ViewModels
{
    public class FriendList : ViewModelBase<Models.FriendList>
    {
        public ICommand NewItemCommand { get; private set; }
        public ObservableCollection<ContactInfo> Contacts { get; private set; }

        public FriendList(Models.FriendList list)
        {
            NewItemCommand = new Command(() =>
            {
                BeginAddNew();
            });
            Model = list;
            Contacts = new ObservableCollection<ContactInfo>();
        }

        protected override async Task<Models.FriendList> DoInitAsync()
        {
            var picker = DependencyService.Get<IContactPicker>();
            var contacts = await Task.WhenAll(Model.Select(c => picker.GetContactInfoForId(c.ContactId)));
            foreach (var c in contacts)
            {
                Contacts.Add(c);
            }
            return Model;
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
            IContactPicker contactPicker = DependencyService.Get<IContactPicker>();
            PrepareToShowModal();
            ContactInfo contact = await contactPicker.GetSelectedContactInfo();
            if (contact == null)
            {
                //Do nothing, user must have cancelled.
            }
            else
            {
                var contactInfo = await contactPicker.GetContactInfoForId(contact.Id);
                if (contactInfo != null)
                {
                    Contacts.Add(contactInfo);
                }
                else
                {
                    throw new NullReferenceException($"Could not obtain contact details for contact ID {contact.Id}. Should never happen.");
                }

                e.NewObject.ContactId = contact.Id;
                OnPropertyChanged(nameof(Model));
            }
        }
    }
}
