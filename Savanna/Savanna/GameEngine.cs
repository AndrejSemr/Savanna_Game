using Savanna;
using Savanna.Playground;
using Savanna.Savanna.Animals;
using System;
using System.Collections.Generic;
using System.Text;

namespace Savanna.Savanna
{
    /// <summary>
    /// Class managing the game.
    /// </summary>
    public class GameEngine
    {

        private Playground.Playground _playground = new Playground.Playground(10, 20);
        private UserUI _userUI = new UserUI();
        private Savanna _savanna = new Savanna();
        /// <summary>
        /// Method start the game.
        /// </summary>
        public void Start()
        {
           
            _userUI.DisplayPlayground(_playground);
            KeyLoger();
        }

        public void KeyLoger()
        {
            int selectedOperation;
            do
            {
                selectedOperation = _userUI.KeyLoger();
                if(selectedOperation == 0)
                {
                    break;
                }

                GenerationNewAnimals(selectedOperation);
                _savanna.SetNewPlayground(_playground);
                _userUI.DisplayPlayground(_playground);
                _savanna.NumbersOfAnimals();
            } while (true);
        }

        public void GenerationNewAnimals(int animalNumber)
        {
            switch (animalNumber)
            {
                case 1:
                    _savanna.AddHerbivore(new Lion(_playground));
                    break;
                case 2:
                    _savanna.AddPredator(new Antelope(_playground));
                    break;
                case -1:
                    _savanna.Iteration(_playground);
                    break;
            }
        }
    }
}
