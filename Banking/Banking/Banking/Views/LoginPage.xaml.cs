using Banking.Logic;
using BankingAPI.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Banking.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
	{
		public LoginPage ()
		{
			InitializeComponent();

            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += async (s, e) => {
                // handle the tap
                await Navigation.PushAsync(new ForgotLoginInfoPage());
            };
            lbForgotPass.GestureRecognizers.Add(tapGestureRecognizer);
        }

        async void BtnLogin_Clicked(object sender, EventArgs e)
        {

            //validates fields
            if (String.IsNullOrEmpty(txtID.Text) || String.IsNullOrEmpty(txtPwd.Text))
            {
                await DisplayAlert("Error", "Los campos de identificacion y contaseña son requeridos", "Volver a intentar");
                return;
            }
            else
            {
                BankingProcess logic = new BankingProcess();
                BankingUser reg = logic.ValidateLogin(txtID.Text, txtPwd.Text);
                if (reg != null)
                {
                    //Preferences.Set("UserName", txtID.Text);
                    //Preferences.Set("UserPassword", txtPwd.Text);
                    Utilities util = new Utilities();
                    util.SetSecureStorage("UserName", txtID.Text);
                    util.SetSecureStorage("UserPassword", txtPwd.Text);
                    string test = util.GetSecureStorage("UserName");

                    //registers a bank account
                    
                    /**BankingBankAccount account = new BankingBankAccount(0,reg.Id, "Personal CRC","Ahorros", 100,DateTime.Now, reg) ;

                    RequestResult result = logic.RegisterBankAccount(account);*/

                    await Navigation.PushAsync(new MainPage(reg.FirstName));
                }
                else {
                    await DisplayAlert("Credenciales Invalidas!", "Identificacion/contraseña incorrecta", "Volver a intentar");
                    return;
                }
            }
            //validates user credentials

            
        }

        async void BtnSignup_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SignUpPage());
        }
    }
}