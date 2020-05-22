using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Threading.Tasks;
using MobileKidsIdApp.Models;
using MobileKidsIdApp.Platform;
using MobileKidsIdApp.Services;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace MobileKidsIdApp.ViewModels
{
    // TODO: Rework to simplify this more.
    public class PhotosViewModel : ViewModelBase // ViewModelBase<Models.FileReferenceList>
    {
        private readonly FamilyRepository _family;
        private readonly IPhotoPicker _photoPicker;

        public ObservableCollection<Photo> Photos { get; private set; } = new ObservableCollection<Photo>();

        public Command AddPhotoCommand { get; private set; }
        public Command<Photo> DeletePhotoCommand { get; private set; }

        public PhotosViewModel(FamilyRepository family, IPhotoPicker photoPicker)
        {
            _family = family;
            _photoPicker = photoPicker;

            AddPhotoCommand = new Command(async () => await AddPhoto());
            DeletePhotoCommand = new Command<Photo>(DeletePhoto);

            family.CurrentChild.Photos.ForEach(_ => Photos.Add(new Photo(_)));
        }

        public async override void OnAppearing()
        {
            var initTasks = new List<Task>();
            Photos.ForEach(_ => initTasks.Add(_.InitializeAsync()));
            await Task.WhenAll(initTasks);
        }

        private async Task AddPhoto()
        {
            var destinationDirectory = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            var fullFileName = await _photoPicker.GetCopiedFilePath(destinationDirectory, Guid.NewGuid().ToString());

            if (fullFileName != null)
            {
                var fileReference = new FileReference();
                fileReference.FileName = fullFileName;
                _family.CurrentChild.Photos.Add(fileReference);

                var photo = new Photo(fileReference);
                await photo.InitializeAsync();
                Photos.Add(photo);
            }
        }

        private void DeletePhoto(Photo photo)
        {
            _family.CurrentChild.Photos.Remove(photo.FileReference);
            Photos.Remove(photo);
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            var fullPath = Path.Combine(documentsPath, photo.FileReference.FileName);
            if (File.Exists(fullPath))
            {
                File.Delete(fullPath);
            }
        }
    }
}