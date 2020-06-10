using Android.App;
using Android.Content.PM;
using Android.OS;
using PlatformDivergenceApp.Services;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

namespace PlatformDivergenceApp.Droid
{
    [Activity(Label = "PlatformDivergenceApp", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);
            Forms.Init(this, savedInstanceState);
            var databasePath = DatabaseAccess.GetDatabaseFilePath();
            this.LoadApplication(new App(databasePath));
        }
    }
}