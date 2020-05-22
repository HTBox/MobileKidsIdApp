using System;
using Android.App;
using Android.Content;

namespace MobileKidsIdApp.Droid
{
    public class ActivityResultEventArgs : EventArgs
    {
        public int requestCode;
        public Result resultCode;
        public Intent data;
    }
}