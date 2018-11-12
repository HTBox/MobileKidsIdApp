using System.Windows.Input;
using Xamarin.Forms;

namespace MobileKidsIdApp.ViewModels
{
    public class ChildProfileItem : ViewModelBase<Models.Child>
    {
        public ICommand EditChildDetailsCommand { get; private set; }
        public ICommand EditFeaturesCommand { get; private set; }
        public ICommand EditCareProvidersCommand { get; private set; }
        public ICommand EditDocumentsCommand { get; private set; }
        public ICommand EditFamilyCommand { get; private set; }
        public ICommand EditFriendsCommand { get; private set; }
        public ICommand EditMedicalNotesCommand { get; private set; }
        public ICommand EditPhysicalDetailsCommand { get; private set; }
        public ICommand EditPhotosCommand { get; private set; }
        public ICommand EditChecklistCommand { get; private set; }
        public ICommand ExportChildProdfileCommand { get; private set; }

        public ChildProfileItem(Models.Child child)
        {
            EditChildDetailsCommand = new Command(async () => {
                await ShowPage(typeof(Views.BasicDetails), await new BasicDetails(Model.ChildDetails).InitAsync());
            });
            EditFeaturesCommand = new Command(async () => {
                await ShowPage(typeof(Views.DistinguishingFeatures), await new DistinguishingFeatures(Model.DistinguishingFeatures).InitAsync());
            });
            EditCareProvidersCommand = new Command(async () => {
                await ShowPage(typeof(Views.ProfessionalCareProviders), await new ProfessionalCareProviders(Model.ProfessionalCareProviders).InitAsync());
            });
            EditDocumentsCommand = new Command(async () => {
                await ShowPage(typeof(Views.Documents), await new Documents().InitAsync());
            });
            EditFamilyCommand = new Command(async () => {
                await ShowPage(typeof(Views.FamilyMemberList), await new FamilyMemberList(Model.FamilyMembers).InitAsync());
            });
            EditFriendsCommand = new Command(async () => {
                await ShowPage(typeof(Views.FriendList), await new FriendList(Model.Friends).InitAsync());
            });
            EditMedicalNotesCommand = new Command(async () => {
                await ShowPage(typeof(Views.MedicalNotes), await new MedicalNotes(Model.MedicalNotes).InitAsync());
            });
            EditPhysicalDetailsCommand = new Command(async () => {
                await ShowPage(typeof(Views.PhysicalDetails), await new PhysicalDetails(Model.PhysicalDetails).InitAsync());
            });
            EditPhotosCommand = new Command(async () => {
                await ShowPage(typeof(Views.Photos), await new Photos(Model.Photos).InitAsync());
            });
            EditChecklistCommand = new Command(async () => {
                await ShowPage(typeof(Views.PreparationChecklist), await new PreparationChecklist(Model.Checklist).InitAsync());
            });
            ExportChildProdfileCommand = new Command(async () => {
                await ShowPage(typeof(Views.DocumentRender), await new BasicDetails(Model.ChildDetails).InitAsync());
            });

            Model = child;
        }
    }
}
