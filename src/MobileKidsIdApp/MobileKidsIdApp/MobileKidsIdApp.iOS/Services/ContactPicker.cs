using MobileKidsIdApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MobileKidsIdApp.ViewModels;
using System.Threading.Tasks;

using Plugin.Contacts;
using Plugin.Contacts.Abstractions;

[assembly: Xamarin.Forms.Dependency(typeof(MobileKidsIdApp.iOS.Services.ContactPicker))]
namespace MobileKidsIdApp.iOS.Services
{
    public class ContactPicker :  IContactPicker
    {
        public async Task<ContactInfo> GetSelectedContactInfo()
        {
            throw new NotImplementedException();
        }
    }
}
