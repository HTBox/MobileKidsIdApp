using System;
using System.Linq;
using System.Threading.Tasks;
using Contacts;
using ContactsUI;
using Foundation;
using MobileKidsIdApp.Models;
using MobileKidsIdApp.Platform;
using UIKit;

namespace MobileKidsIdApp.iOS.Platform
{
    /// <summary>
    /// Implements IContactPicker service for iOS using MonoTouch framework support.
    /// </summary>
    /// <remarks>
    /// See https://developer.xamarin.com/recipes/ios/shared_resources/contacts/choose_a_contact/
    /// </remarks>
    public class ContactPicker : IContactPicker
    {
        public Task<ContactInfo> GetSelectedContactInfo()
        {
            var picker = new CNContactPickerViewController()
            {
                DisplayedPropertyKeys = new NSString[] { CNContactKey.GivenName, CNContactKey.FamilyName }
            };
            
            // Set up Contact Picker Delegate, TaskCompletionSource wrapper.
            var tcs = new TaskCompletionSource<ContactInfo>();
            var pickerDelegate = new ContactPickerDelegate();
            picker.Delegate = pickerDelegate;

            pickerDelegate.ContactSelected += (contact) =>
            {
                tcs.TrySetResult(new ContactInfo { Id = contact.Identifier, FamilyName = contact.FamilyName, AdditionalName = contact.MiddleName, GivenName = contact.GivenName });
            };

            pickerDelegate.SelectionCanceled += () =>
            {
                tcs.TrySetResult(null);
            };

            // Display as modal dialog on current ViewController
            UIWindow window = UIApplication.SharedApplication.KeyWindow;
            UIViewController viewController = window.RootViewController;
            if (viewController == null)
            {
                while (viewController.PresentedViewController != null)
                    viewController = viewController.PresentedViewController;
            }

            viewController.PresentViewController(picker, true, null);

            return tcs.Task;
            
        }

        public Task<ContactInfo> GetContactInfoForId(string id)
        {
            var predicate = CNContact.GetPredicateForContacts(new string[] { id });
            var fetchKeys = new NSString[] { CNContactKey.GivenName, CNContactKey.FamilyName, CNContactKey.MiddleName };

            var store = new CNContactStore();
            var contacts = store.GetUnifiedContacts(predicate, fetchKeys, out NSError error);
            ContactInfo foundContact = null;
            if (contacts.Any())
            {
                var contact = contacts[0];
                foundContact = new ContactInfo
                {
                    Id = id,
                    FamilyName = contact.FamilyName,
                    AdditionalName = contact.MiddleName,
                    GivenName = contact.GivenName
                };
            }
            return Task.FromResult(foundContact);
        }
    }

    internal class ContactPickerDelegate : CNContactPickerDelegate
    {
        #region Constructors
        public ContactPickerDelegate() { }

        public ContactPickerDelegate(IntPtr handle) : base(handle)
        {
        }

        protected ContactPickerDelegate(NSObjectFlag t) : base(t)
        {
        }
        #endregion

        public override void DidSelectContact(CNContactPickerViewController picker, CNContact contact)
        {
            RaiseContactSelected(contact);
        }

        public override void ContactPickerDidCancel(CNContactPickerViewController picker)
        {
            RaiseSelectionCanceled();
        }

        #region Events
        public delegate void SelectionCanceledDelegate();
        public event SelectionCanceledDelegate SelectionCanceled;

        internal void RaiseSelectionCanceled()
        {
            this.SelectionCanceled?.Invoke();
        }

        public delegate void ContactSelectedDelegate(CNContact contact);
        public event ContactSelectedDelegate ContactSelected;

        internal void RaiseContactSelected(CNContact contact)
        {
            this.ContactSelected?.Invoke(contact);
        }

        #endregion
    }

}
