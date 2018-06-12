using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using Foundation;

using MobileKidsIdApp.Services;

[assembly: Xamarin.Forms.Dependency(typeof(MobileKidsIdApp.iOS.Services.WebViewContentHelper_IOS))]
namespace MobileKidsIdApp.iOS.Services
{
    public class WebViewContentHelper_IOS : IWebViewContentHelper
    {
        public string GetBaseUrl()
        {
            return NSBundle.MainBundle.BundlePath;
        }


        public string LoadContentString(string contentResourceName)
        {
            var assembly = IntrospectionExtensions
                .GetTypeInfo(typeof(MobileKidsIdApp.App)).Assembly;
            
            var embeddedResourceName = string.Format("MobileKidsIdApp.Resources.{0}.html", contentResourceName);

            var stream = assembly.GetManifestResourceStream(embeddedResourceName);

            if(stream == null)
            {
                throw new FileNotFoundException();
            }

            string text = "";
            using (var reader = new System.IO.StreamReader(stream))
            {
                text = reader.ReadToEnd();
            }
            return text;
        }
    }
}
