using Xamarin.Forms;

namespace HindiXamApp
{
    public partial class App : Application
    {
        public static string CultureCode { get; set; }
        public App()
        {
            InitializeComponent();
            CultureCode = "";
            if (Device.OS != TargetPlatform.WinPhone)
            {
                DependencyService.Get<ILocalize>().SetLocale();
            }
            // The root page of your application
            MainPage = new NavigationPage( new HomePage());
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
