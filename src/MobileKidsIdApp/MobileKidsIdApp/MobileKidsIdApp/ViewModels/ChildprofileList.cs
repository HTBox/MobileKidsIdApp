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
    public class ChildProfileList : Csla.Xaml.ViewModelBase<Models.Family>
    {
        public ICommand SaveItemCommand { get; private set; }
        public ICommand NewItemCommand { get; private set; }

        public ChildProfileList()
        {

            SaveItemCommand = new Command(async () => await SaveAsync());
            NewItemCommand = new Command(() => BeginAddNew());
        }

        protected async override Task<Family> DoInitAsync()
        {
            return await Csla.DataPortal.FetchAsync<Models.Family>();
        }

        public async void ShowChild(Child child)
        {
            await App.RootPage.Navigation.PushAsync(
                new Views.ChildProfileItem { BindingContext = await new ChildProfileItem(child).InitAsync() });
        }
    }
}
