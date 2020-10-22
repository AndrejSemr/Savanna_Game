
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
        /// <param name="exitButtin"> Pressed key from list. </param>
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

                if (pressedButtin == ConsoleKey.D)
                {
                    return -1;
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
        private void Drow(int[,] playgroundArray)
        {
            for (var i = 0; i < playgroundArray.GetLength(0); i++)
            {
                for (var j = 0; j < playgroundArray.GetLength(1); j++)
                {

                    Console.Write("{0,3}", WitchAnumalToDisplay(playgroundArray[i,j]) );
                }

                Console.WriteLine();
            }
        }

        /// <summary>
        /// Method store animal 'lables' and numbers.
        /// </summary>
        /// <param name="animalNumber"> Animal number. </param>
        /// <returns> string - Animal 'lable' on playground. </returns>
        private string WitchAnumalToDisplay(int animalNumber)
        {
            switch (animalNumber)
            {
                case (1):
                    return "L";
                
                case (2):
                    return "A";

                default:
                    return ".";
            }
        }

        public void DisplayNumberOfHuntersAndHebrivores(int numbersOfHunters, int numberfOfHerbivores)
        {
            Console.WriteLine("Hunters: {0} \t Herbivores: {1}",numbersOfHunters,numberfOfHerbivores);
        }
    }
}
