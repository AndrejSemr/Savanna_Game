using Savanna.Playground;
using System;
using System.Collections.Generic;
using System.Text;

namespace Savanna.Savanna.Animals
{
    /// <summary>
    /// Abstract class for all animals.
    /// </summary>
    public abstract class Animal : PositionOnPlayground
    {
        /// <summary>
        /// Animal health metric.
        /// </summary>
        public double Health { get; set; }
        
        /// <summary>
        /// Animal vision range.
        /// </summary>
        public int VisionRange { get; set; }

        /// <summary>
        /// Method implements animal step.
        /// </summary>

        public Animal(Playground.Playground playground)
        {
            Random random = new Random();
            int newXCoord;
            int newYCoord;
            bool coodinateIsOk = false;

            while (!coodinateIsOk)
            {
                newXCoord = random.Next(0, 10);
                newYCoord = random.Next(0, 10);

                if(playground.PlaygroundGrid[newXCoord, newYCoord] == 0)
                {
                    XPaygroundCoordinate = newXCoord;
                    YPaygroundCoordinate = newYCoord;
                    coodinateIsOk = true;
                }
            }


        }

        public virtual void SpecialAction()
        {

        }

        public void MakeAStep()
        {
            Health = Health-0.5;
        }
    }
}
