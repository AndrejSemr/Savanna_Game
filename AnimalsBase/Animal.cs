using System;
using System.Collections.Generic;

namespace AnimalsBase
{
    /// <summary>
    /// Abstract class for all animals.
    /// </summary>
    /// 
    public abstract class Animal : PositionOnPlayground
    {

        protected double maximumHealth;

        /// <summary>
        /// Property stores button for creating an animal.
        /// </summary>
        public abstract ConsoleKey AnimalConsoleKey { get; set; }

        /// <summary>
        /// Animal label (L, A...).
        /// </summary>
        public char AnimalTypeLabel { get; set; }

        /// <summary>
        /// Animal type name (Lion, Antelope...).
        /// </summary>
        public string AnimalType { get; set; }

        /// <summary>
        /// Property tracks next point birth.
        /// </summary>
        public int TimeToGiveBorth { get; set; }

        /// <summary>
        /// Animal health metric property.
        /// </summary>
        public double Health { get; set; }
        
        /// <summary>
        /// Animal vision range.
        /// </summary>
        protected int VisionRange { get; set; }

        #region Constructor

        /// <summary>
        /// Animal constructor.
        /// </summary>
        /// <param name="arraySizeX"> Number of rows in array. </param>
        /// <param name="arraySizeY"> Number of column in array. </param>
        public Animal(int arraySizeX, int arraySizeY)
        {
            SetRandomPositionInRange(arraySizeX, arraySizeY);
        }

        /// <summary>
        /// Method sets random position in range for animal.
        /// </summary>
        /// <param name="arraySizeX"> Number of rows in array. </param>
        /// <param name="arraySizeY"> Number of column in array. </param>
        public void SetRandomPositionInRange(int arraySizeX, int arraySizeY)
        {
            Random random = new Random();
            XPaygroundCoordinate = random.Next(0, arraySizeX);
            YPaygroundCoordinate = random.Next(0, arraySizeY);
        }

        #endregion

        /// <summary>
        /// Simulating animal behavior.
        /// </summary>
        /// <param name="hunters"> List of hunters. </param>
        /// <param name="herbivores"> List of herbivores. </param>
        /// <param name="playground"> Playground array of char. </param>
        public virtual void SpecialAnimalBehavior(List<Hunters> hunters, List<Herbivores> herbivores, char[,] playground)
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
        /// <param name="isPartOfListAnimal"> If it is part of tis list. </param>
        /// <returns> ID of closest animal from list. </returns>
        protected int FindClosestAnumalIndex<T>(List<T> animal, int xArraySize, int yArraySize, bool isPartOfListAnimal) where T : Animal
        {
            int idOfClosestAnimal = -1;
            double distanceForClosestAnimal = double.MaxValue;

            for (int index = 0; index < animal.Count; index++)
            {
                double distance = DistanceBetweenToAnimalse(XPaygroundCoordinate, YPaygroundCoordinate, animal[index].XPaygroundCoordinate, animal[index].YPaygroundCoordinate, xArraySize, yArraySize);
                
                // If element compares to itself - skit it.
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
        /// Method return the ID of closest animal from list by type.
        /// </summary>
        /// <typeparam name="T"> Is Animal class. </typeparam>
        /// <param name="animal"> List of animals. </param>
        /// <param name="xArraySize"> Playground array size (X coordinate). </param>
        /// <param name="yArraySize"> Playground array size (Y coordinate). </param>
        /// <param name="animalType"> Animal type. </param>
        /// <returns> Closest animal index (With same type). </returns>
        protected int FindClosestAnumalIndexByType<T>(List<T> animal, int xArraySize, int yArraySize, string animalType) where T : Animal
        {
            int idOfClosestAnimal = -1;
            double distanceForClosestAnimal = double.MaxValue;

            for (int index = 0; index < animal.Count; index++)
            {
                if(animalType == animal[index].GetType().Name.ToString()) {

                    double distance = DistanceBetweenToAnimalse(XPaygroundCoordinate, YPaygroundCoordinate, animal[index].XPaygroundCoordinate, animal[index].YPaygroundCoordinate, xArraySize, yArraySize);

                    // If element compares to itself - skit it.
                    if (distance == 0)
                    {
                        continue;
                    }

                    if (distance < distanceForClosestAnimal)
                    {
                        idOfClosestAnimal = index;
                        distanceForClosestAnimal = distance;
                    }
                }
            }

            if (idOfClosestAnimal != -1 && distanceForClosestAnimal > VisionRange)
            {
                return -1;
            }

            return idOfClosestAnimal;
        }

        /// <summary>
        /// Method finds a shorter distance between animals.
        /// </summary>
        /// <param name="firstAnimalXCoordinate"> First animal X coordinate. </param>
        /// <param name="firstAnimalYCoordinate"> First animal Y coordinate. </param>
        /// <param name="secondAnimalXCoordinate"> Second animal X coordinate. </param>
        /// <param name="secondAnimalYCoordinate"> Second animal Y coordinate. </param>
        /// <param name="xArraySize"> Array size X coordinate ass. </param>
        /// <param name="yArraySize"> Array size Y coordinate ass. </param>
        /// <returns> Distance between animals. </returns>
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
        /// <returns> Distance between points in coodrinate line. </returns>
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
        /// <returns> Next cell coordinate. </returns>
        protected int GetModulNumber(int coord, int shift, int arrayLenght)
        {
            return (coord + shift + arrayLenght) % arrayLenght;
        }

        /// <summary>
        /// Method move hunter closer to targer.
        /// </summary>
        /// <param name="animal"> An animal. </param>
        /// <param name="arrayPlayground"> Playground array of char. </param>
        /// <param name="isHunter"> Is it hunter? </param>
        protected void Spet(Animal animal, char[,] arrayPlayground, bool isHunter)
        {
            (int, int) arraySize = (arrayPlayground.GetLength(0), arrayPlayground.GetLength(1));

            int offsetX = ShortenTheDistance(XPaygroundCoordinate, animal.XPaygroundCoordinate, arraySize.Item1, isHunter);
            int offsetY = ShortenTheDistance(YPaygroundCoordinate, animal.YPaygroundCoordinate, arraySize.Item2, isHunter);

            int newX = GetModulNumber(XPaygroundCoordinate, offsetX, arraySize.Item1);
            int newY = GetModulNumber(YPaygroundCoordinate, offsetY, arraySize.Item2);

            if(arrayPlayground[newX, newY] == '.')
            {
                XPaygroundCoordinate = newX;
                YPaygroundCoordinate = newY;
            }

        }

        /// <summary>
        /// Method return change for coordinate, brings points closer.
        /// </summary>
        /// <param name="position"> Hunter position. </param>
        /// <param name="target"> Target position. </param>
        /// <param name="arrayLenght"> Array length. </param>
        /// <returns> Next coordinate shift. </returns>
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
