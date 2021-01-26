using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cocktail
{
    public class Liquor
    {
        //Need id as primary key since Name can be used multiple times
        public int LiquorId { get; set; }
        public string Name { get => name; set => name = value; }
        public int Amount { get => amount; set => amount = value; }


        string name;
        int amount;

        public Liquor()
        {

        }
        public Liquor(string name, int amount)
        {
            this.name = name;
            this.amount = amount;
        }

    }
}
