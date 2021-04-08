using System;
using PlatformDivergenceApp.Services;
using Xamarin.Forms;

namespace PlatformDivergenceApp
{
    public partial class MainPage : ContentPage
    {
        private readonly ISettingsService settingsService;

        public MainPage(string databasePath)
        {
            this.InitializeComponent();

            this.DatabasePathLabel.Text = databasePath;

            // DEMO: Conditional formatting using RuntimePlatform
            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    this.Title = "Platform Divergence @ iOS";
                    this.SettingsEntry.Placeholder = "Enter iOS Settings...";
                    this.SettingsEntry.PlaceholderColor = Color.Blue;
                    break;
                case Device.Android:
                    this.Title = "Platform Divergence @ Android";
                    this.SettingsEntry.Placeholder = "Enter Android Settings...";
                    this.SettingsEntry.PlaceholderColor = Color.Green;
                    break;
            }

            // DEMO: Resolve ISettingsService using Xamarin.Forms.DependencyService
            this.settingsService = DependencyService.Get<ISettingsService>();
        }

        private void OnGetValueButtonClicked(object sender, EventArgs e)
        {
            this.SettingsEntry.Text = this.settingsService.GetValue("SettingsKey");
        }

        private void OnSetValueButtonClicked(object sender, EventArgs e)
        {
            this.settingsService.SetValue("SettingsKey", this.SettingsEntry.Text);
        }

        private void OnResetButtonClicked(object sender, EventArgs e)
        {
            this.settingsService.Reset("SettingsKey");
            this.SettingsEntry.Text = this.settingsService.GetValue("SettingsKey");
        }
    }
}