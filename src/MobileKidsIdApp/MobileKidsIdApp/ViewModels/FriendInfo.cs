using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MobileKidsIdApp.ViewModels
{
    public class FriendInfo
    {
        public FriendInfo(ContactInfo contact)
        {
            ContactId = contact.Id;
            FamilyName = contact.FamilyName;
            GivenName = contact.GivenName;
            AdditionalName = contact.AdditionalName;

            Display = $"{GivenName} {FamilyName}";
        }

        public string ContactId { get; }
        public string FamilyName { get; }
        public string GivenName { get; }
        public string AdditionalName { get; }
        public string Display { get; set; }
    }
}
