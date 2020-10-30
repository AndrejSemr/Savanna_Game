using System;
using System.Collections.Generic;

namespace AnimalsBase
{
    /// <summary>
    /// Class simulates a Herbivores.
    /// </summary>
    public class Herbivores : Animal
    {
        /// <summary>
        /// Property stores button for creating an animal.
        /// </summary>
        public override ConsoleKey AnimalConsoleKey { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        /// <summary>
        /// Hebrivores constructor. 
        /// </summary>
        /// <param name="arraySizeX"> Number of rows in array. </param>
        /// <param name="arraySizeY"> Number of column in array. </param>
        public Herbivores(int arraySizeX, int arraySizeY) :base(arraySizeX,arraySizeY)
        {
            maximumHealth = 50;
            Health = maximumHealth;
            VisionRange = 3;
        }

        /// <summary>
        /// Special method realisation: Herbivores try to avoid hunters. 
        /// </summary>
        /// <param name="hunters"> List of hunters. </param>
        /// <param name="herbivores"> List of herbivores. </param>
        /// <param name="playground"> Playground array of char. </param>
        public override void SpecialAnimalBehavior(List<Hunters> hunters, List<Herbivores> herbivores, char[,] playground)
        {
            int xArraySize = playground.GetLength(0);
            int yArraySize = playground.GetLength(1);

            int idOfNearestHunter = FindClosestAnumalIndex(hunters, xArraySize, yArraySize,false);

            if (idOfNearestHunter != -1)
            {
                Spet(hunters[idOfNearestHunter], playground, false);
            }

            CheckedBirthday(herbivores, playground.GetLength(0),playground.GetLength(1));

            DecreaseEnergyParDay();
        }


        /// <summary>
        /// Method checks animals and decides to increase counter or set 0.
        /// </summary>
        /// <param name="herbivores"> List of hebrivers. </param>
        /// <param name="rowNumber"> Number of rows on playground. </param>
        /// <param name="columnNumber"> Number of columns on playground. </param>
        public void CheckedBirthday(List<Herbivores> herbivores, int rowNumber, int columnNumber)
        {
            int idOfNearestHerbivores = FindClosestAnumalIndexByType(herbivores, rowNumber, columnNumber, AnimalType);

            if (idOfNearestHerbivores != -1)
            {
                double closestHerbivores = DistanceBetweenToAnimalse(
                    XPaygroundCoordinate,
                    YPaygroundCoordinate,
                    herbivores[idOfNearestHerbivores].XPaygroundCoordinate, 
                    herbivores[idOfNearestHerbivores].YPaygroundCoordinate,
                    rowNumber,columnNumber);

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
