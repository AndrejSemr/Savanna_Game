using System;
using System.Collections.Generic;
using Animal;
using AnimalsBase;

namespace Savanna.Savanna
{
    /// <summary>
    /// Class simulates savanna.
    /// </summary>
    public class SavannaEngine : ISavanna
    {
        private List<Hunters> _hunters = new List<Hunters>();
        private List<Herbivores> _hebrivores = new List<Herbivores>();
        private TypeKeeper _typeKeeper = new TypeKeeper();

        private int _maximumNumberOfHunters = 20;
        private int _maximumNumberOfHebrivores = 30;

        #region ListsGeters;

        /// <summary>
        /// Method return list of hunters.
        /// </summary>
        /// <returns> List of hunters. </returns>
        public List<Hunters> GetListOfHunters()
        {
            return _hunters;
        }

        /// <summary>
        /// Method return list of herbivores.
        /// </summary>
        /// <returns> List of herbivores. </returns>
        public List<Herbivores> GetListOfHerbivores()
        {
            return _hebrivores;
        }

        #endregion;

        /// <summary>
        /// Add new Hunter to Hunters array.
        /// </summary>
        /// <param name="animal"> Hunter animal. </param>
        public void AddHunters(Hunters animal)
        {
            if(_hunters.Count <= _maximumNumberOfHunters)
            {
                _hunters.Add(animal);
            }
        }

        /// <summary>
        /// Add new Herbivore to Herbivores array.
        /// </summary>
        /// <param name="animal"> Herbivore animal. </param>
        public void AddHerbivores(Herbivores animal)
        {
            if(_hebrivores.Count <= _maximumNumberOfHebrivores)
            {
                _hebrivores.Add(animal);
            }
        }

        /// <summary>
        /// Method returns number of hunters and herbivores.
        /// </summary>
        /// <returns> Number of hunters, number of hebrivores. </returns>
        public (int, int) NumbersOfAnimals()
        {
            return (_hunters.Count, _hebrivores.Count);
        }

        /// <summary>
        /// Method create a new animal based on pressed button.
        /// </summary>
        /// <param name="playgroundsNumberOfRows"> Playgrounds number of rows. </param>
        /// <param name="playgroundsNumberOfColumns"> Playgrounds number of columns. </param>
        /// <param name="pressedButton"> Pressed button. </param>
        public void GeneratNewAnimals(int playgroundsNumberOfRows, int playgroundsNumberOfColumns, ConsoleKey pressedButton)
        {
            Type animalType;
            bool isSelectedItemInDictionary = _typeKeeper.typeDictionary.TryGetValue(pressedButton, out animalType);

            if (isSelectedItemInDictionary)
            {
                AddAnumalToList(animalType, playgroundsNumberOfRows, playgroundsNumberOfColumns);
            }
        }

        /// <summary>
        /// Method creates a new animal by type and adds it to List.
        /// </summary>
        /// <param name="animalType"> Animal type. </param>
        /// <param name="numberOfRows"> Playgrounds number of rows. </param>
        /// <param name="numberOfColumns"> Playgrounds  number of columns. </param>
        private void AddAnumalToList(Type animalType, int numberOfRows, int numberOfColumns)
        {
            object instanceOfAnimal = Activator.CreateInstance(animalType, numberOfRows, numberOfColumns);

            if (animalType.BaseType.Name.ToString() == "Hunters")
            {
                Hunters hunters = (Hunters)instanceOfAnimal;
                AddHunters(hunters);
            }
            else
            {
                Herbivores herbivores = (Herbivores)instanceOfAnimal;
                AddHerbivores(herbivores);
            }
        }

        /// <summary>
        /// Method simulates one iteration.
        /// </summary>
        /// <param name="playground"> Playground. </param>
        public void Iteration(IPlayground playground)
        {
            int numberOfRows = playground.GetPlaygroundArray().GetLength(0);
            int numberOfColumns = playground.GetPlaygroundArray().GetLength(1);

            for (int index = 0; index < _hunters.Count; index++)
            {
                _hunters[index].SpecialAnimalBehavior(_hunters, _hebrivores, playground.GetPlaygroundArray());

                if ((_hunters[index].TimeToGiveBorth >= 3) && (_hunters.Count < _maximumNumberOfHunters))
                {
                    _hunters[index].TimeToGiveBorth = 0;
                    AddAnumalToList(_hunters[index].GetType(), numberOfRows, numberOfColumns);
                }
            }

            for (int index = 0; index < _hebrivores.Count; index++)
            {
                _hebrivores[index].SpecialAnimalBehavior(_hunters, _hebrivores, playground.GetPlaygroundArray());

                if ((_hebrivores[index].TimeToGiveBorth >= 3) && (_hebrivores.Count <= _maximumNumberOfHebrivores))
                {
                    _hebrivores[index].TimeToGiveBorth = 0;
                    AddAnumalToList(_hebrivores[index].GetType(), numberOfRows, numberOfColumns);
                }
            }

            AnimalHealthCheck();
        }


        /// <summary>
        /// Updates Playground with new data.
        /// </summary>
        /// <param name="playground"> Playground. </param>
        public void UpdatePlayground(IPlayground playground)
        {
            playground.ZerroArray();

            for (int index = 0; index < _hebrivores.Count; index++)
            {
                int x = _hebrivores[index].XPaygroundCoordinate;
                int y = _hebrivores[index].YPaygroundCoordinate;

                playground.SetValue(x, y, _hebrivores[index].AnimalTypeLabel);
            }

            for (int index = 0; index < _hunters.Count; index++)
            {
                int x = _hunters[index].XPaygroundCoordinate;
                int y = _hunters[index].YPaygroundCoordinate;

                playground.SetValue(x, y, _hunters[index].AnimalTypeLabel);
            }
        }

        /// <summary>
        /// Method checks animals health.
        /// </summary>
        private void AnimalHealthCheck()
        {
            for (int index = 0; index < _hunters.Count; index++)
            {
                if (_hunters[index].Health <= 0)
                {
                    _hunters.RemoveAt(index);
                }
            }

            for (int index = 0; index < _hebrivores.Count; index++)
            {
                if (_hebrivores[index].Health <= 0)
                {
                    _hebrivores.RemoveAt(index);
                }
            }
        }

    }
}
