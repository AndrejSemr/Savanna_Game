
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
        /// <returns> Playground array as array of char. </returns>
        public char[,] GetPlaygroundArray();

        /// <summary>
        ///  Method clear playground array.
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
        /// Method get value from playground grid.
        /// </summary>
        /// <param name="row"> Row number. </param>
        /// <param name="colum"> Column number. </param>
        public char GetValue(int row, int colum);
    }
}
