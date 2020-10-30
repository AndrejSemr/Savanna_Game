using AnimalsBase;
using System;
using System.Collections.Generic;

namespace Savanna
{
    /// <summary>
    /// Class for displaying information (console).
    /// </summary>
    public class UserUI : IUserUI
    {

        /// <summary>
        /// Method send a message to user.
        /// </summary>
        /// <param name="message"> Message to user. </param>
        public void SendMessageToUser(string message)
        {
            Console.WriteLine(message);
        }

        /// <summary>
        /// Method return pressed button.
        /// </summary>
        /// <returns> Pressed button. </returns>
        public ConsoleKey KeyLoger()
        {
            return Console.ReadKey().Key;
        }

        /// <summary>
        /// Methode display playground.
        /// </summary>
        /// <param name="gamePlayground"> Playground. </param>
        public void DisplayPlayground(IPlayground gamePlayground)
        {
            Console.Clear();
            Drow(gamePlayground.GetPlaygroundArray());
        }

        /// <summary>
        /// Displays number of hunters and herbivores on screen.
        /// </summary>
        /// <param name="numbersOfHunters"> Number of hunters. </param>
        /// <param name="numberfOfHerbivores"> Number of herbivores. </param>
        public void DisplayNumberOfHuntersAndHebrivores(int numbersOfHunters, int numberfOfHerbivores)
        {
            Console.WriteLine("Hunters: {0} \t Herbivores: {1}", numbersOfHunters, numberfOfHerbivores);
        }

        /// <summary>
        /// Displays information about animals.
        /// </summary>
        /// <param name="hunters"> List of hunters. </param>
        /// <param name="herbivores"> List of herbivores. </param>
        public void DisplayAnimalStatistics(List<Hunters> hunters, List<Herbivores> herbivores)
        {
            for (int index = 0; index < hunters.Count; index++)
            {
                Console.WriteLine("ID: {0} Animal: {1} \t Health: {2}", index, hunters[index].AnimalType, hunters[index].Health);
            }

            Console.WriteLine();

            for (int index = 0; index < herbivores.Count; index++)
            {
                Console.WriteLine("ID: {0} Animal: {1} \t Health: {2}", index, herbivores[index].AnimalType, herbivores[index].Health);
            }
        }

        /// <summary>
        /// Methods display playground.
        /// </summary>
        /// <param name="playgroundArray"> Playground array of chars</param>
        private void Drow(char[,] playgroundArray)
        {
            for (var row = 0; row < playgroundArray.GetLength(0); row++)
            {
                for (var column = 0; column < playgroundArray.GetLength(1); column++)
                {
                    Console.Write("{0,3}", playgroundArray[row, column]);
                }

                Console.WriteLine();
            }
        }

    }
}
