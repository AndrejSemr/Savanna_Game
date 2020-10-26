
namespace Savanna
{
    using System;
    using System.Linq;

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
        /// Method wait that the User press one button from list.
        /// </summary>
        /// <returns> Button number from list. </returns>
        public int KeyLoger()
        {
            ConsoleKey pressedButtin;
            do
            {
                pressedButtin = Console.ReadKey().Key;

                if(pressedButtin == ConsoleKey.L)
                {
                    return 1;
                }

                if (pressedButtin == ConsoleKey.A)
                {
                    return 2;
                }

                if (pressedButtin == ConsoleKey.T)
                {
                    return 3;
                }

                if (pressedButtin == ConsoleKey.D)
                {
                    return 4;
                }

                if (pressedButtin == ConsoleKey.Q)
                {
                    return -1;
                }

                if (pressedButtin == ConsoleKey.W)
                {
                    return -2;
                }

            } while (pressedButtin != ConsoleKey.Escape);
            
            return 0;
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
        /// Methods display playground on console.
        /// </summary>
        /// <param name="playgroundArray"> Playground array</param>
        private void Drow(char[,] playgroundArray)
        {
            for (var i = 0; i < playgroundArray.GetLength(0); i++)
            {
                for (var j = 0; j < playgroundArray.GetLength(1); j++)
                {

                    Console.Write("{0,3}", playgroundArray[i,j] );
                }

                Console.WriteLine();
            }
        }

        /// <summary>
        /// Displays number of hunters and herbivores on screen.
        /// </summary>
        /// <param name="numbersOfHunters"> Number of hunters. </param>
        /// <param name="numberfOfHerbivores"> Number of herbivores. </param>
        public void DisplayNumberOfHuntersAndHebrivores(int numbersOfHunters, int numberfOfHerbivores)
        {
            Console.WriteLine("Hunters: {0} \t Herbivores: {1}",numbersOfHunters,numberfOfHerbivores);
        }
    }
}
