using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBanker
{
    public class Creditcard : Card
    {
        protected double UsedCredit { get => usedCredit; set => usedCredit = value; }
        protected double MaxWithdraw { get => maxWithdraw; set => maxWithdraw = value; }
        protected double Credit { get => credit; set => credit = value; }
        protected double UsedMaxWithdraw {  get => usedMaxWithdraw;  set => usedMaxWithdraw = value; }

        private double usedCredit = 0;
        private double credit;
        private double maxWithdraw;
        private double usedMaxWithdraw = 0;

        

        public virtual bool Withdraw(double amount)
        {
            if (UsedMaxWithdraw + amount < maxWithdraw)
            {
                usedMaxWithdraw += amount;
                usedCredit += amount;
                return true;
            }
            return false;
        }
        public void PayUsedCredit()
        {
            //Not implemented
            //Monthly payment of used credit
            Account.RemoveFromBalance(UsedCredit);
            UsedCredit = 0;
        }

    }
}
