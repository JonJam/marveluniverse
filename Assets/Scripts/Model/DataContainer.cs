namespace MarvelUniverse.Model
{
    using Newtonsoft.Json;

    /// <summary>
    /// A data container.
    /// </summary>
    /// <typeparam name="T">The type of the data contained.</typeparam>
    public class DataContainer<T>
    {
        /// <summary>
        /// Gets or sets the offset.
        /// </summary>
        [JsonProperty("offset")]
        public int Offset { get; set; }

        /// <summary>
        /// Gets or sets the limit.
        /// </summary>
        [JsonProperty("limit")]
        public int Limit { get; set; }

        /// <summary>
        /// Gets or sets the total.
        /// </summary>
        [JsonProperty("total")]
        public int Total { get; set; }

        /// <summary>
        /// Gets or sets the count.
        /// </summary>
        [JsonProperty("count")]
        public int Count { get; set; }

        /// <summary>
        /// Gets or sets the results.
        /// </summary>
        [JsonProperty("results")]
        public T[] Results { get; set; }
    }
}
