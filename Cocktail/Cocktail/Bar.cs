using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Cocktail
{

    public class Bar
    {
        public List<Cocktail> Cocktails { get => cocktails; set => cocktails = value; }

        private List<Cocktail> cocktails = new List<Cocktail>();

        public Bar()
        {
            GetCocktails();
        }

        public void GetCocktails()
        {
            using (var context = new BarContext())
            {
                //Get all cocktails and their liqours
                var query = context.Cocktails.Include(liquor => liquor.Liquors);

                cocktails.Clear();
                foreach (var item in query)
                {
                    //Add cocktail to list
                    cocktails.Add(item);
                }
            }
        }
        public void DeleteCocktail(string name)
        {
            using (var context = new BarContext())
            {
                //Find the cocktail by the name
                var foundcocktail = context.Cocktails.Where(cocktail => cocktail.CocktailNameId == name).Include(liquor => liquor.Liquors).First();
                //Make sure to delete liquor in cocktail, or liquor would still be in database
                foreach (var liquor in foundcocktail.Liquors.ToList())
                {
                    context.Liquors.Remove(liquor);
                }
                //Remove cocktail from database and save changes
                context.Cocktails.Remove(foundcocktail);
                context.SaveChanges();
            }
        }
        public void CreateCocktail(Cocktail cocktail)
        {
            using (var context = new BarContext())
            {
                //Adds a cocktail to database
                context.Cocktails.Add(cocktail);
                context.SaveChanges();
            }
        }
        public void EditCocktail(Cocktail changedCocktail)
        {
            using (var context = new BarContext())
            {
                //Find the cocktail that should be updated
                var foundcocktail = context.Cocktails.Where(cocktail => cocktail.CocktailNameId == changedCocktail.CocktailNameId)
                    .Include(liquor => liquor.Liquors).First();

                if (foundcocktail != null)
                {
                   //Clear the previous liquors
                    foundcocktail.Liquors.Clear();
                    
                    foreach (var liquor in changedCocktail.Liquors.ToList())
                    {
                        //Add all the liquors from the changed cocktail to the existing cocktail we want updated
                        foundcocktail.Liquors.Add(liquor);
                    }
                    //Update additions if changes have been made
                    if (foundcocktail.Additions != changedCocktail.Additions)
                        foundcocktail.Additions = changedCocktail.Additions;

                    context.SaveChanges();

                }

            }
            
        }
        public List<Cocktail> FindCocktail(string search)
        {
            using (var context = new BarContext())
            {
                List<Cocktail> cocktailList = new List<Cocktail>();
                //Find cocktails with searched name
                var query = context.Cocktails
                    .Include(liquor => liquor.Liquors);

                //Could not make liqour search
                //var query = context.Cocktails
                //    .Include(liquor => liquor.Liquors).Where(cocktail => cocktail.Liquors.All(liq => liq.Name.Contains(search)));

                //Could not make linQ work with searching for liquor but only cocktail name
                foreach (var cocktail in query)
                {
                    //If name of cocktail is same as search, add to list
                    if (cocktail.CocktailNameId == search)
                    {
                        cocktailList.Add(cocktail);
                    }
                    //Check liquor names
                    foreach (var liq in cocktail.Liquors)
                    {
                        //If liquor name is same as search, add to list
                        if (liq.Name == search)
                        {
                            cocktailList.Add(cocktail);
                            break;
                        }
                    }
                }
                return cocktailList;
            }
        }
        
    }

}

