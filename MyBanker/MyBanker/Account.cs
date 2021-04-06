using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBanker
{
    public class Account
    {
        public long AccountNumber { get => accountNumber;}
        public double Balance { get => balance;}
        public double MonthlyUse { get => monthlyUse;}


        private long accountNumber;
        private double balance;
        private double monthlyUse = 0;


        public Account(long accountNumber)
        {
            this.accountNumber = accountNumber;
            this.balance = 45000;
        }
        public void RemoveFromBalance(double amount)
        {
            balance -= amount;
            monthlyUse += amount;
        }

    }
}
