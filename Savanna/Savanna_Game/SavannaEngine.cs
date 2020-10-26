using System.Collections;
using System.Collections.Generic;
using Savanna.Savanna.Animals;
using Savanna.Savanna_Game.Animals;

namespace Savanna.Savanna
{
    /// <summary>
    /// Class simulated savanna.
    /// </summary>
    public class SavannaEngine : ISavanna
    {
        public List<Hunters> hunters = new List<Hunters>();
        public List<Herbivores> hebrivores = new List<Herbivores>();

        private int _huntersLimit = 20;
        private int _hebrivoresLimit = 30;

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
        /// Method returns number of hunters and herbivores.
        /// </summary>
        /// <returns> (int,int)cortege - Number of hunters, number of hebrivores. </returns>
        public (int, int) NumbersOfAnimals()
        {
            return (hunters.Count, hebrivores.Count);
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
                case 3:
                    AddHunters(new Tiger(_playground));
                    break;
                case 4:
                    //AddHerbivores(new AnimalDllCreator.Deer(_playground));
                    break;


                /// DELETE AFTER TESTS
                case -1:
                    Antelope antelope1 = new Antelope(_playground) { XPaygroundCoordinate = 2, YPaygroundCoordinate = 2 };
                    Antelope antelope2 = new Antelope(_playground) { XPaygroundCoordinate = 1, YPaygroundCoordinate = 2 };

                    AddHerbivores(antelope1);
                    AddHerbivores(antelope2);

                    break;

                case -2:

                    Lion lion1 = new Lion(_playground) { XPaygroundCoordinate = 7, YPaygroundCoordinate = 1 };
                    Lion lion2 = new Lion(_playground) { XPaygroundCoordinate = 8, YPaygroundCoordinate = 1 };

                    AddHunters(lion1);
                    AddHunters(lion2);

                    break;
            }
        }

        /// <summary>
        /// Method simulates one iteration. 
        /// </summary>
        /// <param name="playground"> Playground. </param>
        public void Iteration(IPlayground playground)
        {
            int xArraySize = playground.GetPlaygroundArray().GetLength(0);
            int yArraySize = playground.GetPlaygroundArray().GetLength(1);

            int huntersBirth = 0;
            int hebrivoresBirth = 0;

            for (int i = 0; i < hunters.Count; i++)
            {
                hunters[i].SpecialAnimalBehavior(hunters, hebrivores, playground);

                if ((hunters[i].TimeToGiveBorth == 3) && (hunters.Count < _huntersLimit))
                {
                    hunters[i].TimeToGiveBorth = 0;
                    huntersBirth++;
                }
            }

            for (int index = 0; index < hebrivores.Count; index++)
            {
                hebrivores[index].SpecialAnimalBehavior(hunters, hebrivores, playground);

                if ((hebrivores[index].TimeToGiveBorth >= 3) && (hebrivores.Count <= _hebrivoresLimit))
                {
                    hebrivores[index].TimeToGiveBorth = 0;
                    hebrivoresBirth++;
                    
                }
            }

            Birthday(playground, huntersBirth, true);
            Birthday(playground, hebrivoresBirth, false);

            AnimalHealthCheck();
        }

        protected void Birthday(IPlayground playground,int counter,bool isHunter)
        {
            counter = (counter / 2);
            for (int index = 0; index < counter; index++)
            {
                if (isHunter)
                {
                    Lion lion = new Lion(playground);
                    AddHunters(lion);
                }
                else
                {
                    Antelope antelope = new Antelope(playground);
                    AddHerbivores(antelope);
                }
            }
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

                playground.SetValue(x, y, hebrivores[index].AnimalTypeLabel);
            }

            for (int index = 0; index < hunters.Count; index++)
            {
                int x = hunters[index].XPaygroundCoordinate;
                int y = hunters[index].YPaygroundCoordinate;

                playground.SetValue(x, y, hunters[index].AnimalTypeLabel);
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
