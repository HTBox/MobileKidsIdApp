using System.Collections.ObjectModel;
using System.Threading.Tasks;
using MobileKidsIdApp.Models;
using MobileKidsIdApp.Platform;
using MobileKidsIdApp.Services;
using Xamarin.Forms;

namespace MobileKidsIdApp.ViewModels
{
    public class FriendListViewModel : ViewModelBase
    {
        private readonly FamilyRepository _family;
        private readonly IContactPicker _contactPicker;

        public ObservableCollection<Friend> Friends { get; private set; }

        public Command NewFriendCommand { get; private set; }
        public Command<Friend> ChangeContactCommand { get; private set; }
        public Command<Friend> DeleteContactCommand { get; private set; }

        public FriendListViewModel(FamilyRepository family, IContactPicker contactPicker)
        {
            _family = family;
            _contactPicker = contactPicker;

            family.CurrentChild.Friends.ForEach(_ => Friends.Add(_));

            NewFriendCommand = new Command(async () => await AddFriend());
            ChangeContactCommand = new Command<Friend>(async (_) => await ChangeContact(_));
            DeleteContactCommand = new Command<Friend>(DeleteContact);
        }

        private async Task AddFriend()
        {
            ContactInfo contact = await _contactPicker.GetSelectedContactInfo();

            if (contact != null)
            {
                var friend = new Friend(contact);
                _family.CurrentChild.Friends.Add(friend);
                Friends.Add(friend);
            }
        }

        private async Task ChangeContact(Friend friend)
        {
            ContactInfo contact = await _contactPicker.GetSelectedContactInfo();

            if (contact != null)
            {
                friend.UpdateFromContact(contact);
            }
        }

        private void DeleteContact(Friend friend)
        {
            _family.CurrentChild.Friends.Remove(friend);
            Friends.Remove(friend);
        }
    }
}