namespace MarvelUniverse.Responses.Story
{
    using Newtonsoft.Json;

    /// <summary>
    /// A story summary.
    /// </summary>
    public class StorySummary
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

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }
    }
}