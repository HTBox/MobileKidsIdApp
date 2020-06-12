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

        private Child _selectedChild;
        public Child SelectedChild
        {
            get => _selectedChild;
            set
            {
                SetProperty(ref _selectedChild, value);
                if (value != null)
                {
                    Device.InvokeOnMainThreadAsync(async () => await ChildTapped(_selectedChild));
                }
            }
        }

        public ObservableCollection<Child> Kids { get; private set; } = new ObservableCollection<Child>();

        public Command AddChildCommand { get; private set; }
        public Command<Child> RemoveChildCommand { get; private set; }

        public ChildProfileListViewModel(FamilyRepository family)
        {
            _family = family;

            AddChildCommand = new Command(async () => await AddChild());
            RemoveChildCommand = new Command<Child>(RemoveChild);
        }

        public override void OnAppearing()
        {
            _family.ClearCurrentChild();
            Refresh();
        }

        private void Refresh(bool force = false)
        {
            if (Kids.Count == 0 || force)
            {
                List<Child> children = _family.Children;
                Kids.Clear();
                children.ForEach((_) => Kids.Add(_));
            }
        }

        private async Task AddChild()
        {
            Child child = _family.NewChild();
            _family.SetCurrentChild(child);
            Kids.Add(child);

            Page basicDetailsPage = await PushAsync<BasicDetailsPage, BasicDetailsViewModel>();
            await InsertPageBefore<ChildProfilePage, ChildProfileViewModel>(basicDetailsPage);
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
            SelectedChild = null;
        }
    }
}
