namespace MarvelUniverse.Responses.Comic
{
    using Newtonsoft.Json;

    /// <summary>
    /// A comic date.
    /// </summary>
    public class ComicDate
    {
        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the date.
        /// </summary>
        [JsonProperty("date")]
        public string Date { get; set; }
    }
}