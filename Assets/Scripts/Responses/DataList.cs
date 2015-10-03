namespace MarvelUniverse.Responses
{
    using Newtonsoft.Json;

    /// <summary>
    /// A data list.
    /// </summary>
    /// <typeparam name="T">The type of the data contained.</typeparam>
    public class DataList<T>
    {
        /// <summary>
        /// Gets or sets the amount of items available.
        /// </summary>
        [JsonProperty("available")]
        public int Available { get; set; }

        /// <summary>
        /// Gets or sets the amount of items returned.
        /// </summary>
        [JsonProperty("returned")]
        public int Returned { get; set; }

        /// <summary>
        /// Gets or sets the collection URI.
        /// </summary>
        [JsonProperty("collectionURI")]
        public string CollectionURI { get; set; }

        /// <summary>
        /// Gets or sets the items.
        /// </summary>
        [JsonProperty("items")]
        public T[] Items { get; set; }
    }
}