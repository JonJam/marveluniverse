namespace MarvelUniverse.Responses.Comic
{
    using Newtonsoft.Json;

    public class ComicDate
    {
        [JsonProperty("type")]
        public string Type { get; set; }
        
        [JsonProperty("date")]
        public string Date { get; set; }
    }
}