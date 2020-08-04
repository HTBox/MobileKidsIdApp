using Android.Content;
using MobileKidsIdApp.Droid.Assets.Renderers;
using MobileKidsIdApp.Views;
using System.Net;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(WebView), typeof(PdfWebViewRenderer))]
namespace MobileKidsIdApp.Droid.Assets.Renderers
{
    public class PdfWebViewRenderer : WebViewRenderer
    {
        public PdfWebViewRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<WebView> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null)
            {
                var customWebView = Element as CustomWebView;
                Control.Settings.AllowUniversalAccessFromFileURLs = true;
                Control.LoadUrl(string.Format("file:///android_asset/pdfjs/web/viewer.html?file={0}", string.Format("file:///{0}", WebUtility.UrlEncode(customWebView.Uri))));
            }
        }
    }
}