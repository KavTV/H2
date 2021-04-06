using System;
using System.Collections.Generic;
using System.Text;

namespace KampArena
{
    public class WizardAdapter : IFighter
    {
        private Wizard wizard;
        public int DefenseLeft => wizard.DefenseLeft();
        

        public WizardAdapter(Wizard wizard)
        {
            this.wizard = wizard;
        }

        public int Attack()
        {
            return wizard.CastFireballSpell();
        }

        public void Defend(int attack)
        {
            //The shield method is broken and the wizard never takes damage
            //Im not allowed to change wizard class in the task.
            wizard.Shield(attack);
        }

        public bool HasEscaped()
        {
            return wizard.IsPortalOpened();
        }
    }
}
