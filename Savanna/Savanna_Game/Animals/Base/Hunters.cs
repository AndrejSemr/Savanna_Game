using System.Collections.Generic;
using System.Collections.Specialized;

namespace Savanna.Savanna.Animals
{

    /// <summary>
    /// Class simulates a hunters.
    /// </summary>
    public class Hunters : Animal
    {
        /// <summary>
        /// Constructor for hunters.
        /// </summary>
        /// <param name="playground"></param>
        public Hunters(IPlayground playground) : base(playground)
        {
            maximumHealth = 30;
            Health = maximumHealth;
            VisionRange = 5;
        }

        public Hunters(IPlayground playground, int currentPositionX, int currentPositionY, int rangeX, int rangeY)
                :base(playground, currentPositionX, currentPositionY, rangeX, rangeY)
        {
        }

        /// <summary>
        /// Special method realisation: Hunters trying catch and eat herbivores.
        /// </summary>
        /// <param name="hunters"> List of hunters. </param>
        /// <param name="herbivores"> List of herbivores. </param>
        /// <param name="playground"> Playground array. </param>
        public override void SpecialAnimalBehavior(List<Hunters> hunters, List<Herbivores> herbivores, IPlayground playground)
        {
            int xArraySize = playground.GetPlaygroundArray().GetLength(0);
            int yArraySize = playground.GetPlaygroundArray().GetLength(1);

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
                    //Spet(herbivores[idOfNearestHerbivores], (xArraySize, yArraySize),true);
                    Spet(herbivores[idOfNearestHerbivores], playground, true);
                }
            }

            CheckedBirthday(hunters);

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


        public void CheckedBirthday(List<Hunters> h)
        {
            int idOfNearestHerbivores = FindClosestAnumalIndexByType(h, 20, 20, AnimalType);
            if (idOfNearestHerbivores != -1)
            {
                double closestHerbivores = DistanceBetweenToAnimalse(XPaygroundCoordinate, YPaygroundCoordinate, h[idOfNearestHerbivores].XPaygroundCoordinate, h[idOfNearestHerbivores].YPaygroundCoordinate, 20, 20);
                if (closestHerbivores < 1.4143)
                {
                    TimeToGiveBorth++;
                    System.Console.WriteLine("Triger");
                }
                else
                {
                    TimeToGiveBorth = 0;
                }

            }

        }
    }
}
