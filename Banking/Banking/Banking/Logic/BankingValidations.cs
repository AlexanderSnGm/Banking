using Banking.Objects;
using BankingAPI.Objects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Banking.Logic
{
    public class BankingValidations
    {
        private string emailPattern = @"^([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5})$";
        private string phonePattern = @"^\(?\d{3}\)?-? *\d{3}-? *-?\d{4}";
        /// <summary>
        /// Validate the reg obj
        /// </summary>
        /// <param name="reg"></param>
        /// <returns></returns>
        public string ValidateUser(BankingUserForReg reg) {
            string error = "";
            bool nonFirstError = false;

            if (String.IsNullOrEmpty(reg.FirstName)) {
                if (nonFirstError)
                    nonFirstError = true;

                error += nonFirstError ? "\n" : "";
                error += "El campo de nombre es requerido! \n";
            }
            if (String.IsNullOrEmpty(reg.LastName))
            {
                if (nonFirstError)
                    nonFirstError = true;

                error += nonFirstError ? "\n" : "";
                error += "El campo de apellido es requerido! \n";
            }


            error += ValidateEmail(reg.Email, nonFirstError);

            if (String.IsNullOrEmpty(reg.PhoneNumber))
            {
                if (nonFirstError)
                    nonFirstError = true;

                error += nonFirstError ? "\n" : "";
                error += "El campo de teléfono es requerido! \n";
            }
            //else if (!Regex.IsMatch(reg.PhoneNumber, phonePattern))
            //{
            //    if (nonFirstError)
            //        nonFirstError = true;

            //    error += nonFirstError ? "\n" : "";
            //    error += "El teléfono ingresado no posee un formato valido! \n";
            //}

            if (String.IsNullOrEmpty(reg.Password))
            {
                if (nonFirstError)
                    nonFirstError = true;

                error += nonFirstError ? "\n" : "";
                error += "El campo de contraseña es requerido! \n";
            }
            else if(reg.Password.Length <= 5) {
                if (nonFirstError)
                    nonFirstError = true;

                error += nonFirstError ? "\n" : "";
                error += "La contraseña debe tener al menos 6 caracteres! \n";
            }
            if (String.IsNullOrEmpty(reg.confirmationPassword))
            {
                if (nonFirstError)
                    nonFirstError = true;

                error += nonFirstError ? "\n" : "";
                error += "El campo de confirmación de la contraseña es requerido! \n";
            }

            if(reg.Password != reg.confirmationPassword)
            {
                if (nonFirstError)
                    nonFirstError = true;

                error += nonFirstError ? "\n" : "";
                error += "Los campos de contraseña y confirmación de la contraseña no coinciden! \n";
            }



            return error;
        }

        public string ValidateEmail(string email, bool nonFirstError = false) {
            string error = "";
            if (String.IsNullOrEmpty(email))
            {
                if (nonFirstError)
                    nonFirstError = true;

                error += nonFirstError ? "\n" : "";
                error += "El campo de email es requerido! \n";
            }
            else if (!Regex.IsMatch(email, emailPattern))
            {
                if (nonFirstError)
                    nonFirstError = true;

                error += nonFirstError ? "\n" : "";
                error += "El email ingresado no posee un formato valido! \n";
            }
            return error;
        }


    }
}
