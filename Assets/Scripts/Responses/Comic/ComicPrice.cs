namespace MarvelUniverse.Responses.Comic
{
    using Newtonsoft.Json;

    public class ComicPrice
    {
        [JsonProperty("type")]
        public string Type { get; set; }
        
        [JsonProperty("price")]
        public string Price { get; set; }
    }
}