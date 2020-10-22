
namespace Savanna
{
    using System;

    /// <summary>
    /// Class simulates the playground.
    /// </summary>
    public class Playground : IPlayground
    {
        #region VariableDeclaration

        /// <summary>
        /// Playground grid.
        /// </summary>
        public int[,] PlaygroundGrid { get; set; }

        /// <summary>
        /// Iteration number.
        /// </summary>
        public int IterationNumber { get; set; }
        #endregion

        #region Constructors


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

            PlaygroundGrid = new int[rows, columns];
            IterationNumber = 0;
            ZerroArray();
        }

        #endregion

        /// <summary>
        /// Method return playground as an array of numbers.
        /// </summary>
        /// <returns> int[,] - Playground array as array of int. </returns>
        public int[,] GetPlaygroundArray()
        {
            return PlaygroundGrid;
        }

        /// <summary>
        ///  Method randomly fills playground array with 1 (life) or 0 (free) values.
        /// </summary>
        public void ZerroArray()
        {
            for (int i = 0; i < PlaygroundGrid.GetLength(0); i++)
            {
                for (int j = 0; j < PlaygroundGrid.GetLength(1); j++)
                {
                    PlaygroundGrid[i, j] = 0;
                }
            }
        }

    }
}
