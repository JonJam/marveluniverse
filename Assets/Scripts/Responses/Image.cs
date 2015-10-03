namespace MarvelUniverse.Responses
{
    using Newtonsoft.Json;

    /// <summary>
    /// An image.
    /// </summary>
    public class Image
    {
        /// <summary>
        /// Gets or sets the path.
        /// </summary>
        [JsonProperty("path")]
        public string Path { get; set; }

        /// <summary>
        /// Gets or sets the extension.
        /// </summary>
        [JsonProperty("extension")]
        public string Extension { get; set; }
    }
}