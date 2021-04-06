using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBanker
{
    class Maestro : Card, IExpiryDate
    {
        public DateTime ExpiryDate { get => expiryDate; set => expiryDate = value; }

        private DateTime expiryDate;

        public Maestro(string name)
        {
            AutoGenerate(name, "5018");
            AddExpiryDate();
            International = true;
        }
        public override string CardNumberGenerator()
        {
            //This card specifically has 15 numbers (without prefix)
            Random rnd = new Random();
            string rndstring = "";
            for (int i = 0; i < 15; i++)
            {
                rndstring += rnd.Next(0, 9);
            }
            return rndstring;
        }
        public void AddExpiryDate()
        {
            ExpiryDate = DateTime.Now.AddYears(5).AddMonths(8);
        }
    }
}
