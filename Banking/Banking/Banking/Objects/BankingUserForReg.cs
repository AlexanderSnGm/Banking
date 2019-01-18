using BankingAPI.Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Banking.Objects
{
    public class BankingUserForReg : BankingUserReg
    {
        public string confirmationPassword { get; set; }

        public BankingUserForReg(int id, string firstName, string lastName, string email, string phoneNumber, string password, string confirmationPassword) : base(id, firstName, lastName, email, phoneNumber, password)
        {
            this.confirmationPassword = confirmationPassword;
        }

        //public BankingUserForReg(string id, string firstName, string lastName, string  )

    }
}
