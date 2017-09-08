using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileKidsIdApp.ViewModels
{
    public class ContactPicker : BindableObject
    {
        public ContactInfo Contact { get; private set; }
        internal List<ContactInfo> Contacts { get; private set; }

        public ContactPicker()
        {
            Contacts = new List<ContactInfo>();
        }

        public async Task<ContactPicker> InitAsync()
        {
            if (await Plugin.Contacts.CrossContacts.Current.RequestPermission())
            {
                await Task.Run(() =>
                {
                    var contactList = Plugin.Contacts.CrossContacts.Current;
                    contactList.PreferContactAggregation = true;
                    var contacts = contactList.Contacts;
                    if (contacts != null)
                    {
                        Contacts = contactList.Contacts.
                            Where(_ => !string.IsNullOrWhiteSpace(_.LastName)).
                            Select(_ => new ContactInfo { Id = _.Id, DisplayName = _.DisplayName }).ToList();
                        OnPropertyChanged("Contacts");
                    }
                });
            }
            return this;
        }

        internal void PickContact(object selectedItem)
        {
            var contact = selectedItem as ContactInfo;
            if (contact != null)
                Contact = contact;
        }

        public class ContactInfo
        {
            public string Id { get; set; }
            public string DisplayName { get; set; }
        }
    }
}
