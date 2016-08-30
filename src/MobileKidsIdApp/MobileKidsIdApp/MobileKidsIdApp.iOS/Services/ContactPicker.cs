using MobileKidsIdApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MobileKidsIdApp.ViewModels;
using System.Threading.Tasks;
using ContactsUI;
using Contacts;
using Foundation;
using UIKit;
using System.Threading;

[assembly: Xamarin.Forms.Dependency(typeof(MobileKidsIdApp.iOS.Services.ContactPicker))]
namespace MobileKidsIdApp.iOS.Services
{
    /// <summary>
    /// Implements IContactPicker service for iOS using MonoTouch framework support.
    /// </summary>
    /// <remarks>
    /// See https://developer.xamarin.com/recipes/ios/shared_resources/contacts/choose_a_contact/
    /// </remarks>
    public class ContactPicker :  IContactPicker
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
                tcs.SetResult(new ContactInfo { Id = contact.Identifier, FamilyName = contact.FamilyName, AdditionalName = contact.MiddleName, GivenName = contact.GivenName });
            };

            // Display as modal dialog on main view.
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
            // Raise the contact selected event
            RaiseContactSelected(contact);
        }


        #region Events
        public delegate void SelectionCanceledDelegate();
        public event SelectionCanceledDelegate SelectionCanceled;

        internal void RaiseSelectionCanceled()
        {
            if (this.SelectionCanceled != null) this.SelectionCanceled();
        }

        public delegate void ContactSelectedDelegate(CNContact contact);
        public event ContactSelectedDelegate ContactSelected;

        internal void RaiseContactSelected(CNContact contact)
        {
            if (this.ContactSelected != null) this.ContactSelected(contact);
        }

        public delegate void ContactPropertySelectedDelegate(CNContactProperty property);
        public event ContactPropertySelectedDelegate ContactPropertySelected;

        internal void RaiseContactPropertySelected(CNContactProperty property)
        {
            if (this.ContactPropertySelected != null) this.ContactPropertySelected(property);
        }
        #endregion
    }

}
