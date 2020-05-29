using Xamarin.Essentials;

namespace MobileKidsIdApp.Services
{
    public static class Settings
    {
        private static string AllowPasswordSetupKey = "AllowPasswordSetupKey";
        private static string IdentityKey = "IdentityKey";

        public static bool AllowPasswordSetup
        {
            get => Preferences.Get(AllowPasswordSetupKey, true);
            set => Preferences.Set(AllowPasswordSetupKey, value);
        }

        public static string Identity
        {
            get => Preferences.Get(IdentityKey, null);
            set => Preferences.Set(IdentityKey, value);
        }
    }
}
