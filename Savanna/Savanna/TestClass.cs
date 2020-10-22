using System;
using System.Collections.Generic;
using System.Text;

namespace Savanna.Savanna
{
    public class TestClass
    {
        public double DistanceBetweenToPoints(int x, int y, int xTarget, int yTatget,int xArraySize, int yArraySize)
        {
            int distanceByX = LaTestModulNumber(x,xTarget, xArraySize);
            int distanceByY = LaTestModulNumber(y, yTatget, yArraySize);
            return Math.Sqrt(Math.Pow(distanceByX, 2) + Math.Pow(distanceByY, 2));
        }


        private int LaTestModulNumber(int position, int target, int arrayLenght)
        {
            int returnNumberInRightSide;
            int returnNumberInLeftSide;

            returnNumberInRightSide = ( (position - target) + arrayLenght) % arrayLenght;
            returnNumberInLeftSide =  ( (target - position)  + arrayLenght) % arrayLenght;
            if (returnNumberInRightSide < returnNumberInLeftSide) return returnNumberInRightSide;
            return returnNumberInLeftSide;
        }

        public void PrintArr(int[,] arr)
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                    Console.Write(" {0} ", arr[i, j]);
                Console.WriteLine();
            }

        }
    }
}
