using System.Threading.Tasks;
using MobileKidsIdApp.Models;

namespace MobileKidsIdApp.Platform
{
    // TODO: Replace with Essentials? 
    public interface IContactPicker
    {
        Task<ContactInfo> GetSelectedContactInfo();

        Task<ContactInfo> GetContactInfoForId(string id);
    }
}
