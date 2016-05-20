using Csla.Xaml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobileKidsIdApp.Models;
using System.Windows.Input;
using Xamarin.Forms;

namespace MobileKidsIdApp.ViewModels
{
    public class ChildProfileItem : ViewModelBase<Models.Child>
    {
        public ICommand EditChildDetailsCommand { get; private set; }
        public ICommand EditFeaturesCommand { get; private set; }
        public ICommand EditCareProvidersCommand { get; private set; }
        public ICommand EditFamilyCommand { get; private set; }
        public ICommand EditFriendsCommand { get; private set; }
        public ICommand EditMedicalNotesCommand { get; private set; }
        public ICommand EditPhysicalDetailsCommand { get; private set; }
        public ICommand EditChecklistCommand { get; private set; }
        public ChildProfileItem(Models.Child child)
        {
            EditChildDetailsCommand = new Command(async () =>
            {
                await App.RootPage.Navigation.PushAsync(
                    new Views.BasicDetails { BindingContext = await new BasicDetails(Model.ChildDetails).InitAsync() });
            });
            EditFeaturesCommand = new Command(async () =>
            {
                await App.RootPage.Navigation.PushAsync(
                    new Views.DistinguishingFeatures { BindingContext = await new DistinguishingFeatures(Model.DistinguishingFeatures).InitAsync() });
            });
            EditCareProvidersCommand = new Command(async () =>
            {
                await App.RootPage.Navigation.PushAsync(
                    new Views.ProfessionalCareProviders { BindingContext = await new ProfessionalCareProviders(Model.ProfessionalCareProviders).InitAsync() });
            });
            EditFamilyCommand = new Command(async () => 
            {
                await App.RootPage.Navigation.PushAsync(
                    new Views.FamilyMemberList { BindingContext = await new FamilyMemberList(Model.FamilyMembers).InitAsync() });
            });
            EditFriendsCommand = new Command(async () => 
            {
            await App.RootPage.Navigation.PushAsync(
                new Views.FriendList { BindingContext = await new FriendList(Model.Friends).InitAsync() });
            });
            EditMedicalNotesCommand = new Command(async () => {
                await App.RootPage.Navigation.PushAsync(
                    new Views.MedicalNotes { BindingContext = await new MedicalNotes(Model.MedicalNotes).InitAsync() });
            });
            EditPhysicalDetailsCommand = new Command(async () => {
                await App.RootPage.Navigation.PushAsync(
                    new Views.PhysicalDetails { BindingContext = await new PhysicalDetails(Model.PhysicalDetails).InitAsync() });
            });
            EditChecklistCommand = new Command(async () => {
                await App.RootPage.Navigation.PushAsync(
                    new Views.PreparationChecklist { BindingContext = await new PreparationChecklist(Model.Checklist).InitAsync() });
            });

            Model = child;
        }
    }
}
