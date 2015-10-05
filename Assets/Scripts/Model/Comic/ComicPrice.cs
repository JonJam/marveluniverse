namespace MarvelUniverse.Model.Comic
{
    using Newtonsoft.Json;

    /// <summary>
    /// A comic price.
    /// </summary>
    public class ComicPrice
    {
        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the price.
        /// </summary>
        [JsonProperty("price")]
        public string Price { get; set; }
    }
}