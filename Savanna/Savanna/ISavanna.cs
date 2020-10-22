using Savanna.Savanna.Animals;

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
        /// Method create a new animal based on animal number.
        /// </summary>
        /// <param name="animalNumber"> Anumal number. </param>
        public void GeneratNewAnimals(IPlayground _playground, int animalNumber);

        /// <summary>
        /// Method simulates one iteration. 
        /// </summary>
        /// <param name="playground"> Playground. </param>
        public void Iteration(IPlayground playground);

        /// <summary>
        /// Updates Playground with new data.
        /// </summary>
        /// <param name="playground"> Playground. </param>
        public void SetNewPlayground(IPlayground playground);

        /// <summary>
        /// Method returns number of hunters and herbivores.
        /// </summary>
        /// <returns> (int,int)cortege - Number of hunters, number of hebrivores. </returns>
        public (int, int) NumbersOfAnimals();
    }
}