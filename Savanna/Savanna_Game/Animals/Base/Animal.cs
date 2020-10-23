using System;
using System.Collections.Generic;

namespace Savanna.Savanna.Animals
{
    /// <summary>
    /// Abstract class for all animals.
    /// </summary>
    public abstract class Animal : PositionOnPlayground
    {

        protected double maximumHealth;

        public string DisplayName { get; set; }

        /// <summary>
        /// Parameter tracks next point birth.
        /// </summary>
        public int TimeToGiveBorth { get; set; }

        /// <summary>
        /// Animal health metric.
        /// </summary>
        public double Health { get; set; }
        
        /// <summary>
        /// Animal vision range.
        /// </summary>
        protected int VisionRange { get; set; }

        #region Constructors

        /// <summary>
        /// Animal constructor.
        /// </summary>
        /// <param name="playground"> Playground. </param>
        public Animal(IPlayground playground)
        {
            double arrayRowCount = playground.GetPlaygroundArray().GetLength(0);
            double arrayColumnCount = playground.GetPlaygroundArray().GetLength(0);
            int middleX = (int)Math.Round((arrayRowCount / 2) - 0.5);
            int middleY = (int)Math.Round((arrayColumnCount / 2) - 0.5);
            SetRandomPositionInRange(playground, middleX, middleY, middleX-1, middleY-1);
        }

        
        public Animal(IPlayground playground, int currentPositionX, int currentPositionY, int rangeX, int rangeY)
        {
            //SetRandomPositionInRange(playground, currentPositionX, currentPositionY, rangeX, rangeY);
            // AddHerbivores(new Antelope(_playground, X, Y , 3, 3));
            SetRandomPositionInRange(playground, currentPositionX, currentPositionY, rangeX, rangeY);
        }

        /// <summary>
        /// Method sets random position in range for animal.
        /// </summary>
        /// <param name="playground"> Playground. </param>
        private void SetRandomPositionInRange(IPlayground playground, int positionX, int positionY, int shiftX, int shiftY)
        {
            Random random = new Random();
            int newXCoord;
            int newYCoord;
            bool coodinateIsOk = false;
            int pointIsNotNullCount = 0;
            int arrayXSize = playground.GetPlaygroundArray().GetLength(0);
            int arrayYSize = playground.GetPlaygroundArray().GetLength(1);

            while (!coodinateIsOk)
            {
                int randomXShift = random.Next(-shiftX, shiftX);
                int randomYShift = random.Next(-shiftY, shiftY);
                if (randomXShift == 0) randomXShift++;
                if (randomYShift == 0) randomYShift++;

                newXCoord = GetModulNumber(positionX, randomXShift, arrayXSize);
                newYCoord = GetModulNumber(positionY, randomYShift, arrayYSize);

                if (playground.GetValue(newXCoord, newYCoord) == 0)
                {

                    XPaygroundCoordinate = newXCoord;
                    YPaygroundCoordinate = newYCoord;
                    coodinateIsOk = true;
                }
                else if (pointIsNotNullCount > 20)
                {
                    int middleX = (int)Math.Round((playground.GetPlaygroundArray().GetLength(0) / 2) - 0.5);
                    int middleY = (int)Math.Round((playground.GetPlaygroundArray().GetLength(0) / 2) - 0.5);

                    SetRandomPositionInRange(playground, middleX, middleY, middleX-2, middleY-2);
                }
                else
                {
                    pointIsNotNullCount++;
                }
            }
        }

        #endregion

        /// <summary>
        /// Simulating animal behavior.
        /// </summary>
        /// <param name="hunters"> List of hunters. </param>
        /// <param name="herbivores"> List of herbivores. </param>
        /// <param name="playground"> Playground array </param>
        public virtual void SpecialAnimalBehavior(List<Hunters> hunters,List<Herbivores> herbivores, IPlayground playground)
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
        /// Method return the ID of closest animal from list. 
        /// </summary>
        /// <typeparam name="T"> Is Animal class. </typeparam>
        /// <param name="animal"> List of animals. </param>
        /// <param name="xArraySize"> Playground array size (X coordinate). </param>
        /// <param name="yArraySize"> Playground array size (Y coordinate). </param>
        /// <returns> ID of closest animal from list. </returns>
        protected int FindClosestAnumalIndex<T>(List<T> animal, int xArraySize, int yArraySize, bool isPartOfListAnimal) where T : Animal
        {
            int idOfClosestAnimal = -1;
            double distanceForClosestAnimal = double.MaxValue;

            for (int index = 0; index < animal.Count; index++)
            {
                double distance = DistanceBetweenToAnimalse(XPaygroundCoordinate, YPaygroundCoordinate, animal[index].XPaygroundCoordinate, animal[index].YPaygroundCoordinate, xArraySize, yArraySize);
                if(isPartOfListAnimal && ( distance == 0))
                {
                    continue;
                }

                if (distance < distanceForClosestAnimal)
                {
                    idOfClosestAnimal = index;
                    distanceForClosestAnimal = distance;
                }
            }

            if (idOfClosestAnimal != -1 && distanceForClosestAnimal > VisionRange)
            {
                return -1;
            }

            return idOfClosestAnimal;
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
        /// <returns> Smallest distance. </returns>
        private int FindShortDistance(int position, int target, int arrayLenght)
        {
            int returnNumberInRightSide = CalculatingDistance(position, target, arrayLenght);
            int returnNumberInLeftSide  = CalculatingDistance(target, position, arrayLenght);

            if (returnNumberInRightSide < returnNumberInLeftSide)
            {
                return returnNumberInRightSide;
            }

            return returnNumberInLeftSide;
        }

        /// <summary>
        /// Method return distance between points in coodrinate line.
        /// </summary>
        /// <param name="position"> Current point. </param>
        /// <param name="target"> Target point. </param>
        /// <param name="arrayLenght"> Playground length. </param>
        /// <returns> int - return distance between points in coodrinate line. </returns>
        public int CalculatingDistance(int position, int target, int arrayLenght)
        {
            return ((position - target) + arrayLenght) % arrayLenght;
        }

        /// <summary>
        /// Method return modul number (next cell coordinate) to avoid going out of array.
        /// </summary>
        /// <param name="coord"> Current position.</param>
        /// <param name="shift"> Offset/next coordinate to check. </param>
        /// <param name="arrayLenght"> Array size/lenght/border. </param>
        /// <returns> int - Next cell coordinate. </returns>
        protected int GetModulNumber(int coord, int shift, int arrayLenght)
        {
            return (coord + shift + arrayLenght) % arrayLenght;
        }

        /// <summary>
        /// Method move hunter closer to targer.
        /// </summary>
        /// <param name="animal"> Herbivore. </param>
        /// <param name="arraySize"> Array size (rows,columns) </param>
        protected void Spet(Animal animal, (int, int) arraySize, bool isHunter)
        {
            int offsetX = ShortenTheDistance(XPaygroundCoordinate, animal.XPaygroundCoordinate, arraySize.Item1, isHunter);
            int offsetY = ShortenTheDistance(YPaygroundCoordinate, animal.YPaygroundCoordinate, arraySize.Item2, isHunter);

            XPaygroundCoordinate = GetModulNumber(XPaygroundCoordinate, offsetX, arraySize.Item1);
            YPaygroundCoordinate = GetModulNumber(YPaygroundCoordinate, offsetY, arraySize.Item2);
        }

        /// <summary>
        /// Method return change for coordinate, brings points closer.
        /// </summary>
        /// <param name="position"> Hunter position. </param>
        /// <param name="target"> Target position. </param>
        /// <param name="arrayLenght"> Array length. </param>
        /// <returns> int - next coordinate shift. </returns>
        private int ShortenTheDistance(int position, int target, int arrayLenght, bool isHunter)
        {
            int returnNumberInRightSide = CalculatingDistance(position, target, arrayLenght);
            int returnNumberInLeftSide = CalculatingDistance(target, position, arrayLenght);

            if (returnNumberInLeftSide > returnNumberInRightSide)
            {
                if (isHunter)
                {
                    return -1;
                }

                return 1;
            }

            if (isHunter)
            {
                return 1;
            }

            return -1;
        }
    }
}
