using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Banking.Views;
using Xamarin.Essentials;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Banking
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();


            //MainPage = new MainPage();

            MainPage = new NavigationPage(new LoginPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
            //Preferences.Clear();
            SecureStorage.RemoveAll();
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
