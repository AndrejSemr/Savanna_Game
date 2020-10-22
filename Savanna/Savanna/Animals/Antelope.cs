using System;
using System.Collections.Generic;
using System.Text;

namespace Savanna.Savanna.Animals
{
    public class Antelope : Herbivores
    {
        public Antelope(Playground playground) : base(playground)
        {
            maximumHealth = 40;
            Health = maximumHealth;
            VisionRange = 3;
        }
    }
}
