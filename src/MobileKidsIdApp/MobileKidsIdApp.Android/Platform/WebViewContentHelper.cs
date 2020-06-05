using MobileKidsIdApp.Platform;

namespace MobileKidsIdApp.Droid.Platform
{
    public class WebViewContentHelper : WebViewContentHelperBase
    {
        public override string GetBaseUrl()
        {
            return "file:///android_asset/";
        }
    }
}
