namespace MarvelUniverse.Model.Comic
{
    using Newtonsoft.Json;

    /// <summary>
    /// A text object.
    /// </summary>
    public class TextObject
    {
        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the language.
        /// </summary>
        [JsonProperty("language")]
        public string Language { get; set; }

        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        [JsonProperty("text")]
        public string Text { get; set; }
    }
}