using System;
using System.Collections.Generic;
using System.Text;

namespace Savanna.Savanna.Animals
{
    public class Antelope : Herbivores
    {
        public Antelope(Playground playground) : base(playground)
        {
            Health = 40;
        }
    }
}
