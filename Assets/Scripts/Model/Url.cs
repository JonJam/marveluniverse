namespace MarvelUniverse.Model
{
    using Newtonsoft.Json;

    /// <summary>
    /// A URL.
    /// </summary>
    public class Url
    {
        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        [JsonProperty("url")]
        public string Value { get; set; }
    }
}