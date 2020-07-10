using MobileKidsIdApp.Models;

namespace MobileKidsIdApp.ViewModels
{
    public class BasicDetailsViewModel : CurrentChildViewModel
    {
        private Child _child;
        public Child Child
        {
            get => _child;
            set => SetProperty(ref _child, value);
        }

        public BasicDetailsViewModel()
            => Child = CurrentChild;
    }
}
