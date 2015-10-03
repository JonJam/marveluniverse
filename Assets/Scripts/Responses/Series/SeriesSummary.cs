namespace MarvelUniverse.Responses.Series
{
    using Newtonsoft.Json;
    
    /// <summary>
    /// A series summary
    /// </summary>
    public class SeriesSummary
    {
        /// <summary>
        /// Gets or sets the resource URI.
        /// </summary>
        [JsonProperty("resourceURI")]
        public string ResourceURI { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}