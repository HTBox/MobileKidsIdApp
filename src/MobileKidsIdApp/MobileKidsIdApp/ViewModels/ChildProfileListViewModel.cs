using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using MobileKidsIdApp.Models;
using MobileKidsIdApp.Services;
using MobileKidsIdApp.Views;
using Xamarin.Forms;

namespace MobileKidsIdApp.ViewModels
{
    public class ChildProfileListViewModel : ViewModelBase
    {
        private readonly FamilyRepository _family;

        private bool _isBusy;
        public bool IsBusy
        {
            get => _isBusy;
            set => SetProperty(ref _isBusy, value);
        }

        public ObservableCollection<Child> Kids { get; private set; } = new ObservableCollection<Child>();

        public Command AddChildCommand { get; private set; }
        public Command<Child> RemoveChildCommand { get; private set; }
        public Command RefreshCommand { get; private set; }

        public ChildProfileListViewModel(FamilyRepository family)
        {
            _family = family;

            AddChildCommand = new Command(async () => await AddChild());
            RemoveChildCommand = new Command<Child>(RemoveChild);
            RefreshCommand = new Command(Refresh);
        }

        public override void OnAppearing()
        {
            _family.ClearCurrentChild();
            Refresh();
        }

        private void Refresh()
        {
            IsBusy = true;

            List<Child> children = _family.Children;
            Kids.Clear();
            children.ForEach((_) => Kids.Add(_));

            IsBusy = false;
        }

        private async Task AddChild()
        {
            await PushAsync<ChildProfilePage, ChildProfileViewModel>(false);
            await PushAsync<BasicDetailsPage, BasicDetailsViewModel>();
        }

        private void RemoveChild(Child child)
        {
            Kids.Remove(child);
            _family.RemoveChild(child);
        }

        public async Task ChildTapped(Child child)
        {
            _family.SetCurrentChild(child);
            await PushAsync<ChildProfilePage, ChildProfileViewModel>();
        }
    }
}
