using System.Threading.Tasks;
using MobileKidsIdApp.Models;
using MobileKidsIdApp.Platform;
using MobileKidsIdApp.Services;
using Xamarin.Forms;

namespace MobileKidsIdApp.ViewModels
{
    public class BasicDetailsViewModel : ViewModelBase
    {
        private readonly IContactPicker _contactPicker;

        private Child _child;
        public Child Child
        {
            get => _child;
            set => SetProperty(ref _child, value);
        }

        private ContactInfo _contact;
        public ContactInfo Contact
        {
            get => _contact;
            set => SetProperty(ref _contact, value);
        }

        public Command ChangeContactCommand { get; private set; }

        public BasicDetailsViewModel(FamilyRepository family, IContactPicker contactPicker)
        {
            _contactPicker = contactPicker;

            Child = family.CurrentChild;

            ChangeContactCommand = new Command(async () => await ChangeContact());
        }

        private async Task ChangeContact()
        {
            ContactInfo contact = await _contactPicker.GetSelectedContactInfo();

            if (contact != null)
            {
                Contact = contact;

                //Only overwrite name fields if they were blank.
                if (string.IsNullOrEmpty(Child.FamilyName))
                {
                    Child.FamilyName = contact.FamilyName;
                }

                if (string.IsNullOrEmpty(Child.NickName))
                {
                    Child.NickName = contact.NickName;
                }

                if (string.IsNullOrEmpty(Child.AdditionalName))
                {
                    Child.AdditionalName = contact.AdditionalName;
                }

                if (string.IsNullOrEmpty(Child.GivenName))
                {
                    Child.GivenName = contact.GivenName;
                }

                if (string.IsNullOrEmpty(Child.ContactNameManual))
                {
                    Child.ContactNameManual = contact.ContactNameManual;
                }

                if (string.IsNullOrEmpty(Child.ContactPhoneManual))
                {
                    Child.ContactPhoneManual = contact.ContactPhoneManual;
                }
            }
        }
    }
}
