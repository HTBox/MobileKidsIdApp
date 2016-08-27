using Csla.Xaml;
using MobileKidsIdApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MobileKidsIdApp.ViewModels
{
    public class BasicDetails : ViewModelBase<Models.ChildDetails>
    {
        public ICommand ChangeContactCommand { get; private set; }

        public BasicDetails(Models.ChildDetails details)
        {
            ChangeContactCommand = new Command(async () =>
            {
                var contact = await DependencyService.Get<IContactPicker>().GetSelectedContactInfo();
                if (contact == null)
                    Model.ContactId = string.Empty;
                else
                    Model.ContactId = contact.Id;
            });

            Model = details;
            Model.PropertyChanged += Model_PropertyChanged;
        }

        public string ContactName { get; private set; }

        private void Model_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "ContactId" && !string.IsNullOrEmpty(Model.ContactId))
            {
                // TODO : Verify this still works if we are selecting the contact via the native facilities.
                var contactList = Plugin.Contacts.CrossContacts.Current;
                contactList.PreferContactAggregation = true;
                var contact = contactList.Contacts.Where(_ => _.Id == Model.ContactId).FirstOrDefault();
                if (contact != null)
                    ContactName = contact.DisplayName;
                OnPropertyChanged("ContactName");
            }
        }
    }
}
