using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobileKidsIdApp.Services;

[assembly: Xamarin.Forms.Dependency(typeof(MobileKidsIdApp.UWP.Services.WebViewContentHelper))]
namespace MobileKidsIdApp.UWP.Services
{
    public class WebViewContentHelper : WebViewContentHelperBase
    {
        public override string GetBaseUrl()
        {
            return "ms-appx-web:///";
        }
    }
}
