using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WF_BankingApplication
{
    public class CBankingApp
    {
        private string AccName;
        private string AccAddress;
        private static decimal OpBalance;

        private decimal NetBalance;

        public void CreateAccount(string accName, string accAddress, decimal opBalalce)
        {
            AccName = accName;
            AccAddress = accAddress;
            OpBalance = opBalalce;
        }

        public decimal Withdrawal(decimal trAmount)
        {
            NetBalance = OpBalance - trAmount;
            return NetBalance;
        }

        public decimal Deposit(decimal trAmount)
        {
            NetBalance = OpBalance + trAmount;
            return NetBalance;
        }

    }
}
