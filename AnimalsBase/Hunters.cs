using System;
using System.Collections.Generic;

namespace AnimalsBase
{

    /// <summary>
    /// Class simulates a hunters.
    /// </summary>
    public class Hunters : Animal
    {
        /// <summary>
        /// Property stores button for creating an animal.
        /// </summary>
        public override ConsoleKey AnimalConsoleKey { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        /// <summary>
        /// Constructor for hunters.
        /// </summary>
        /// <param name="arraySizeX"> Number of rows in array. </param>
        /// <param name="arraySizeY"> Number of column in array. </param>
        public Hunters(int arraySizeX, int arraySizeY) : base(arraySizeX,arraySizeY)
        {
            maximumHealth = 30;
            Health = maximumHealth;
            VisionRange = 5;
        }

        /// <summary>
        /// Special method realisation: Hunters trying catch and eat herbivores.
        /// </summary>
        /// <param name="hunters"> List of hunters. </param>
        /// <param name="herbivores"> List of herbivores. </param>
        /// <param name="playground"> Playground array. </param>
        public override void SpecialAnimalBehavior(List<Hunters> hunters, List<Herbivores> herbivores, char[,] playground)
        {
            int xArraySize = playground.GetLength(0);
            int yArraySize = playground.GetLength(1);

            int idOfNearestHerbivores = FindClosestAnumalIndex(herbivores, xArraySize, yArraySize,false);

            if (idOfNearestHerbivores != -1)
            {
                double distance = DistanceBetweenToAnimalse(XPaygroundCoordinate, YPaygroundCoordinate, herbivores[idOfNearestHerbivores].XPaygroundCoordinate, herbivores[idOfNearestHerbivores].YPaygroundCoordinate, xArraySize, yArraySize);

                if (distance < 1.4143)
                {
                    EatTarget(herbivores, idOfNearestHerbivores);
                }
                else
                {
                    Spet(herbivores[idOfNearestHerbivores], playground, true);
                }
            }

            CheckedBirthday(hunters, playground.GetLength(0), playground.GetLength(1));

            DecreaseEnergyParDay();
        }

        /// <summary>
        /// Hunter eats hebrivore.
        /// </summary>
        /// <param name="herbivores"> List of hebrivores. </param>
        /// <param name="indexOfHebrivores"> Index of nearest herbivores. </param>
        protected void EatTarget(List<Herbivores> herbivores, int indexOfHebrivores)
        {
            Health = maximumHealth;
            herbivores.RemoveAt(indexOfHebrivores);
        }

        /// <summary>
        /// Method checks animals and decides to increase counter or set 0.
        /// </summary>
        /// <param name="hunters"> List of hunters. </param>
        /// <param name="rowNumber"> Number of rows on playground. </param>
        /// <param name="columnNumber"> Number of columns on playground. </param>
        private void CheckedBirthday(List<Hunters> hunters, int rowNumber, int columnNumber)
        {
            int idOfNearestHerbivores = FindClosestAnumalIndexByType(hunters, rowNumber, columnNumber, AnimalType);
            if (idOfNearestHerbivores != -1)
            {
                double closestHerbivores = DistanceBetweenToAnimalse(XPaygroundCoordinate, YPaygroundCoordinate, hunters[idOfNearestHerbivores].XPaygroundCoordinate, hunters[idOfNearestHerbivores].YPaygroundCoordinate, 20, 20);
                if (closestHerbivores < 1.4143)
                {
                    TimeToGiveBorth++;
                }
                else
                {
                    TimeToGiveBorth = 0;
                }
            }
        }

    }
}
