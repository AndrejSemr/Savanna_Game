
namespace Savanna
{
    /// <summary>
    /// Interface provides the necessary functionality for work with Playground.
    /// </summary>
    public interface IPlayground
    {

        /// <summary>
        /// Method return playground as an array of numbers.
        /// </summary>
        /// <returns> int[,] - Playground array as array of int. </returns>
        public char[,] GetPlaygroundArray();

        /// <summary>
        ///  Method fills playground array with 0 values.
        /// </summary>
        public void ZerroArray();

        /// <summary>
        /// Method sets new value to playground grid.
        /// </summary>
        /// <param name="row"> Row number. </param>
        /// <param name="colum"> Column number. </param>
        /// <param name="value"> New value. </param>
        public void SetValue(int row, int colum, char value);

        /// <summary>
        /// Method sets new value to playground grid.
        /// </summary>
        /// <param name="row"> Row number. </param>
        /// <param name="colum"> Column number. </param>
        public char GetValue(int row, int colum);
    }
}
