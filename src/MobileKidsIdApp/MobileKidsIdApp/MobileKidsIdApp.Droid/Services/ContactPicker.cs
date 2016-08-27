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

[assembly: Xamarin.Forms.Dependency(typeof(MobileKidsIdApp.Droid.Services.ContactPicker))]
namespace MobileKidsIdApp.Droid.Services
{     
    public class ContactPicker : Java.Lang.Object, IContactPicker
    {
        public async Task<ContactInfo> GetSelectedContactInfo()
        {
            throw new NotImplementedException();
        }
    }
}