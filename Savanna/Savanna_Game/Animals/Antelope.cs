using AnimalsBase;
using System;

namespace Animal
{
    public class Antelope : Herbivores
    {
        /// <summary>
        /// Property stores button for creating an animal.
        /// </summary>
        public override ConsoleKey AnimalConsoleKey
        {
            get
            {
                return ConsoleKey.A;
            }
            set { }
        }

        /// <summary>
        /// Constructor for Antelope.
        /// </summary>
        /// <param name="arraySizeX"> Number of rows in array. </param>
        /// <param name="arraySizeY"> Number of column in array. </param>
        public Antelope(int arraySizeX, int arraySizeY) : base(arraySizeX, arraySizeY)
        {
            AnimalTypeLabel = 'A';
            AnimalType = "Antelope";

            maximumHealth = 40;
            Health = maximumHealth;
            VisionRange = 3;
        }
    }
}
