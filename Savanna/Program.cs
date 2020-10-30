using Savanna.Savanna;

namespace Savanna
{
    public class Program
    {

        /// <summary>
        /// Method starts the game.
        /// </summary>
        static void Main(string[] args)
        {
            GameEngine gameEngine = new GameEngine();
            gameEngine.Start();
        }
    }
}


//ok  Iteration 1 Requirements
//ok  1.Console application
//ok  2.Pressing button A and L add animals to field
//ok  3. Two animal types: Antelope and Lion
//ok  4. Animals moving on field and try:
//ok      a.Antelope to avoid lion
//ok      b. Lion to catch and eat antelope
//ok  5. Each animal take portion of time from game engine to make move and special action
//ok  6. Each animal has vision range and moves based on it

//  Iteration 2 Requirements
//  1.Add health metric for each animal
//ok  2. Decrease 0.5 health on each move
//ok  3. Increase health when eat antelope
//ok  4. Add Die function due lack of health
//  5. Birth function when 2 animals near for 3 rounds
