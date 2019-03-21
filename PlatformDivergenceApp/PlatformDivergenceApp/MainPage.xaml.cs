using System;
using PlatformDivergenceApp.Services;
using Xamarin.Forms;

namespace PlatformDivergenceApp
{
    public partial class MainPage : ContentPage
    {
        private readonly ISettingsService settingsService;

        public MainPage()
        {
            this.InitializeComponent();

            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    this.SettingsEntry.Placeholder = "Enter iOS Settings...";
                    this.SettingsEntry.PlaceholderColor = Color.Blue;
                    break;
                case Device.Android:
                    this.SettingsEntry.Placeholder = "Enter Android Settings...";
                    this.SettingsEntry.PlaceholderColor = Color.Green;
                    break;
            }

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