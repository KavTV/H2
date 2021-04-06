using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBanker
{
    class Mastercard : Creditcard, IExpiryDate
    {
        private double dailyUsedWithdraw = 0;
        public DateTime ExpiryDate { get => expiryDate; set => expiryDate = value; }

        private DateTime expiryDate;
        public Mastercard(string name)
        {
            Credit = 40000;
            MaxWithdraw = 30000;
            AutoGenerate(name, "51");
            AddExpiryDate();
        }

        public override bool Validate(double amount)
        {
            //card must not have used all credit
            if (UsedCredit + amount <= Credit)
            {
                return true;
            }
            return false;
        }
        public override bool Withdraw(double amount)
        {
            //Mastercard has only 5k daily withdraw
            if (dailyUsedWithdraw + amount <= 5000)
            {

                bool withdrawvalidated = base.Withdraw(amount);
                if (withdrawvalidated)
                {
                    dailyUsedWithdraw += amount;
                    return true;
                }
            }
            return false;
        }

        public override void Pay(double amount)
        {
            UsedCredit += amount;
        }

        public void AddExpiryDate()
        {
            ExpiryDate = DateTime.Now.AddYears(5);
        }
    }
}
