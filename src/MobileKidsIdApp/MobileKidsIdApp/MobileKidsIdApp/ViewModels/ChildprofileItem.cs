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
                    new Views.FamilyMemberList { BindingContext = await new FamilyMemberList(Model.FamilyMembers).InitAsync() }  );
            });
            

            Model = child;
        }
    }
}
