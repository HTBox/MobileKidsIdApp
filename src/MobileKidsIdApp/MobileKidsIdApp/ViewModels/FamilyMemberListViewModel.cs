using System.Collections.ObjectModel;
using MobileKidsIdApp.Models;
using MobileKidsIdApp.Services;
using Xamarin.Forms;

namespace MobileKidsIdApp.ViewModels
{
    public class FamilyMemberListViewModel : ViewModelBase
    {
        private readonly FamilyRepository _family;

        public ObservableCollection<FamilyMember> FamilyMembers { get; private set; } = new ObservableCollection<FamilyMember>();

        public Command NewFamilyMemberCommand { get; private set; }

        public FamilyMemberListViewModel(FamilyRepository family)
        {
            _family = family;

            family.CurrentChild.FamilyMembers.ForEach(_ => FamilyMembers.Add(_));

            NewFamilyMemberCommand = new Command(AddFamilyMember);
        }

        private void AddFamilyMember()
        {
            var familyMember = new FamilyMember();
            _family.CurrentChild.FamilyMembers.Add(familyMember);
            FamilyMembers.Add(familyMember);
        }
    }
}
