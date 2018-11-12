using System.Threading.Tasks;

namespace MobileKidsIdApp.ViewModels
{
    public interface IViewModel
    {
        Task CloseView(bool withoutSave);
        Task CloseView();
    }

    public class ViewModelBase<T> : Csla.Xaml.ViewModelBase<T>, IViewModel
    {
        public async Task CloseView(bool withoutSave)
        {
            if (withoutSave)
                Model = default(T);
            else
                await CloseView();
        }

        public async Task CloseView()
        {
            // save data
            await App.CurrentFamily.SaveFamilyAsync();
            // release event handlers from model
            Model = default(T);
        }
    }
}
