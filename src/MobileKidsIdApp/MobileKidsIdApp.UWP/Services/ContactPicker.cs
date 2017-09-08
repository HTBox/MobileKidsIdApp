using MobileKidsIdApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobileKidsIdApp.ViewModels;
using WinContacts = Windows.ApplicationModel.Contacts;

[assembly: Xamarin.Forms.Dependency(typeof(MobileKidsIdApp.UWP.Services.ContactPicker))]
namespace MobileKidsIdApp.UWP.Services
{
    public class ContactPicker : IContactPicker
    {

        public async Task<ContactInfo> GetSelectedContactInfo()
        {

            var contactPicker = new WinContacts.ContactPicker();

            contactPicker.DesiredFieldsWithContactFieldType.Add(WinContacts.ContactFieldType.Email);
            contactPicker.DesiredFieldsWithContactFieldType.Add(WinContacts.ContactFieldType.Address);
            contactPicker.DesiredFieldsWithContactFieldType.Add(WinContacts.ContactFieldType.PhoneNumber);

            var contact = await contactPicker.PickContactAsync();

            if (contact != null)
            {
                return CreateContactInfo(contact);
            }
            else
            {
                return null;
            }
        }

        private ContactInfo CreateContactInfo(WinContacts.Contact contact)
        {
            return new ContactInfo()
            {
                Id = contact.Id,
                FamilyName = contact.LastName,
                AdditionalName = contact.MiddleName,
                GivenName = contact.FirstName
            };
        }

        public async Task<ContactInfo> GetContactInfoForId(string id)
        {
            var store = await WinContacts.ContactManager
                    .RequestStoreAsync(WinContacts.ContactStoreAccessType.AllContactsReadOnly);
            var contact = await store.GetContactAsync(id);
            return CreateContactInfo(contact);
        }

    }
}
