using MobileKidsIdApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobileKidsIdApp.ViewModels;

[assembly: Xamarin.Forms.Dependency(typeof(MobileKidsIdApp.UWP.Services.ContactPicker))]
namespace MobileKidsIdApp.UWP.Services
{
    public class ContactPicker : IContactPicker
    {
        public Task<ContactInfo> GetSelectedContactInfo()
        {
            throw new NotImplementedException();
        }
    }
}
