using System;
using System.Collections.Generic;
using System.Text;

namespace KampArena
{
    class DragonAdapter : IFighter
    {
        private Dragon dragon;
        private bool secondAttack = false;

        public int DefenseLeft => dragon.Defense();

        public DragonAdapter(Dragon dragon)
        {
            this.dragon = dragon;
        }
        public int Attack()
        {
            if (secondAttack == false)
            {
                return dragon.TaleSlash();
            }
            else
            {
                return dragon.BreatheFire();
            }
        }

        public void Defend(int attack)
        {
            dragon.Defend(attack);
        }

        public bool HasEscaped()
        {
            return dragon.IsFlyingAway();
        }
    }
}
