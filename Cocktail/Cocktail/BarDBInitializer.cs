using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cocktail
{
    class BarDBInitializer : DropCreateDatabaseAlways<BarContext>
    {
        protected override void Seed(BarContext context)
        {
            List<Cocktail> defaultCocktail = new List<Cocktail>();

            defaultCocktail.Add(new Cocktail("Margarita", new List<Liquor> { new Liquor("Lime Juice",60), new Liquor("Triple Sec", 30), new Liquor("Tequila", 60) }));
            defaultCocktail.Add(new Cocktail("Mai Tai", new List<Liquor> { new Liquor("Dark Rum", 50), new Liquor("Orange Curacao", 15), new Liquor("Lime Juice", 10), new Liquor("Almond Syrup", 60) }));
            defaultCocktail.Add(new Cocktail("White Russian", new List<Liquor> { new Liquor("Fresh Cream", 30), new Liquor("Kahlua", 30), new Liquor("Vodka", 90) }));
            defaultCocktail.Add(new Cocktail("Screwdriver", new List<Liquor> { new Liquor("Orange Juice", 135), new Liquor("Vodka", 45) }));

            context.Cocktails.AddRange(defaultCocktail);

            base.Seed(context);
        }


    }
}
