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

        public void DisplayNumberOfHuntersAndHebrivores(int numbersOfHunters, int numberfOfHerbivores);
    }
}
