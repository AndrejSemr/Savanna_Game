﻿using Savanna.Savanna.Animals;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

namespace Savanna.Savanna
{
    /// <summary>
    /// Class managing the game.
    /// </summary>
    public class GameEngine
    {

        private IPlayground _playground = new Playground(20, 20);
        private IUserUI _userUI = new UserUI();
        private ISavanna _savanna = new SavannaEngine();

        /// <summary>
        /// Method start the game.
        /// </summary>
        /// https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/attributes/creating-custom-attributes
        public void Start()
        {

           _userUI.DisplayPlayground(_playground);

            TimerCallback tm = new TimerCallback(GameLifeCycle);
            Timer timer = new Timer(tm, null, 0, 1000);

            KeyLoger();
            timer.Dispose();
        }

        /// <summary>
        /// Method captures special keys from keyboard.
        /// </summary>
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

                _savanna.GeneratNewAnimals(_playground ,selectedOperation);
                _savanna.SetNewPlayground(_playground);

            } while (true);
        }

        /// <summary>
        /// Game loop.
        /// </summary>
        /// <param name="obj"> null. </param>
        private void GameLifeCycle(object obj)
        {
            _savanna.Iteration(_playground);
            _savanna.SetNewPlayground(_playground);
            (int, int) cortege = _savanna.NumbersOfAnimals();

            _userUI.DisplayPlayground(_playground);
            _userUI.DisplayNumberOfHuntersAndHebrivores(cortege.Item1,cortege.Item2);
        }
    }
}
