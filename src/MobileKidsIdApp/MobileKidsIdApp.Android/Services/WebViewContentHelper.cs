using System;
using System.IO;
using System.Reflection;
using MobileKidsIdApp.Services;

[assembly: Xamarin.Forms.Dependency(typeof(MobileKidsIdApp.Droid.Services.WebViewContentHelper))]
namespace MobileKidsIdApp.Droid.Services
{
    public class WebViewContentHelper : WebViewContentHelperBase
    {
        public override string GetBaseUrl()
        {
            return "file:///android_asset/";
        }
    }
}
