using AnimalsBase;
using System;

namespace Animal
{
    public class Tiger : Hunters
    {
        /// <summary>
        /// Property stores button for creating an animal.
        /// </summary>
        public override ConsoleKey AnimalConsoleKey
        {
            get
            {
                return ConsoleKey.T;
            }
            set { }
        }

        /// <summary>
        /// Constructor for Tiger.
        /// </summary>
        /// <param name="arraySizeX"> Number of rows in array. </param>
        /// <param name="arraySizeY"> Number of column in array. </param>
        public Tiger(int arraySizeX, int arraySizeY) : base(arraySizeX, arraySizeY)
        {
            AnimalTypeLabel = 'T';
            AnimalType = "Tiger";

            maximumHealth = 30;
            Health = maximumHealth;
            VisionRange = 4;
        }
    }
}
