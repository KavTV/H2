using System;

namespace KampArena
{
    class Program
    {
        static void Main(string[] args)
        {
            //Do the first fight
            IFighter fight1 = Fight(new Knight(), new Knight());
            if (fight1 != null)
                Console.WriteLine(fight1.ToString());

            //Do Knight, Wizard fight
            IFighter fight2 = Fight(new Knight(), new WizardAdapter(new Wizard()));
            if (fight2 != null)
                Console.WriteLine(fight2.ToString());

            //Knight, dragon fight
            IFighter fight3 = Fight(new Knight(), new DragonAdapter(new Dragon()));
            if (fight3 != null)
                Console.WriteLine(fight3.ToString());

            //
            IFighter fight4 = Fight(new DragonAdapter(new Dragon()), new WizardAdapter(new Wizard()));
            if (fight4 != null)
                Console.WriteLine(fight4.ToString());

            Console.ReadLine();
        }

        public static IFighter Fight(IFighter f1, IFighter f2)
        {

            while ((!f1.HasEscaped() && !f2.HasEscaped()) && ((f1.DefenseLeft > 0) && (f2.DefenseLeft > 0)))
            {
                // Første fighter henter attack
                int attack = f1.Attack();
                // Anden fighter skal forsvare sig
                f2.Defend(attack);
                // Anden fighter henter attack
                attack = f2.Attack();
                // Første fighter skal forsvare sig
                f1.Defend(attack);
            }

            IFighter winner = null;

            // kampen er afsluttet
            if ((f1.DefenseLeft > 0) && (!f1.HasEscaped()))
                winner = f1;

            if ((f2.DefenseLeft > 0) && (!f2.HasEscaped()))
                winner = f2;

            // Hvis der returneres null, så har kampen været jævnbyrdig
            return winner;

        }

    }
}
