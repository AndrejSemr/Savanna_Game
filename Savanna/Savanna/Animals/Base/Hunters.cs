using Savanna.Playground;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Savanna.Savanna.Animals
{
    /// <summary>
    /// Class simulates a herbivore.
    /// </summary>
    public class Hunters : Animal
    {
        public Hunters(Playground.Playground playground) :base(playground)
        {
            Health = 100.0;
            VisionRange = 5;
        }

        public bool IsAnPredatorInVisionRange(int[,] playground)
        {
            return true;
        }



        public virtual void RRR()
        {
            Console.WriteLine("R");
        }
    }
}
