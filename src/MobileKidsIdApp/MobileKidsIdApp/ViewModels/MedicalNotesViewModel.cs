using MobileKidsIdApp.Models;
using MobileKidsIdApp.Services;

namespace MobileKidsIdApp.ViewModels
{
    public class MedicalNotesViewModel : ViewModelBase
    {
        private Child _child;
        public Child Child
        {
            get => _child;
            set => SetProperty(ref _child, value);
        }

        public MedicalNotesViewModel(FamilyRepository family)
        {
            Child = family.CurrentChild;
        }
    }
}
