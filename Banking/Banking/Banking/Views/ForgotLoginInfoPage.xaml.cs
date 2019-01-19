using Banking.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Banking.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ForgotLoginInfoPage : ContentPage
	{
		public ForgotLoginInfoPage ()
		{
			InitializeComponent ();
		}

        private async void BtnForgotPass_Clicked(object sender, EventArgs e)
        {
            string errors = "";

            BankingValidations val = new BankingValidations();
            errors = val.ValidateEmail(txtID.Text);
            //send email
            //BankingUserForReg reg = new BankingUserForReg(0, txtFirstName.Text, txtLastName.Text, txtID.Text, txtPhone.Text, txtPwd.Text, txtPwd2.Text);

            
            //
            if (String.IsNullOrEmpty(errors))
            {               
                await DisplayAlert("Correo Enviado!", "Su información de usuario ha sido enviada a su correo de forma exitosa!\n", "OK");
                await Navigation.PopAsync();//Navigation.PushAsync(new LoginPage());
            }
            else
            {
                await DisplayAlert("Error", errors, "OK");
                return;
            }

        }
    }
}