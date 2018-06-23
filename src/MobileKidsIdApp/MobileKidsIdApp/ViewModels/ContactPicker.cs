
namespace MobileKidsIdApp.ViewModels
{
    public class ContactPicker : BindableObject
    {
        public ContactInfo Contact { get; private set; }

        public ContactPicker()
        {
            
        }

        internal void PickContact(object selectedItem)
        {
            if (selectedItem is ContactInfo contact)
            {
                Contact = contact;
            }
        }

        public class ContactInfo
        {
            public string Id { get; set; }
            public string DisplayName { get; set; }
        }
    }
}
