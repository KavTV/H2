using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaffeaskinen
{
    public abstract class Machine
    {
        public double WaterContainer { get => waterContainer; set => waterContainer = value; }
        public Content Content { get => content; set => content = value; }
        public bool TurnedOn { get => turnedOn; set => turnedOn = value; }
        public double Output { get => output; set => output = value; }
        
        private double waterContainer;
        private Content content = new Content();

        private bool turnedOn;

        private double output;

        public virtual void RefillWater(int cups, double cupsize)
        {
            //Refill container by the amount of cups and the size of the cups.
            WaterContainer = cups * cupsize;
        }
        public void RefillContent(double amount)
        {
            content.Amount = amount;
        }
        public void TurnOn()
        {
            turnedOn = true;
        }
        public void TurnOff()
        {
            turnedOn = false;
        }
        public void MakeOutput()
        {
            Output = WaterContainer;
            WaterContainer = 0;
            Content.Amount = 0;
        }
    }
}
