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
        
        protected override Task<FileReferenceList> DoInitAsync()
        {
            //Alright, so this is very ugly. Why not use async/await?  Well calling base.DoInitAsync is
            //throwing a NotImplementedException for some reason so anything that comes after awaiting
            //on that never runs. By not using async/await the error still happens but the ContinueWith still runs.
            var baseInitTask = base.DoInitAsync();
            return baseInitTask.ContinueWith(tsk => {
                if (tsk.Exception!= null)
                    System.Diagnostics.Debug.WriteLine("Error from DoInitAsync task: " + tsk.Exception.Message);
                var photoViewModels = Model.Select(f => new PhotoViewModel(f)).ToList();
                foreach (var f in photoViewModels)
                    PhotoViewModels.Add(f);
                return Task.WhenAll(photoViewModels.Select(f => f.InitializeAsync()).ToArray());
            }, TaskScheduler.FromCurrentSynchronizationContext()).Unwrap()
            .ContinueWith(tsk => baseInitTask.Result, TaskScheduler.FromCurrentSynchronizationContext());
        }

        private readonly ICommand _choosePhotoCommand;
        public ICommand ChoosePhotoCommand { get { return _choosePhotoCommand; } }
        
        public ObservableCollection<PhotoViewModel> PhotoViewModels { get; private set; }

        private async void ChoosePhoto()
        {
            BeginAddNew();
            var itm = Model.Last();
            var rootFolder = FileSystem.Current.LocalStorage;
            var path = await DependencyService.Get<IPhotoPicker>().GetCopiedFilePath(rootFolder.Path, itm.Id);
            if (path == null)
            {
                Model.Remove(itm);
                return;
            }
            itm.FileName = path;
            var newFileReference = Model.Last();
            var photoVM = new PhotoViewModel(newFileReference);
            await photoVM.InitializeAsync();
            PhotoViewModels.Add(photoVM);
        }

        private readonly ICommand _deletePhotoCommand;
        public ICommand DeletePhotoCommand { get { return _deletePhotoCommand; } }
    }

}