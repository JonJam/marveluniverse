namespace MarvelUniverse.Responses
{
    using Newtonsoft.Json;

    /// <summary>
    /// The data wrapper.
    /// </summary>
    /// <typeparam name="T">The type of the API object</typeparam>
    public class DataWrapper<T>
    {
        /// <summary>
        /// Gets or sets the code.
        /// </summary>
        [JsonProperty("code")]
        public int Code { get; set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets the copyright.
        /// </summary>
        [JsonProperty("copyright")]
        public string Copyright { get; set; }

        /// <summary>
        /// Gets or sets the attribution text.
        /// </summary>
        [JsonProperty("attributionText")]
        public string AttributionText { get; set; }

        /// <summary>
        /// Gets or sets the attribution HTML.
        /// </summary>
        [JsonProperty("attributionHTML")]
        public string AttributionHTML { get; set; }

        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        [JsonProperty("data")]
        public DataContainer<T> Data { get; set; }

        /// <summary>
        /// Gets or sets the ETAG.
        /// </summary>
        [JsonProperty("etag")]
        public string Etag { get; set; }
    }
}