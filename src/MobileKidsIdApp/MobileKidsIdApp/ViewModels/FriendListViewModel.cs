using System.Collections.ObjectModel;
using MobileKidsIdApp.Models;
using Xamarin.Forms;

namespace MobileKidsIdApp.ViewModels
{
    public class FriendListViewModel : CurrentChildViewModel
    {
        public ObservableCollection<Person> Friends { get; private set; } = new ObservableCollection<Person>();

        public Command NewFriendCommand { get; private set; }

        public FriendListViewModel()
        {
            CurrentChild.Friends.ForEach(_ => Friends.Add(_));

            NewFriendCommand = new Command(AddFriend);
        }

        private void AddFriend()
        {
            var friend = new Person();
            CurrentChild.Friends.Add(friend);
            Friends.Add(friend);
        }
    }
}