namespace MarvelUniverse.Responses.Story
{
    using Newtonsoft.Json;

    public class StorySummary
    {
        [JsonProperty("resourceURI")]
        public string ResourceURI { get; set; }
        
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }
}