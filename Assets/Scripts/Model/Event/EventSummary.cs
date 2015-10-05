namespace MarvelUniverse.Model.Event
{
    using Newtonsoft.Json;

    /// <summary>
    /// An event summary.
    /// </summary>
    public class EventSummary
    {
        /// <summary>
        /// Gets or sets the resource URI. This is a string but using object as some Model return JSON object incorrectly.
        /// </summary>
        [JsonProperty("resourceURI")]
        public object ResourceURI { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}