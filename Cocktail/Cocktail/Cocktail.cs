using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cocktail
{
    public class Cocktail
    {
        [Key]
        public string CocktailNameId { get => name; set => name = value; }
        public List<Liquor> Liquors { get => liquors; set => liquors = value; }
        public string Additions { get => additions; set => additions = value; }

        private string name;
        private List<Liquor> liquors = new List<Liquor>();
        private string additions;
        public Cocktail()
        {

        }
        public Cocktail(string name, List<Liquor> liquors)
        {
            this.name = name;
            this.liquors = liquors;
        }
        public Cocktail(string name, List<Liquor> liquors, string additions)
        {
            this.name = name;
            this.liquors = liquors;
            this.additions = additions;
        }



    }
}
