﻿using System;
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

            if (result.Status == 0)
            {
                //reg.Id = result.BankingUserResult.Id;
                //reg.Password = result.BankingUserResult.Password;
                //reg.FirstName = result.BankingUserResult.FirstName;
                //reg.LastName = result.BankingUserResult.LastName;
                //reg.Email = result.BankingUserResult.Email;
                //reg.PhoneNumber = result.BankingUserResult.PhoneNumber;
                user = result.BankingUserResult;
            }
            else {
                user = null;
            }

            return user;
        }

        public RequestResult Register(BankingUserReg bankingUserReg)
        {
            RequestResult result = API.RegisterWebMethod(bankingUserReg);
            if (result.Status != 0)
            {
                result = null;
            }

            return result;
            //throw new NotImplementedException();
        }

        public RequestResult RegisterBankAccount(BankingBankAccount bankingBankAccount)
        {
            RequestResult result = API.BankAccountWebMethod(BankingWebAPI.Methods.POST, bankingBankAccount);
            if (result.Status != 0)
            {
                result = null;
            }

            return result;
            //throw new NotImplementedException();
        }
    }
}
