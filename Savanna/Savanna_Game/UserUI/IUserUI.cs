using System;
using System.Collections.Generic;
using System.Text;

namespace Savanna
{
    public interface IUserUI
    {
        /// <summary>
        /// Method wait that the User press one button from list.
        /// </summary>
        /// <param name="exitButtin"> Pressed key from list. </param>
        public int KeyLoger();

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
    }
}
