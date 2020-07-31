using MobileKidsIdApp.Models;
using MobileKidsIdApp.Services;

namespace MobileKidsIdApp.ViewModels
{
    public abstract class CurrentChildViewModel : ViewModelBase
    {
        protected FamilyRepository Family => FamilyRepository.Instance;
        protected Child CurrentChild => Family.CurrentChild;
    }
}
