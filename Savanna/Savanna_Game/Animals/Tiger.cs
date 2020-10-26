using Savanna.Savanna.Animals;
using System;
using System.Collections.Generic;
using System.Text;

namespace Savanna.Savanna_Game.Animals
{
    public class Tiger: Hunters
    {
        public Tiger(IPlayground playground) : base(playground)
        {
            AnimalTypeLabel = 'T';
            AnimalType = "Tiger";

            maximumHealth = 30;
            Health = maximumHealth;
            VisionRange = 4;
        }

        public Tiger(IPlayground playground, int currentPositionX, int currentPositionY, int rangeX, int rangeY)
        : base(playground, currentPositionX, currentPositionY, rangeX, rangeY)
        {
        }
    }
}
