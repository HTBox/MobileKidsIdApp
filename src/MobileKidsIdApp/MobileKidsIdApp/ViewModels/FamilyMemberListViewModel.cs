using System.Collections.ObjectModel;
using MobileKidsIdApp.Models;
using Xamarin.Forms;

namespace MobileKidsIdApp.ViewModels
{
    public class FamilyMemberListViewModel : CurrentChildViewModel
    {
        public ObservableCollection<FamilyMember> FamilyMembers { get; private set; } = new ObservableCollection<FamilyMember>();

        public Command NewFamilyMemberCommand { get; private set; }

        public FamilyMemberListViewModel()
        {
            CurrentChild.FamilyMembers.ForEach(_ => FamilyMembers.Add(_));

            NewFamilyMemberCommand = new Command(AddFamilyMember);
        }

        private void AddFamilyMember()
        {
            var familyMember = new FamilyMember();
            CurrentChild.FamilyMembers.Add(familyMember);
            FamilyMembers.Add(familyMember);
        }
    }
}
