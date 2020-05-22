using Xamarin.Essentials;

namespace MobileKidsIdApp.Services
{
    public class SettingsRepository
    {
        private readonly string AllowPasswordSetupKey = "AllowPasswordSetupKey";

        public bool AllowPasswordSetup
        {
            get => Preferences.Get(AllowPasswordSetupKey, true);
            set => Preferences.Set(AllowPasswordSetupKey, value);
        }
    }
}
