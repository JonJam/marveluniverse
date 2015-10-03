namespace MarvelUniverse.Responses.Creator
{
    using Newtonsoft.Json;

    public class CreatorSummary
    {
        [JsonProperty("resourceURI")]
        public string ResourceURI { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("role")]
        public string Role { get; set; }
    }
}