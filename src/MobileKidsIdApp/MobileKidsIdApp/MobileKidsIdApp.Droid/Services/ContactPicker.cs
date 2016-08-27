using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MobileKidsIdApp.Services;
using MobileKidsIdApp.ViewModels;
using Plugin.Contacts.Abstractions;
using Plugin.Contacts;
using Android.Provider;

[assembly: Xamarin.Forms.Dependency(typeof(MobileKidsIdApp.Droid.Services.ContactPicker))]
namespace MobileKidsIdApp.Droid.Services
{     
    public class ContactPicker : Java.Lang.Object, IContactPicker
    {
        public Task<ContactInfo> GetSelectedContactInfo()
        {
            var tcs = new TaskCompletionSource<ContactInfo>();
            Intent pickContactIntent =
                new Intent(Intent.ActionPick, Android.Net.Uri.Parse("content://contacts"));
            pickContactIntent.SetType(Android.Provider.ContactsContract.CommonDataKinds.Phone.ContentType); // Show user only contacts w/ phone numbers

            var handler = new EventHandler<ActivityResultEventArgs>((sender, e) => OnActivityResult(tcs, e));
            MainActivity.Instance.ActivityResult += handler;
            tcs.Task.ContinueWith(t => MainActivity.Instance.ActivityResult -= handler);
            try
            {
                MainActivity.Instance.StartActivityForResult(pickContactIntent, PICK_CONTACT_REQUEST);
            }
            catch (Exception ex)
            {
                tcs.SetException(ex);
            }
            return tcs.Task;
        }
        
        static int PICK_CONTACT_REQUEST = 42; // The request code
        
        protected void OnActivityResult(TaskCompletionSource<ContactInfo> tcs, ActivityResultEventArgs e) //int requestCode, Android.App.Result resultCode, Intent data)
        {
            // Check which request it is that we're responding to
            if (e.requestCode == PICK_CONTACT_REQUEST)
            {
                // Make sure the request was successful
                if (e.resultCode == Android.App.Result.Ok)
                {
                    //var uri = ContactsContract.Contacts.ContentUri;
                    string[] projection = {
                       ContactsContract.Contacts.InterfaceConsts.Id,
                       ContactsContract.Contacts.InterfaceConsts.DisplayName,
                       ContactsContract.Contacts.InterfaceConsts.PhotoId,
                    };

                    var loader = new CursorLoader(MainActivity.Instance, e.data.Data, projection, null, null, null);
                    var cursor = (Android.Database.ICursor)loader.LoadInBackground();

                    var contactList = new List<ContactInfo>();
                    if (cursor.MoveToFirst())
                    {
                        do
                        {
                            var displayName = cursor.GetString(cursor.GetColumnIndex(projection[1]));
                            var nameParts = displayName.Split(' ');
                            var lastName = nameParts.Length > 1 ? nameParts[1] : null;
                            contactList.Add(new ContactInfo()
                            {
                                Id = cursor.GetLong(cursor.GetColumnIndex(projection[0])).ToString(),
                                GivenName = nameParts[0],
                                AdditionalName = null,
                                FamilyName = lastName
                            });
                        } while (cursor.MoveToNext());
                    }
                    tcs.SetResult(contactList.FirstOrDefault());
                    return;
                }
            }

            tcs.SetResult(null);
        }
        
    }
}