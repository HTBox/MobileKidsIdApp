using System.IO;
using System.Reflection;

namespace MobileKidsIdApp.Platform
{
    public abstract class WebViewContentHelperBase : IWebViewContentHelper
    {
        /// <summary>
        /// Abstract. Override to return platform-specific BaseUrl string for use in WebView.
        /// </summary>
        /// <returns>The base URL.</returns>
        public abstract string GetBaseUrl();
        /// <summary>
        /// Loads text contents of embedded resource file.
        /// </summary>
        /// <returns>Text content string value.</returns>
        /// <param name="contentResourceName">Content resource name.</param>
        public virtual string LoadContentString(string contentResourceName)
        {
            var assembly = IntrospectionExtensions
                          .GetTypeInfo(typeof(MobileKidsIdApp.App)).Assembly;

            var embeddedResourceName = string.Format("MobileKidsIdApp.Resources.{0}.html",
                                                     contentResourceName);

            var stream = assembly.GetManifestResourceStream(embeddedResourceName);

            if (stream == null)
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
