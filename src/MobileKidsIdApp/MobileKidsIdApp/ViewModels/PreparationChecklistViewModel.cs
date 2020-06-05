using MobileKidsIdApp.Models;
using MobileKidsIdApp.Services;

namespace MobileKidsIdApp.ViewModels
{
    public class PreparationChecklistViewModel : ViewModelBase
    {
        private Child _child;
        public Child Child
        {
            get => _child;
            set => SetProperty(ref _child, value);
        }

        public PreparationChecklistViewModel(FamilyRepository family)
        {
            Child = family.CurrentChild;
        }
    }
}
