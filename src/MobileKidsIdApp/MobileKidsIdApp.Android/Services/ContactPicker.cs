using System.Threading.Tasks;
using Android.App;
using MobileKidsIdApp.Services;
using MobileKidsIdApp.ViewModels;
using Android.Provider;
using Android.Content;
using System;
using System.Collections.Generic;
using System.Linq;

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

        protected void OnActivityResult(TaskCompletionSource<ContactInfo> tcs, ActivityResultEventArgs e)
         {
            // Check which request it is that we're responding to
            if (e.requestCode == PICK_CONTACT_REQUEST)
            {
                // Make sure the request was successful
                if (e.resultCode == Android.App.Result.Ok)
                {
                    var loader = new CursorLoader(MainActivity.Instance, e.data.Data, projection, null, null, null);
                    var cursor = (Android.Database.ICursor)loader.LoadInBackground();

                    var contactList = new List<ContactInfo>();
                    if (cursor.MoveToFirst())
                    {
                        do
                        {
                            contactList.Add(GetContactInfoFromCursor(cursor));
                        } while (cursor.MoveToNext());
                    }
                    tcs.SetResult(contactList.FirstOrDefault());
                    return;
                }
            }

            tcs.SetResult(null);
         }

        private ContactInfo GetContactInfoFromCursor(Android.Database.ICursor cursor)
        {
            var displayName = cursor.GetString(cursor.GetColumnIndex(projection[1]));
            var nameParts = displayName.Split(' ');
            var lastName = nameParts.Length > 1 ? nameParts[1] : null;
            return new ContactInfo()
            {
                Id = cursor.GetString(cursor.GetColumnIndex(ContactsContract.ContactsColumns.LookupKey)),
                GivenName = nameParts[0],
                AdditionalName = null,
                FamilyName = lastName
            };
        }

        private static readonly string[] projection = {
            ContactsContract.Contacts.InterfaceConsts.Id,
            ContactsContract.Contacts.InterfaceConsts.DisplayName,
            ContactsContract.Contacts.InterfaceConsts.PhotoId,
            ContactsContract.Contacts.InterfaceConsts.LookupKey,
        };

        public Task<ContactInfo> GetContactInfoForId(string id)
        {
            var uri = Android.Net.Uri.WithAppendedPath(ContactsContract.Contacts.ContentLookupUri, id);

            ContactInfo contact = null;
            var cursor = Application.Context
                .ContentResolver.Query(uri, projection, null, null, null);
            if ((cursor != null) && (cursor.Count > 0))
            {
                cursor.MoveToFirst();
                while ((cursor != null) && (cursor.IsAfterLast == false))
                {
                    contact = GetContactInfoFromCursor(cursor);
                    cursor.MoveToNext();
                }
            }
            if (cursor != null)
                cursor.Close();
            
            return Task.FromResult(contact);
        }
    }
}