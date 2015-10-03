namespace MarvelUniverse.Responses.Event
{
    using Newtonsoft.Json;

    /// <summary>
    /// An event summary.
    /// </summary>
    public class EventSummary
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