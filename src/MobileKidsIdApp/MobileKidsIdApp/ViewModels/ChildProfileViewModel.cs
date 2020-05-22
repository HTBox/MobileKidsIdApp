using MobileKidsIdApp.Views;
using Xamarin.Forms;

namespace MobileKidsIdApp.ViewModels
{
    public class ChildProfileViewModel : ViewModelBase
    {
        public Command EditChildDetailsCommand { get; private set; }
        public Command EditFeaturesCommand { get; private set; }
        public Command EditCareProvidersCommand { get; private set; }
        public Command EditDocumentsCommand { get; private set; }
        public Command EditFamilyCommand { get; private set; }
        public Command EditFriendsCommand { get; private set; }
        public Command EditMedicalNotesCommand { get; private set; }
        public Command EditPhysicalDetailsCommand { get; private set; }
        public Command EditPhotosCommand { get; private set; }
        public Command EditChecklistCommand { get; private set; }
        public Command ExportChildProdfileCommand { get; private set; }

        public ChildProfileViewModel()
        {
            EditChildDetailsCommand = new Command(async () =>
                await PushAsync<BasicDetailsPage, BasicDetailsViewModel>()
            );
            EditFeaturesCommand = new Command(async () =>
                await PushAsync<DistinguishingFeaturesPage, DistinguishingFeaturesViewModel>()
            );
            EditCareProvidersCommand = new Command(async () =>
                await PushAsync<ProfessionalCareProvidersPage, ProfessionalCareProvidersViewModel>()
            );
            EditDocumentsCommand = new Command(async () =>
                await PushAsync<DocumentsPage, DocumentsViewModel>()
            );
            EditFamilyCommand = new Command(async () =>
                await PushAsync<FamilyMemberListPage, FamilyMemberListViewModel>()
            );
            EditFriendsCommand = new Command(async () =>
                await PushAsync<FriendListPage, FriendListViewModel>()
            );
            EditMedicalNotesCommand = new Command(async () =>
                await PushAsync<MedicalNotesPage, MedicalNotesViewModel>()
            );
            EditPhysicalDetailsCommand = new Command(async () =>
                await PushAsync<PhysicalDetailsPage, PhysicalDetailsViewModel>()
            );
            EditPhotosCommand = new Command(async () =>
                await PushAsync<PhotosPage, PhotosViewModel>()
            );
            EditChecklistCommand = new Command(async () =>
                await PushAsync<PreparationChecklistPage, PreparationChecklistViewModel>()
            );
            ExportChildProdfileCommand = new Command(async () =>
                await PushAsync<DocumentRenderPage, DocumentRenderViewModel>()
            );
        }
    }
}
