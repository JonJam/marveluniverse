namespace MarvelUniverse.Communications.Result
{
    /// <summary>
    /// Implementation of the IResult interface.
    /// </summary>
    /// <typeparam name="T">Type of data contained in the result.</typeparam>
    public class Result<T> : IResult<T>
    {
        /// <summary>
        /// The data.
        /// </summary>
        private readonly T data;

        /// <summary>
        /// The error.
        /// </summary>
        private readonly string error;

        /// <summary>
        /// Initializes a new instance of the <see cref="Result{T}"/> class.
        /// </summary>
        /// <param name="data">The data.</param>
        public Result(T data)
        {
            this.data = data;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Result{T}"/> class.
        /// </summary>
        /// <param name="error">The error.</param>
        public Result(string error)
        {
            this.error = error;
        }

        /// <summary>
        /// Gets the error.
        /// </summary>
        /// <value>
        /// The error.
        /// </value>
        public string Error
        {
            get
            {
                return this.error;
            }
        }

        /// <summary>
        /// Gets the data.
        /// </summary>
        /// <value>
        /// The data.
        /// </value>
        public T Data
        {
            get
            {
                return this.data;
            }
        }

        /// <summary>
        /// Gets a value indicating whether this instance is success.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is success; otherwise, <c>false</c>.
        /// </value>
        public bool IsSuccess
        {
            get
            {
                return string.IsNullOrEmpty(this.Error) &&
                    !this.IsDefaultData();
            }
        }

        /// <summary>
        /// Determines whether [is default data].
        /// </summary>
        /// <returns>Flag indicating whether is default data.</returns>
        private bool IsDefaultData()
        {
            return object.Equals(this.Data, default(T));
        }
    }
}
