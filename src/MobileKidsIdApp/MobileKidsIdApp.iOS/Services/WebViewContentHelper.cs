using System;
using System.IO;
using System.Reflection;

using Foundation;

using MobileKidsIdApp.Services;

[assembly: Xamarin.Forms.Dependency(typeof(MobileKidsIdApp.iOS.Services.WebViewContentHelper))]
namespace MobileKidsIdApp.iOS.Services
{
    public class WebViewContentHelper : WebViewContentHelperBase
    {
        public override string GetBaseUrl()
        {
            return NSBundle.MainBundle.BundlePath;
        }
    }
}
