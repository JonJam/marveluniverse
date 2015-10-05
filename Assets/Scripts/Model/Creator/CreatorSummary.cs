namespace MarvelUniverse.Model.Creator
{
    using Newtonsoft.Json;

    /// <summary>
    /// A creator summary.
    /// </summary>
    public class CreatorSummary
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
        /// Gets or sets the role.
        /// </summary>
        [JsonProperty("role")]
        public string Role { get; set; }
    }
}