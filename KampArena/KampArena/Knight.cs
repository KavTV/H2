using System;
using System.Collections.Generic;
using System.Text;

namespace KampArena
{
    class Knight : IFighter
    {
        public int DefenseLeft => defenseLeft;
        private int defenseLeft = 30;

        public int Attack()
        {
            Random rnd = new Random();
            return rnd.Next(1, 6);
        }

        public void Defend(int attack)
        {
            defenseLeft -= attack;
        }

        public bool HasEscaped()
        {
            Random rnd = new Random();

            if (rnd.Next(1,101) <= 15)
            {
                return true;
            }
            return false;
        }
    }
}
