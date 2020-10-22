using Savanna;
using System;
using System.Collections.Generic;
using System.Text;

namespace Savanna.Savanna.Animals
{
    /// <summary>
    /// Abstract class for all animals.
    /// </summary>
    public abstract class Animal : PositionOnPlayground
    {
        /// <summary>
        /// Animal health metric.
        /// </summary>
        public double Health { get; set; }
        
        /// <summary>
        /// Animal vision range.
        /// </summary>
        public int VisionRange { get; set; }

        /// <summary>
        /// Animal constructor.
        /// </summary>
        /// <param name="playground"> Playground. </param>
        public Animal(Playground playground)
        {
            Random random = new Random();
            int arrayXSize = playground.GetPlaygroundArray().GetLength(0);
            int arrayYSize = playground.GetPlaygroundArray().GetLength(1);
            int newXCoord;
            int newYCoord;
            bool coodinateIsOk = false;

            while (!coodinateIsOk)
            {
                newXCoord = random.Next(0, arrayXSize);
                newYCoord = random.Next(0, arrayYSize);

                if(playground.PlaygroundGrid[newXCoord, newYCoord] == 0)
                {
                    XPaygroundCoordinate = newXCoord;
                    YPaygroundCoordinate = newYCoord;
                    coodinateIsOk = true;
                }
            }


        }

        public virtual void SpecialAction(List<Hunters> hunters,List<Herbivores> herbivores, int xArraySize, int yArraySize)
        {
            
        }

        /// <summary>
        /// Method lowers the animal health.
        /// </summary>
        public void DecreaseEnergyParDay()
        {
            Health = Health-0.5;
        }

        /// <summary>
        /// Method finds a short distance between animals.
        /// </summary>
        /// <param name="firstAnimalXCoordinate"> First animal X coordinate. </param>
        /// <param name="firstAnimalYCoordinate"> First animal Y coordinate. </param>
        /// <param name="secondAnimalXCoordinate"> Second animal X coordinate. </param>
        /// <param name="secondAnimalYCoordinate"> Second animal Y coordinate. </param>
        /// <param name="xArraySize"> Array size X coordinate ass. </param>
        /// <param name="yArraySize"> Array size Y coordinate ass. </param>
        /// <returns> double - Distance between animals. </returns>
        public double DistanceBetweenToAnimalse(int firstAnimalXCoordinate, int firstAnimalYCoordinate, int secondAnimalXCoordinate, int secondAnimalYCoordinate, int xArraySize, int yArraySize)
        {
            int distanceByX = FindShortDistance(firstAnimalXCoordinate, secondAnimalXCoordinate, xArraySize);
            int distanceByY = FindShortDistance(firstAnimalYCoordinate, secondAnimalYCoordinate, yArraySize);
            return Math.Sqrt(Math.Pow(distanceByX, 2) + Math.Pow(distanceByY, 2));
        }

        /// <summary>
        /// Method return smallest distance from points in coodrinate circle.
        /// </summary>
        /// <param name="position"> First point value. </param>
        /// <param name="target"> Second point value. </param>
        /// <param name="arrayLenght"> Maximum value in circle. </param>
        /// <returns> Smaller distance. </returns>
        private int FindShortDistance(int position, int target, int arrayLenght)
        {
            int returnNumberInRightSide = CalculatingDistance(position, target, arrayLenght);
            int returnNumberInLeftSide  = CalculatingDistance(target, position, arrayLenght);
            //int returnNumberInRightSide = ((position - target) + arrayLenght) % arrayLenght;
            //int returnNumberInLeftSide = ((target - position) + arrayLenght) % arrayLenght;

            if (returnNumberInRightSide < returnNumberInLeftSide)
            {
                return returnNumberInRightSide;
            }

            return returnNumberInLeftSide;
        }

        /// <summary>
        /// Method return distance from points in coodrinate circle.
        /// </summary>
        /// <param name="position"></param>
        /// <param name="target"></param>
        /// <param name="arrayLenght"></param>
        /// <returns></returns>
        public int CalculatingDistance(int position, int target, int arrayLenght)
        {
            return ((position - target) + arrayLenght) % arrayLenght;
        }

        /// <summary>
        /// Method return modul number to avoid going out of array.
        /// </summary>
        /// <param name="coord"> Current position.</param>
        /// <param name="shift"> Offset/next coordinate to check. </param>
        /// <param name="arrayLenght"> Array size/lenght/border. </param>
        /// <returns> int - Next cell coordinate. </returns>
        protected int GetModulNumber(int coord, int shift, int arrayLenght)
        {
            return (coord + shift + arrayLenght) % arrayLenght;
        }
    }
}
