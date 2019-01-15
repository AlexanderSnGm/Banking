using System;
using System.Collections.Generic;
using System.Text;
using BankingAPI;
using BankingAPI.Objects;


namespace Banking.Logic
{
    public class BankingProcess
    {
        BankingWebAPI API = new BankingWebAPI();


        public BankingUser ValidateLogin(string login, string password) {
            BankingUser user = new BankingUser();

            RequestResult result = API.LoginWebMethod(login, password);

            if (result.Status == 0) {
                //reg.Id = result.BankingUserResult.Id;
                //reg.Password = result.BankingUserResult.Password;
                //reg.FirstName = result.BankingUserResult.FirstName;
                //reg.LastName = result.BankingUserResult.LastName;
                //reg.Email = result.BankingUserResult.Email;
                //reg.PhoneNumber = result.BankingUserResult.PhoneNumber;
                user = result.BankingUserResult;
            }

            return user;
        }


    }
}
