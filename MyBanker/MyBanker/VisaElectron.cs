using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBanker
{
    class VisaElectron : Card, IExpiryDate
    {
        public DateTime ExpiryDate { get => expiryDate; set => expiryDate = value; }

        private DateTime expiryDate;

        public VisaElectron(string name)
        {
            AutoGenerate(name, "4026");
            AddExpiryDate();
            International = true;
        }
        public override bool Validate(int amount)
        {
            //Validate that the monthly use is not over 10k
            if (Account.MonthlyUse + amount <= 10000)
            {
                return true;
            }
            return false;
        }
        public void AddExpiryDate()
        {
            ExpiryDate = DateTime.Now.AddYears(5);
        }
    }
}
