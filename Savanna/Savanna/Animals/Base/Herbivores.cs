using Savanna;
using System;
using System.Collections.Generic;
using System.Text;

namespace Savanna.Savanna.Animals
{
    /// <summary>
    /// Class simulates a Predator.
    /// </summary>
    public class Herbivores : Animal
    {
        public Herbivores(Playground playground):base(playground)
        {
        }

        public override void SpecialAnimalBehavior(List<Hunters> hunters, List<Herbivores> herbivores, IPlayground playground)
        {
            int xArraySize = playground.GetPlaygroundArray().GetLength(0);
            int yArraySize = playground.GetPlaygroundArray().GetLength(1);

            int idOfNearestHerbivores = FindClosestHunterIndex(hunters, xArraySize, yArraySize);

            if (idOfNearestHerbivores != -1)
            {
                MoveToTarget(hunters[idOfNearestHerbivores], (xArraySize, yArraySize));
            }
        }

        /// <summary>
        /// Method finds closest hunter.
        /// </summary>
        /// <param name="hunters"> List of hunters. </param>
        /// <param name="xArraySize"> Playground array size by X coordinate. </param>
        /// <param name="yArraySize"> Playground array size by Y coordinate. </param>
        /// <returns>int - closest hunter index. </returns>
        protected int FindClosestHunterIndex(List<Hunters> hunters, int xArraySize, int yArraySize)
        {
            int idOfNearestAnimal = -1;
            double distanceOfNearestAnimal = double.MaxValue;
            for (int index = 0; index < hunters.Count; index++)
            {
                double distance = DistanceBetweenToAnimalse(XPaygroundCoordinate, YPaygroundCoordinate, hunters[index].XPaygroundCoordinate, hunters[index].YPaygroundCoordinate, xArraySize, yArraySize);

                if (distance < distanceOfNearestAnimal)
                {
                    idOfNearestAnimal = index;
                    distanceOfNearestAnimal = distance;
                }
            }

            if (idOfNearestAnimal != -1 && distanceOfNearestAnimal > VisionRange)
            {
                return -1;
            }

            return idOfNearestAnimal;
        }

        /// <summary>
        /// Method move hunter closer to targer.
        /// </summary>
        /// <param name="hunter"> Hunter. </param>
        /// <param name="arraySize"> Array size (rows,columns) </param>
        protected void MoveToTarget(Hunters hunter, (int, int) arraySize)
        {
            int offsetX = IncreaseTheDistance(XPaygroundCoordinate, hunter.XPaygroundCoordinate, arraySize.Item1);
            int offsetY = IncreaseTheDistance(YPaygroundCoordinate, hunter.YPaygroundCoordinate, arraySize.Item2);

            XPaygroundCoordinate = GetModulNumber(XPaygroundCoordinate, offsetX, arraySize.Item1);
            YPaygroundCoordinate = GetModulNumber(YPaygroundCoordinate, offsetY, arraySize.Item2);
        }

        /// <summary>
        /// Method return change for coordinate, move points away each other.
        /// </summary>
        /// <param name="position"> Herbivore position. </param>
        /// <param name="target"> Hunter position. </param>
        /// <param name="arrayLenght"> Array length. </param>
        /// <returns> int - next coordinate shift. </returns>
        private int IncreaseTheDistance(int position, int target, int arrayLenght)
        {
            int returnNumberInRightSide = CalculatingDistance(position, target, arrayLenght);
            int returnNumberInLeftSide = CalculatingDistance(target, position, arrayLenght);

            if (returnNumberInLeftSide > returnNumberInRightSide)
            {
                return 1;
            }

            return -1;
        }

    }
}
