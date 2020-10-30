using AnimalsBase;
using System;
using System.Collections.Generic;

namespace Savanna
{
    public interface IUserUI
    {
        /// <summary>
        /// Method return pressed button.
        /// </summary>
        /// <returns> Pressed button. </returns>
        public ConsoleKey KeyLoger();

        /// <summary>
        /// Methode display playground.
        /// </summary>
        /// <param name="gamePlayground"> Playground. </param>
        public void DisplayPlayground(IPlayground gamePlayground);

        /// <summary>
        /// Displays number of hunters and herbivores on screen.
        /// </summary>
        /// <param name="numbersOfHunters"> Number of hunters. </param>
        /// <param name="numberfOfHerbivores"> Number of herbivores. </param>
        public void DisplayNumberOfHuntersAndHebrivores(int numbersOfHunters, int numberfOfHerbivores);

        /// <summary>
        /// Displays information about animals.
        /// </summary>
        /// <param name="hunters"> List of hunters. </param>
        /// <param name="herbivores"> List of herbivores. </param>
        public void DisplayAnimalStatistics(List<Hunters> hunters, List<Herbivores> herbivores);
    }
}
