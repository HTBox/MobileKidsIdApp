using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace MobileKidsIdApp.Droid
{
    public class ActivityResultEventArgs : EventArgs
    {
        public int requestCode;
        public Result resultCode;
        public Intent data;
    }
}