namespace MarvelUniverse.Communications.Result
{
    /// <summary>
    /// Interface for result processor.
    /// </summary>
    public interface IResultProcessor
    {
        /// <summary>
        /// Processes a result.
        /// </summary>
        /// <typeparam name="T">Return type of the result.</typeparam>
        /// <param name="result">The result.</param>
        /// <returns>Flag indicating whether the result is successful.</returns>
        bool ProcessResult<T>(IResult<T> result);
    }
}
