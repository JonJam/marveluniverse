namespace MarvelUniverse.Responses.Comic
{
    using Newtonsoft.Json;

    /// <summary>
    /// A comic summary.
    /// </summary>
    public class ComicSummary
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