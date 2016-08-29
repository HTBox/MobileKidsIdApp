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

        protected ContactInfo SelectedContactInfo { get; set; }

        public async Task<ContactInfo> GetSelectedContactInfo()
        {
           
            var tcs = new TaskCompletionSource<ContactInfo>();

            var picker = new CNContactPickerViewController();

            // Select property to pick
            picker.DisplayedPropertyKeys = new NSString[] { CNContactKey.GivenName, CNContactKey.FamilyName };

            // Respond to selection
            var pickerDelegate = new ContactPickerDelegate();
            picker.Delegate = pickerDelegate;

            pickerDelegate.ContactSelected += (contact) => {
                SelectedContactInfo = new ContactInfo { Id = contact.Identifier, DisplayName = string.Format("{0} {1}", contact.GivenName, contact.FamilyName) };
            };

            UIWindow window = UIApplication.SharedApplication.KeyWindow;
            UIViewController viewController = window.RootViewController;
            if (viewController == null)
            {
                while (viewController.PresentedViewController != null)
                    viewController = viewController.PresentedViewController;

            }

            viewController.PresentViewController(picker, true, null);


            return SelectedContactInfo;
            // Display picker

   
            
        }


    }


}
