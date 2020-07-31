using MobileKidsIdApp.Models;

namespace MobileKidsIdApp.ViewModels
{
    public class PreparationChecklistViewModel : CurrentChildViewModel
    {
        private Child _child;
        public Child Child
        {
            get => _child;
            set => SetProperty(ref _child, value);
        }

        public PreparationChecklistViewModel()
            => Child = CurrentChild;
    }
}
