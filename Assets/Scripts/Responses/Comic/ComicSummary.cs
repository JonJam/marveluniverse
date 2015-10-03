namespace MarvelUniverse.Responses.Comic
{
    using Newtonsoft.Json;

    public class ComicSummary
    {
        [JsonProperty("resourceURI")]
        public string ResourceURI { get; set; }
        
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}