using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileKidsIdApp.Services
{
    public interface IContactPicker
    {
        Task<ViewModels.ContactInfo> GetSelectedContactInfo();

        Task<ViewModels.ContactInfo> GetContactInfoForId(string id);
    }
}
