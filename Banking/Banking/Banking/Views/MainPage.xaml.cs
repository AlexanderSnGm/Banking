using Banking.Logic;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Banking.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : TabbedPage
    {
        public MainPage(string userName)
        {
            
            InitializeComponent();
            this.Title = "Bienvenido " + userName + "!";
        }

        public MainPage()
        {

            InitializeComponent();
        }

        private async void MiLogout_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopToRootAsync();

        }
    }
}