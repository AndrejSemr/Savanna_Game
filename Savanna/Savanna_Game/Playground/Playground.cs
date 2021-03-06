﻿
using System;

namespace Savanna
{
    /// <summary>
    /// Class simulates the playground.
    /// </summary>
    public class Playground : IPlayground
    {

        /// <summary>
        /// Playground grid.
        /// </summary>
        private char[,] PlaygroundGrid { get; set; }

        /// <summary>
        /// Constructor creates a playground based on rows and cilumns.
        /// </summary>
        /// <param name="rows">Number of rows in new Playground.</param>
        /// <param name="columns">Number of rows in new Playground.</param>
        public Playground(int rows, int columns)
        {
            if (rows <= 1 || columns <= 1)
            {
                throw new ArgumentOutOfRangeException("Row and Column size must be greater than 0");
            }

            PlaygroundGrid = new char[rows, columns];
            ZerroArray();
        }

        /// <summary>
        /// Method return playground as an array of numbers.
        /// </summary>
        /// <returns> Playground array as array of char. </returns>
        public char[,] GetPlaygroundArray()
        {
            return PlaygroundGrid;
        }

        /// <summary>
        /// Method clear playground array.
        /// </summary>
        public void ZerroArray()
        {
            for (int i = 0; i < PlaygroundGrid.GetLength(0); i++)
            {
                for (int j = 0; j < PlaygroundGrid.GetLength(1); j++)
                {
                    PlaygroundGrid[i, j] = '.';
                }
            }
        }

        /// <summary>
        /// Method sets new value to playground grid.
        /// </summary>
        /// <param name="row"> Row number. </param>
        /// <param name="colum"> Column number. </param>
        /// <param name="value"> New value. </param>
        public void SetValue(int row, int colum, char value)
        {
            PlaygroundGrid[row, colum] = value;
        }

        /// <summary>
        /// Method get value from playground grid.
        /// </summary>
        /// <param name="row"> Row number. </param>
        /// <param name="colum"> Column number. </param>
        public char GetValue(int row, int colum)
        {
            return PlaygroundGrid[row, colum];
        }

    }
}
