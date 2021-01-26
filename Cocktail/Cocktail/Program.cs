using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Cocktail
{
    class Program
    {
        static Bar bar = new Bar();
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("1 = Se cocktails \n 2 = Slet cocktail \n 3 = Lav cocktail \n 4 = rediger cocktail \n 5 = Søg efter cocktail");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        GetCocktails();
                        break;
                    case "2":
                        DeleteCocktail();
                        break;
                    case "3":
                        CreateCocktail();
                        break;
                    case "4":
                        EditCocktail();
                        break;
                    case "5":
                        FindCocktail();
                        break;
                }
            }
            

            

        }
        private static void GetCocktails()
        {
            //Update cocktail list
            bar.GetCocktails();
            //Write out information about cocktail
            foreach (var item in bar.Cocktails)
            {
                Console.WriteLine(item.CocktailNameId);
                foreach (var liqour in item.Liquors)
                {
                    Console.WriteLine(liqour.Name);
                    Console.WriteLine(liqour.Amount + " ml");
                }
                Console.WriteLine(item.Additions);
                Console.WriteLine("---------------------");
            }
        }
        private static void DeleteCocktail()
        {
            //give user overview
            GetCocktails();
            Console.WriteLine("Skriv navnet på den drink du vil slette");
            string nameInput = Console.ReadLine();
            bar.DeleteCocktail(nameInput);
        }
        private static void CreateCocktail()
        {
            Console.WriteLine("Lav din cocktail");
            List<Liquor> liquors = new List<Liquor>();
            //Get how many types of liquor the user wants
            Console.WriteLine("Hvor mange forskellige ting skal der i din drink?");
            int amountOfLiquor = int.Parse(Console.ReadLine());

            for (int i = 0; i < amountOfLiquor; i++)
            {
                //Save each liquor in list
                Console.WriteLine("hvad skal der være i din drink?");
                string liqourInput = Console.ReadLine();
                Console.WriteLine("hvor mange ml skal der være?");
                int amountInput = int.Parse(Console.ReadLine());
                liquors.Add(new Liquor(liqourInput, amountInput));
            }
            Console.WriteLine("Hvad skal din drink hedde?");
            string cocktailName = Console.ReadLine();
            bar.CreateCocktail(new Cocktail(cocktailName, liquors));
        }
        private static void EditCocktail()
        {
            //Give user overview of cocktails
            GetCocktails();

            Console.WriteLine("Hvilken drink vil du ændre?");
            string selectedDrink = Console.ReadLine();

            List<Liquor> liquors = new List<Liquor>();
            //Get how many types of liquor the user wants
            Console.WriteLine("Hvor mange forskellige ting skal der i drinken?");
            int amountOfLiquor = int.Parse(Console.ReadLine());

            for (int i = 0; i < amountOfLiquor; i++)
            {
                //Save each liquor in list
                Console.WriteLine("hvad skal der være i din drink?");
                string liqourInput = Console.ReadLine();
                Console.WriteLine("hvor mange ml skal der være?");
                int amountInput = int.Parse(Console.ReadLine());
                liquors.Add(new Liquor(liqourInput, amountInput));
            }
            Console.WriteLine("har du nogle tilføjelser? ja/nej");
            string additionInput = Console.ReadLine();
            if (additionInput.ToLower() == "ja")
            {
                Console.WriteLine("Hvad skal din tilføjelse være?");
                string addition = Console.ReadLine();
                bar.EditCocktail(new Cocktail(selectedDrink, liquors, addition));
            }
            else
            {
                bar.EditCocktail(new Cocktail(selectedDrink, liquors));
            }
        }
        private static void FindCocktail()
        {
            Console.WriteLine("Skriv hvad du vil søge efter");
            string searchInput = Console.ReadLine();
            var cocktails = bar.FindCocktail(searchInput);
            if (cocktails != null)
            {
                Console.Clear();
                foreach (var cocktail in cocktails)
                {
                    Console.WriteLine(cocktail.CocktailNameId);
                }
            }
        }

    }
}
