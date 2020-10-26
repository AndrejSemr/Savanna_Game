using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace Savanna.Savanna.Animals
{
    /// <summary>
    /// Class simulates a Herbivores.
    /// </summary>
    public class Herbivores : Animal
    {
        public Herbivores(IPlayground playground):base(playground)
        {
            maximumHealth = 50;
            Health = maximumHealth;
            VisionRange = 3;
        }

        public Herbivores(IPlayground playground, int currentPositionX, int currentPositionY, int rangeX, int rangeY)
                : base(playground, currentPositionX, currentPositionY, rangeX, rangeY)
        {
        }

        /// <summary>
        /// Special method realisation: Herbivores try to avoid hunters. 
        /// </summary>
        /// <param name="hunters"> List of hunters. </param>
        /// <param name="herbivores"> List of herbivores. </param>
        /// <param name="playground"> Playground array. </param>
        public override void SpecialAnimalBehavior(List<Hunters> hunters, List<Herbivores> herbivores, IPlayground playground)
        {
            int xArraySize = playground.GetPlaygroundArray().GetLength(0);
            int yArraySize = playground.GetPlaygroundArray().GetLength(1);

            int idOfNearestHunter = FindClosestAnumalIndex(hunters, xArraySize, yArraySize,false);

            if (idOfNearestHunter != -1)
            {
                //Spet(hunters[idOfNearestHunter], (xArraySize, yArraySize), false);
                Spet(hunters[idOfNearestHunter], playground, false);
            }

            CheckedBirthday(herbivores);

            DecreaseEnergyParDay();
        }



        public void CheckedBirthday(List<Herbivores> h)
        {
            int idOfNearestHerbivores = FindClosestAnumalIndexByType(h, 20, 20, AnimalType);

            if (idOfNearestHerbivores != -1)
            {
                double closestHerbivores = DistanceBetweenToAnimalse(
                    XPaygroundCoordinate,
                    YPaygroundCoordinate,
                    h[idOfNearestHerbivores].XPaygroundCoordinate, 
                    h[idOfNearestHerbivores].YPaygroundCoordinate,
                    20,20);

                if (closestHerbivores < 1.4143)
                {
                    TimeToGiveBorth++;
                    System.Console.WriteLine("ID: {0} -> ID:{1} Dist: {2} TTGB:{3}",
                                        "tmp",idOfNearestHerbivores, closestHerbivores, TimeToGiveBorth);
                }
                else
                {
                    TimeToGiveBorth = 0;
                }
            }
        }
    }
}
