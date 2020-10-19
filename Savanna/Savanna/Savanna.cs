using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Savanna.Playground;
using Savanna.Savanna.Animals;

namespace Savanna.Savanna
{
    public class Savanna
    {
        public List<Hunters> carnivores = new List<Hunters>();
        public List<Herbivores> predators = new List<Herbivores>();

        /// <summary>
        /// Add new Herbivore to Herbivores array.
        /// </summary>
        /// <param name="animal"> Herbivore animal. </param>
        public void AddHerbivore(Hunters animal)
        {
            carnivores.Add(animal);
        }

        /// <summary>
        /// Add new Predator to Predators array.
        /// </summary>
        /// <param name="animal"> Predator animal. </param>
        public void AddPredator(Herbivores animal)
        {
            predators.Add(animal);
        }

        public void NumbersOfAnimals()
        {
            Console.WriteLine("Herbivers: {0} \t Predator: {1}",carnivores.Count, predators.Count);
        }

        /// <summary>
        /// Method simulate one itaration. 
        /// </summary>
        /// <param name="playground"> Playground. </param>
        public void Iteration(Playground.Playground playground)
        {
            HunterCaughtUpVictim(playground);
        }

        /// <summary>
        /// Uppdate Playground with new data.
        /// </summary>
        /// <param name="playground"> Playground. </param>
        public void SetNewPlayground(Playground.Playground playground)
        {
            playground.ZerroArray();

            for (int index = 0; index < predators.Count; index++)
            {
                int x = predators[index].XPaygroundCoordinate;
                int y = predators[index].YPaygroundCoordinate;
                playground.PlaygroundGrid[x,y] = 2;
            }

            for (int index = 0; index < carnivores.Count; index++)
            {
                int x = carnivores[index].XPaygroundCoordinate;
                int y = carnivores[index].YPaygroundCoordinate;
                playground.PlaygroundGrid[x, y] = 1;
            }
        }
        ////////////////////////////////////////////

        #region HunterCaughtUpVictimRegion

        /// <summary>
        /// Hunter eats victim if he/she is close (1 block).
        /// </summary>
        /// <param name="playground"></param>
        private void HunterCaughtUpVictim(Playground.Playground playground)
        {
            for (int index = 0; index < carnivores.Count; index++)
            {
                int predator_x = 0;
                int predator_y = 0;
                int carnivores_x = carnivores[index].XPaygroundCoordinate;
                int carnivores_y = carnivores[index].YPaygroundCoordinate;

                if (IsAnPredatorCaught(playground.GetPlaygroundArray(), carnivores_x, carnivores_y, out predator_x, out predator_y))
                {
                    carnivores[index].Health = 100;

                    int predatorIndex = predators.FindIndex(
                        elem => elem.XPaygroundCoordinate == predator_x
                        &&
                        elem.YPaygroundCoordinate == predator_y
                        );
                    predators.RemoveAt(predatorIndex);
                }
            }
        }

        /// <summary>
        /// Mehod checks if hunter caught victim.
        /// </summary>
        /// <param name="playground"> Playground. </param>
        /// <param name="carnivores_x"> Hunter X coordinat. </param>
        /// <param name="carnivores_y"> Hunter Y coordinat. </param>
        /// <param name="predators_x"> Predator X coordinat if he/she is caught.</param>
        /// <param name="predators_y"> Predator Y coordinat if he/she is caught.</param>
        /// <returns> bool - True if predator is caught. </returns>
        private bool IsAnPredatorCaught(int[,] playgroundArray, int x_coord, int y_coord, out int predators_x, out int predators_y)
        {

            for (int row = -1; row < 2; row++)
            {
                for (int column = -1; column < 2; column++)
                {
                    int x = GetModulNumber(x_coord, row, playgroundArray.GetLength(0));
                    int y = GetModulNumber(y_coord, column, playgroundArray.GetLength(1));

                    if(playgroundArray[x, y] == 2)
                    {
                        predators_x = x;
                        predators_y = y;
                        return true;
                    }
                }
            }

            predators_x = -1;
            predators_y = -1;
            return false;
        }

        #endregion;

        /// <summary>
        /// Method return modul number to avoid going out of array.
        /// </summary>
        /// <param name="coord"> Current position.</param>
        /// <param name="offset"> Offset/next coordinate to check. </param>
        /// <param name="arrayLenght"> Array size/lenght/border. </param>
        /// <returns> int - Next cell coordinate. </returns>
        private int GetModulNumber(int coord, int offset, int arrayLenght)
        {
            return (coord + offset + arrayLenght) % arrayLenght;
        }
    }
}
