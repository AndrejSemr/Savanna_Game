using System;
using System.Collections.Generic;
using System.Linq;
using Savanna;
using Savanna.Savanna.Animals;

namespace Savanna.Savanna
{
    /// <summary>
    /// Class simulated savanna.
    /// </summary>
    public class Savanna : ISavanna
    {
        public List<Hunters> hunters = new List<Hunters>();
        public List<Herbivores> hebrivores = new List<Herbivores>();

        /// <summary>
        /// Add new Hunter to Hunters array.
        /// </summary>
        /// <param name="animal"> Hunter animal. </param>
        public void AddHunters(Hunters animal)
        {
            hunters.Add(animal);
        }

        /// <summary>
        /// Add new Herbivore to Herbivores array.
        /// </summary>
        /// <param name="animal"> Herbivore animal. </param>
        public void AddHerbivores(Herbivores animal)
        {
            hebrivores.Add(animal);
        }

        /// <summary>
        /// Method create a new animal based on animal number.
        /// </summary>
        /// <param name="animalNumber"> Anumal number. </param>
        public void GeneratNewAnimals(IPlayground _playground, int animalNumber)
        {
            switch (animalNumber)
            {
                case 1:
                    AddHunters(new Lion(_playground));
                    break;
                case 2:
                    AddHerbivores(new Antelope(_playground));
                    break;


                /// DELETE AFTER TESTS
                case -1:
                    Iteration(_playground);
                    break;
            }
        }

        /// <summary>
        /// Method returns number of hunters and herbivores.
        /// </summary>
        /// <returns> (int,int)cortege - Number of hunters, number of hebrivores. </returns>
        public (int,int) NumbersOfAnimals()
        {
            return (Hunters: hunters.Count, Hebrivores: hebrivores.Count);
        }

        /// <summary>
        /// Method simulates one iteration. 
        /// </summary>
        /// <param name="playground"> Playground. </param>
        public void Iteration(IPlayground playground)
        {
            int xArraySize = playground.GetPlaygroundArray().GetLength(0);
            int yArraySize = playground.GetPlaygroundArray().GetLength(1);

            for (int i = 0; i < hunters.Count; i++)
            {
                hunters[i].SpecialAnimalBehavior(hunters, hebrivores, playground);
            }

            for (int i = 0; i < hebrivores.Count; i++)
            {
                hebrivores[i].SpecialAnimalBehavior(hunters, hebrivores, playground);
            }

            AnimalHealthCheck();
        }

        /// <summary>
        /// Updates Playground with new data.
        /// </summary>
        /// <param name="playground"> Playground. </param>
        public void SetNewPlayground(IPlayground playground)
        {
            playground.ZerroArray();

            for (int index = 0; index < hebrivores.Count; index++)
            {
                int x = hebrivores[index].XPaygroundCoordinate;
                int y = hebrivores[index].YPaygroundCoordinate;
                playground.SetValue(x, y, 2);
            }

            for (int index = 0; index < hunters.Count; index++)
            {
                int x = hunters[index].XPaygroundCoordinate;
                int y = hunters[index].YPaygroundCoordinate;
                playground.SetValue(x, y, 1);
            }
        }

        /// <summary>
        /// Method checks animals health.
        /// </summary>
        private void AnimalHealthCheck()
        {
            for (int i = 0; i < hunters.Count; i++)
            {
                if (hunters[i].Health <= 0)
                {
                    hunters.RemoveAt(i);
                }
            }

            for (int i = 0; i < hebrivores.Count; i++)
            {
                if (hebrivores[i].Health <= 0)
                {
                    hebrivores.RemoveAt(i);
                }
            }
        }
    }
}
