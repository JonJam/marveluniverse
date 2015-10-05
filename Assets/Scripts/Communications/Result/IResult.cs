namespace MarvelUniverse.Communications.Result
{
    /// <summary>
    /// Interface for a result.
    /// </summary>
    /// <typeparam name="T">Type of data contained in the result.</typeparam>
    public interface IResult<T>
    {
        /// <summary>
        /// Gets the error.
        /// </summary>
        /// <value>
        /// The error.
        /// </value>
        string Error
        {
            get;
        }

        /// <summary>
        /// Gets the data.
        /// </summary>
        /// <value>
        /// The data.
        /// </value>
        T Data
        {
            get;
        }

        /// <summary>
        /// Gets a value indicating whether this instance is a success.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is a success; otherwise, <c>false</c>.
        /// </value>
        bool IsSuccess
        {
            get;
        }
    }
}
