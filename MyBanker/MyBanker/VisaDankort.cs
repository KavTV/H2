using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBanker
{
    public class VisaDankort : Creditcard, IExpiryDate
    {
        public DateTime ExpiryDate { get => expiryDate; set => expiryDate = value; }

        private DateTime expiryDate;
        public VisaDankort(string name)
        {
            //Monthly credit 20k and max withdraw 25k a month
            Credit = 20000;
            MaxWithdraw = 25000;
            AutoGenerate(name, "4");
            AddExpiryDate();
        }
        public override bool Validate(double amount)
        {
            //Max 25000
            if (UsedMaxWithdraw + amount <= 25000)
            {
                return true;
            }
            //If the if use is too high
            return false;
        }
        public override void Pay(double amount)
        {
            //take account for overdraft
            if (Account.Balance < amount)
            {
                UsedCredit += amount;
                return;
            }
            base.Pay(amount);
        }
        public void AddExpiryDate()
        {
            ExpiryDate = DateTime.Now.AddYears(5);
        }
    }
}
