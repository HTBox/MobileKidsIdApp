using Android.Content;
using MobileKidsIdApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Xamarin.Forms.Dependency(typeof(MobileKidsIdApp.iOS.Services.PhotoPicker))]

namespace MobileKidsIdApp.iOS.Services
{
    public class PhotoPicker
    {

        public Task<string> GetCopiedFilePath(string copyToDirectory, string fileNameWithoutExtension)
        {
            //Look here for how this might work: https://developer.xamarin.com/recipes/ios/media/video_and_photos/choose_a_photo_from_the_gallery/
            throw new NotImplementedException("PhotoPicker not implemented for iOS yet.");
        }


    }
    
}
