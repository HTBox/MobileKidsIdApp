using System.IO;
using System.Reflection;

namespace MobileKidsIdApp
{
    public static class Documents
    {
        public static string Abduction = "abduction";
        public static string AmberAlert = "amberalert";
        public static string DisasterPrep = "disasterprep";
        public static string DNA = "dna";
        public static string International = "international";
        public static string Missing = "missing";
        public static string Runaway = "runaway";
        public static string Safety = "safety";
        public static string AboutHTBox = "abouthtbox";
        public static string AboutMCM = "aboutmcm";

        public static string LoadContentString(string contentResourceName)
        {
            string result = null;

            if (!string.IsNullOrEmpty(contentResourceName))
            {
                Stream stream = IntrospectionExtensions
                    .GetTypeInfo(typeof(Documents))
                    .Assembly
                    .GetManifestResourceStream($"MobileKidsIdApp.Resources.Docs.{contentResourceName}.html");

                if (stream != null)
                {
                    using var reader = new StreamReader(stream);
                    result = reader.ReadToEnd();
                }
            }

            return result ?? MissingResourceContent;
        }

        public static string MissingResourceContent
            => "<html><body><div><h1>Topic Not Found</h1><p>The requested topic was not found.</p></div></body></html>";
    }
}
