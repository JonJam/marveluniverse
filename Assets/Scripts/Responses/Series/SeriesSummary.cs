namespace MarvelUniverse.Responses.Series
{
    using Newtonsoft.Json;
    
    public class SeriesSummary
    {        
        [JsonProperty("resourceURI")]
        public string ResourceURI { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}