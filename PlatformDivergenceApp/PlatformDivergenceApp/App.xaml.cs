using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

namespace PlatformDivergenceApp
{
    public partial class App : Application
    {
        public App(string databasePath)
        {
            this.InitializeComponent();

            this.MainPage = new NavigationPage(new MainPage(databasePath));
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}