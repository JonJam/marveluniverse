namespace MarvelUniverse.Communications
{
    using System.Collections.Generic;
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
        /// Initializes a new instance of the <see cref="BaseService"/>
        /// </summary>
        /// <param name="jsonSerializer">The JSON serializer.</param>
        public BaseService(IJsonSerializer jsonSerializer)
        {
            this.jsonSerializer = jsonSerializer;
        }

        /// <summary>
        /// Creates a successful search result.
        /// </summary>
        /// <param name="json">The JSON obtained.</param>
        /// <returns>A result.</returns>
        protected IResult<IList<T>> CreateSuccessfulSearchResult<T>(string json)
        {
            DataWrapper<T> dataWrapper = this.jsonSerializer.Deserialize<DataWrapper<T>>(json);

            IList<T> comics = null;

            if (dataWrapper != null &&
                dataWrapper.Data != null)
            {
                comics = dataWrapper.Data.Results;
            }

            return new Result<IList<T>>(comics);
        }
    }
}
