using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBanker
{
     public abstract class Card
    {
        protected string Name { get => name; set => name = value; }
        protected long CardNumber { get => cardNumber; set => cardNumber = value; }
        protected bool International { get => international; set => international = value; }
        protected Account Account { get => account; set => account = value; }

        private string name;
        private long cardNumber;
        private bool international = false;
        private Account account;

        /// <summary>
        /// Used to validate a card before buing
        /// </summary>
        /// <param name="amount"></param>
        /// <returns></returns>
        public virtual bool Validate(double amount)
        {
            if (account.Balance > amount)
            {
                return true;
            }
            return false;
        }
        public virtual void Pay(double amount)
        {
            //Removes money from balance
            account.RemoveFromBalance(amount);
        }
        public virtual void AutoGenerate(string name, string prefix)
        {
            //Generate a card, with prefix from type of card.
            this.name = name;
            this.cardNumber = long.Parse(prefix += CardNumberGenerator());
            this.account = new Account(AccountNumberGenerator());
        }
        public virtual string CardNumberGenerator()
        {
            Random rnd = new Random();
            string rndstring = "";
            for (int i = 0; i < 12; i++)
            {
                rndstring += rnd.Next(0, 9);
            }
            return rndstring;
        }
        public long AccountNumberGenerator()
        {
            Random rnd = new Random();
            string accountstring = "";

            for (int i = 0; i < 10; i++)
            {
                accountstring += rnd.Next(0, 9);
            }
            return long.Parse(accountstring);
        }

    }
}
