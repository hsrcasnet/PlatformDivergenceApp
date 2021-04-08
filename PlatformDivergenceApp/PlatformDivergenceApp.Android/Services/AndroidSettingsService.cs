using Android.Preferences;
using PlatformDivergenceApp.Droid.Services;
using PlatformDivergenceApp.Services;
using Xamarin.Forms;
using Application = Android.App.Application;

// DEMO: Register Android-specific dependency
[assembly: Dependency(typeof(AndroidSettingsService))]

namespace PlatformDivergenceApp.Droid.Services
{
    /// <summary>
    /// Implementation of Android-specific settings service.
    /// </summary>
    public class AndroidSettingsService : SettingsServiceBase
    {
        public AndroidSettingsService()
        {
        }

        public override string GetValue(string key)
        {
            using (var sharedPreferences = PreferenceManager.GetDefaultSharedPreferences(Application.Context))
            {
                return sharedPreferences.GetString(key, null);
            }
        }

        public override void SetValue(string key, string newValue)
        {
            using (var sharedPreferences = PreferenceManager.GetDefaultSharedPreferences(Application.Context))
            {
                using (var sharedPreferencesEditor = sharedPreferences.Edit())
                {
                    sharedPreferencesEditor.PutString(key, newValue);
                    sharedPreferencesEditor.Commit();
                }
            }
        }
    }
}