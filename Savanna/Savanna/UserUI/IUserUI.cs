using System;
using System.Collections.Generic;
using System.Text;

namespace Savanna
{
    public interface IUserUI
    {
        /// <summary>
        /// Method wait for specified key to be pressed.
        /// </summary>
        /// <param name="exitButtin"> Key that should be pressed. </param>
        public int KeyLoger();

        public void DisplayPlayground(IPlayground gamePlayground);
    }
}
