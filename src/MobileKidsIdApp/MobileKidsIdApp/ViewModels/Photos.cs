using Csla.Xaml;
using MobileKidsIdApp.Models;
using MobileKidsIdApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using PCLStorage;
using System.Globalization;

namespace MobileKidsIdApp.ViewModels
{
    public class Photos : ViewModelBase<Models.FileReferenceList>
    {

        public Photos(FileReferenceList fileReferenceList)
        {
            Model = fileReferenceList;
            _choosePhotoCommand = new Command(ChoosePhoto);
            _deletePhotoCommand = new Command(async obj =>
            {
                var photoVM = (PhotoViewModel)obj;
                PhotoViewModels.Remove(photoVM);
                var fileRef = photoVM.FileReference;
                Model.Remove(fileRef);
                var file = await FileSystem.Current.GetFileFromPathAsync(fileRef.FileName);
                await file.DeleteAsync();
            });
            PhotoViewModels = new ObservableCollection<PhotoViewModel>();
        }

        public async Task SaveDataAsync()
        {
            await App.CurrentFamily.SaveFamilyAsync();
        }

        protected override async Task<FileReferenceList> DoInitAsync()
        {
            var photoViewModels = Model.Select(_ => new PhotoViewModel(_)).ToList();
            var initTasks = new List<Task>();
            foreach (var viewModel in photoViewModels)
            {
                PhotoViewModels.Add(viewModel);
                initTasks.Add(viewModel.InitializeAsync());
            }
            await Task.WhenAll(initTasks);
            return Model;
        }

        private readonly ICommand _choosePhotoCommand;
        public ICommand ChoosePhotoCommand { get { return _choosePhotoCommand; } }
        
        public ObservableCollection<PhotoViewModel> PhotoViewModels { get; private set; }

        private void ChoosePhoto()
        {
            Model.AddedNew += (async (o, e) => 
            {
                var newItem = e.NewObject;
                var rootFolder = FileSystem.Current.LocalStorage;
                var fileName = await GenerateUniqueFileNameFor(FileSystem.Current.LocalStorage);

                var path = await DependencyService.Get<IPhotoPicker>().GetCopiedFilePath(rootFolder.Path, fileName);
                if (path == null)
                {
                    Model.Remove(newItem);
                    return;
                }
                newItem.FileName = path;
                var photoVM = new PhotoViewModel(newItem);
                await photoVM.InitializeAsync();
                PhotoViewModels.Add(photoVM);
            });
            BeginAddNew();
        }

        private readonly ICommand _deletePhotoCommand;
        public ICommand DeletePhotoCommand { get { return _deletePhotoCommand; } }

        private static Random _rnd = new Random();
        private static async Task<string> GenerateUniqueFileNameFor(IFolder folder)
        {
            string result;
            var files = await folder.GetFilesAsync();
            do
            {
                result = string.Empty;
                for (int i = 0; i < 6; i++)
                    result += Convert.ToChar(_rnd.Next(97, 122));
            } while (files.Count(_ => _.Name == result) > 0);
            return result;
        }
    }

}