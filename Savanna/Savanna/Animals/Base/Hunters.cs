using System.Collections.Generic;

namespace Savanna.Savanna.Animals
{

    /// <summary>
    /// Class simulates a herbivore.
    /// </summary>
    public class Hunters : Animal
    {
        public Hunters(IPlayground playground) :base(playground)
        {
            Health = 100.0;
            VisionRange = 5;
        }

        public bool IsAnPredatorInVisionRange(int[,] playground)
        {
            return true;
        }

        public override void SpecialAnimalBehavior(List<Hunters> hunters, List<Herbivores> herbivores, IPlayground playground)
        {
            int xArraySize = playground.GetPlaygroundArray().GetLength(0);
            int yArraySize = playground.GetPlaygroundArray().GetLength(1);

            int idOfNearestHerbivores = FindClosestHerbivoresIndex(herbivores, xArraySize, yArraySize);
            
            if(idOfNearestHerbivores != -1)
            {
                double distance = DistanceBetweenToAnimalse(XPaygroundCoordinate, YPaygroundCoordinate, herbivores[idOfNearestHerbivores].XPaygroundCoordinate, herbivores[idOfNearestHerbivores].YPaygroundCoordinate, xArraySize, yArraySize);
                if (distance < 1.4143)
                {
                    EatTarget(herbivores, idOfNearestHerbivores);
                }
                else
                {
                    MoveToTarget(herbivores[idOfNearestHerbivores], (xArraySize, yArraySize));
                }
            }

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
        /// Method finds closest herbivores.
        /// </summary>
        /// <param name="hunters"> List of herbivores. </param>
        /// <param name="xArraySize"> Playground array size by X coordinate. </param>
        /// <param name="yArraySize"> Playground array size by Y coordinate. </param>
        /// <returns>int - closest hunter index. </returns>
        protected int FindClosestHerbivoresIndex(List<Herbivores> herbivores, int xArraySize, int yArraySize)
        {
            int idOfNearestAnimal = -1;
            double distanceOfNearestAnimal = double.MaxValue;
            for (int index = 0; index < herbivores.Count; index++)
            {
                double distance = DistanceBetweenToAnimalse(XPaygroundCoordinate, YPaygroundCoordinate, herbivores[index].XPaygroundCoordinate, herbivores[index].YPaygroundCoordinate, xArraySize, yArraySize);

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
        /// <param name="herbivore"> Herbivore. </param>
        /// <param name="arraySize"> Array size (rows,columns) </param>
        protected void MoveToTarget(Herbivores herbivore,(int,int)arraySize)
        {
            int offsetX = ShortenTheDistance(XPaygroundCoordinate, herbivore.XPaygroundCoordinate, arraySize.Item1);
            int offsetY = ShortenTheDistance(YPaygroundCoordinate, herbivore.YPaygroundCoordinate, arraySize.Item2);

            XPaygroundCoordinate = GetModulNumber(XPaygroundCoordinate, offsetX, arraySize.Item1);
            YPaygroundCoordinate = GetModulNumber(YPaygroundCoordinate, offsetY, arraySize.Item2);
        }

        /// <summary>
        /// Method return change for coordinate, brings points closer.
        /// </summary>
        /// <param name="position"> Hunter position. </param>
        /// <param name="target"> Target position. </param>
        /// <param name="arrayLenght"> Array length. </param>
        /// <returns> int - next coordinate shift. </returns>
        private int ShortenTheDistance(int position, int target, int arrayLenght)
        {
            int returnNumberInRightSide = CalculatingDistance(position, target, arrayLenght);
            int returnNumberInLeftSide  = CalculatingDistance(target, position, arrayLenght);

            if (returnNumberInLeftSide > returnNumberInRightSide)
            {
                return -1;
            }

            return 1;
        }

    }
}
