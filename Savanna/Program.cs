using Savanna.Savanna;
using System;
using System.Security.Cryptography.X509Certificates;

namespace Savanna
{
    public class Program
    {

        /// <summary>
        /// Method starts the game.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            GameEngine gameEngine = new GameEngine();
            gameEngine.Start();
        }
    }
}