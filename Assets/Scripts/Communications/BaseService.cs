namespace MarvelUniverse.Communications
{
    using System.Collections.Generic;
    using System.Linq;
    using MarvelUniverse.Communications.Result;
    using MarvelUniverse.Communications.Serialization;
    using MarvelUniverse.Model;

    /// <summary>
    /// The base service.
    /// </summary>
    public abstract class BaseService
    {
        /// <summary>
        /// The JSON serializer.
        /// </summary>
        private readonly IJsonSerializer jsonSerializer;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseService"/> class.
        /// </summary>
        /// <param name="jsonSerializer">The JSON serializer.</param>
        public BaseService(IJsonSerializer jsonSerializer)
        {
            this.jsonSerializer = jsonSerializer;
        }

        /// <summary>
        /// Creates a successful list result.
        /// </summary>
        /// <typeparam name="T">The type to list item.</typeparam>
        /// <param name="json">The JSON obtained.</param>
        /// <returns>A result.</returns>
        protected IResult<IList<T>> CreateSuccessfulListResult<T>(string json)
        {
            DataWrapper<T> dataWrapper = this.jsonSerializer.Deserialize<DataWrapper<T>>(json);

            IList<T> data = null;

            if (dataWrapper != null &&
                dataWrapper.Data != null)
            {
                data = dataWrapper.Data.Results;
            }

            return new Result<IList<T>>(data);
        }

        /// <summary>
        /// Creates a successful result.
        /// </summary>
        /// <typeparam name="T">The type to deserialize to.</typeparam>
        /// <param name="json">The JSON obtained.</param>
        /// <returns>A result.</returns>
        protected IResult<T> CreateSuccessfulResult<T>(string json)
        {
            DataWrapper<T> dataWrapper = this.jsonSerializer.Deserialize<DataWrapper<T>>(json);

            T data = default(T);

            if (dataWrapper != null &&
                dataWrapper.Data != null &&
                dataWrapper.Data.Results != null &&
                dataWrapper.Data.Results.Count() > 0)
            {
                data = dataWrapper.Data.Results[0];
            }

            return new Result<T>(data);
        }
    }
}
