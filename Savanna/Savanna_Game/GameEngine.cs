using System;
using System.Threading;

namespace Savanna.Savanna
{
    /// <summary>
    /// Class manages game.
    /// </summary>
    public class GameEngine
    {

        private IPlayground _playground = new Playground(20, 20);
        private IUserUI _userUI = new UserUI();
        private ISavanna _savanna = new SavannaEngine();

        /// <summary>
        /// Method start the game.
        /// </summary>
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
            ConsoleKey selectedOperation;

            do
            {
                selectedOperation = _userUI.KeyLoger();

                if (selectedOperation == ConsoleKey.Escape)
                {
                    break;
                }

                _savanna.GeneratNewAnimals(_playground.GetPlaygroundArray().GetLength(0),
                                           _playground.GetPlaygroundArray().GetLength(0),
                                           selectedOperation);
                _savanna.UpdatePlayground(_playground);

            } while (true);
        }

        /// <summary>
        /// Game loop.
        /// </summary>
        /// <param name="obj"> Null. </param>
        private void GameLifeCycle(object obj)
        {
            _savanna.Iteration(_playground);
            _savanna.UpdatePlayground(_playground);
            (int, int) cortege = _savanna.NumbersOfAnimals();

            _userUI.DisplayPlayground(_playground);
            _userUI.DisplayNumberOfHuntersAndHebrivores(cortege.Item1,cortege.Item2);
            _userUI.DisplayAnimalStatistics(_savanna.GetListOfHunters(), _savanna.GetListOfHerbivores());
        }

    }
}
