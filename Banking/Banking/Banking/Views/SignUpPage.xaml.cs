using Banking.Logic;
using Banking.Objects;
using BankingAPI.Objects;
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
	public partial class SignUpPage : ContentPage
	{
        BankingValidations validates = new BankingValidations();
        BankingProcess logic = new BankingProcess();
        public SignUpPage ()
		{
			InitializeComponent();
		}

        private async void BtnSignUp_Clicked(object sender, EventArgs e)
        {
            BankingUserForReg reg = new BankingUserForReg(0, txtFirstName.Text, txtLastName.Text, txtID.Text, txtPhone.Text, txtPwd.Text, txtPwd2.Text);
            
            string errors = validates.ValidateUser(reg);
            if (String.IsNullOrEmpty(errors))
            {
                RequestResult result = logic.Register(new BankingUserReg(reg.Id, reg.FirstName, reg.LastName, reg.Email, reg.PhoneNumber, reg.Password));
                await DisplayAlert("Bienvenido!", "Usuario registrado con exito! \n", "OK");
                await Navigation.PopAsync();//Navigation.PushAsync(new LoginPage());
            }
            else {
                await DisplayAlert("Error", errors, "OK");
                return;
            }
        }

        
    }
}