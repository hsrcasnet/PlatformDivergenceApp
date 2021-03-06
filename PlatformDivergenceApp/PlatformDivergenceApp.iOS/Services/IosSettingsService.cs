﻿using Foundation;
using PlatformDivergenceApp.iOS.Services;
using PlatformDivergenceApp.Services;
using Xamarin.Forms;

// DEMO: Register iOS-specific dependency
[assembly: Dependency(typeof(IosSettingsService))]

namespace PlatformDivergenceApp.iOS.Services
{
    /// <summary>
    /// Implementation of iOS-specific settings service.
    /// </summary>
    public class IosSettingsService : SettingsServiceBase
    {
        public IosSettingsService()
        {
        }

        public override string GetValue(string key)
        {
            using (var defaults = NSUserDefaults.StandardUserDefaults)
            {
                return defaults.StringForKey(key);
            }
        }

        public override void SetValue(string key, string newValue)
        {
            using (var defaults = NSUserDefaults.StandardUserDefaults)
            {
                defaults.SetString(newValue ?? string.Empty, key);
                defaults.Synchronize();
            }
        }
    }
}