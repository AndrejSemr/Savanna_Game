using AnimalsBase;
using System;

namespace Animal
{
    public class Lion : Hunters
    {
        /// <summary>
        /// Property stores button for creating an animal.
        /// </summary>
        public override ConsoleKey AnimalConsoleKey
        {
            get
            {
                return ConsoleKey.L;
            }
            set { }
        }

        /// <summary>
        /// Constructor for Lion.
        /// </summary>
        /// <param name="arraySizeX"> Number of rows in array. </param>
        /// <param name="arraySizeY"> Number of column in array. </param>
        public Lion(int arraySizeX, int arraySizeY) : base(arraySizeX, arraySizeY)
        {
            AnimalTypeLabel = 'L';
            AnimalType = "Lion";

            maximumHealth = 10;
            Health = maximumHealth;
            VisionRange = 6;
        }
    }
}
