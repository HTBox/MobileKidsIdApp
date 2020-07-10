using MobileKidsIdApp.Models;
using MobileKidsIdApp.Views;
using Xamarin.Forms;

namespace MobileKidsIdApp.ViewModels
{
    public class ChildProfileViewModel : CurrentChildViewModel
    {
        private Child _child;
        public Child Child
        {
            get => _child;
            set => SetProperty(ref _child, value);
        }

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
            Child = CurrentChild;

            EditChildDetailsCommand = new Command(async () =>
                await PushAsync<BasicDetailsPage, BasicDetailsViewModel>()
            );
            EditFeaturesCommand = new Command(async () =>
                await PushAsync<DistinguishingFeaturesPage, DistinguishingFeaturesViewModel>()
            );
            EditCareProvidersCommand = new Command(async () =>
                await PushAsync<CareProvidersPage, CareProvidersViewModel>()
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

        public override void OnAppearing() => Family.SaveChildren();
    }
}
