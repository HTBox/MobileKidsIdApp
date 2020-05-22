using Foundation;
using MobileKidsIdApp.Platform;

namespace MobileKidsIdApp.iOS.Platform
{
    public class WebViewContentHelper : WebViewContentHelperBase
    {
        public override string GetBaseUrl()
        {
            return NSBundle.MainBundle.BundlePath;
        }
    }
}
