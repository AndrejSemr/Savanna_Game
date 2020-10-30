using AnimalsBase;
using System;
using System.Collections.Generic;

namespace Savanna.Savanna
{
    /// <summary>
    /// Interface provides necessary functionallity for Savanna class.
    /// </summary>
    public interface ISavanna
    {
        /// <summary>
        /// Add new Herbivore to Herbivores array.
        /// </summary>
        /// <param name="animal"> Herbivore animal. </param>
        public void AddHerbivores(Herbivores animal);

        /// <summary>
        /// Add new Hunter to Hunters array.
        /// </summary>
        /// <param name="animal"> Hunter animal. </param>
        public void AddHunters(Hunters animal);

        /// <summary>
        /// Method create a new animal based on pressed button.
        /// </summary>
        /// <param name="_playground"> Playground. </param>
        /// <param name="pressedButton"> Pressed button. </param>
        public void GeneratNewAnimals(int playgroundsNumberOfRows, int playgroundsNumberOfColumns, ConsoleKey pressedButton);

        /// <summary>
        /// Method simulates one iteration. 
        /// </summary>
        /// <param name="playground"> Playground. </param>
        public void Iteration(IPlayground playground);

        /// <summary>
        /// Updates Playground with new data.
        /// </summary>
        /// <param name="playground"> Playground. </param>
        public void UpdatePlayground(IPlayground playground);

        /// <summary>
        /// Method returns number of hunters and herbivores.
        /// </summary>
        /// <returns> (int,int)cortege - Number of hunters, number of hebrivores. </returns>
        public (int, int) NumbersOfAnimals();

        /// <summary>
        /// Method return list of hunters.
        /// </summary>
        /// <returns> List of hunters. </returns>
        public List<Hunters> GetListOfHunters();

        /// <summary>
        /// Method return list of herbivores.
        /// </summary>
        /// <returns> List of herbivores. </returns>
        public List<Herbivores> GetListOfHerbivores();

    }
}