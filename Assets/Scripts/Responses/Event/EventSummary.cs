namespace MarvelUniverse.Responses.Event
{
    using Newtonsoft.Json;

    public class EventSummary
    {
        [JsonProperty("resourceURI")]
        public string ResourceURI { get; set; }
        
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}