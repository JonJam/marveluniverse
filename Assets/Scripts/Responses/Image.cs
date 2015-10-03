namespace MarvelUniverse.Responses
{
    using Newtonsoft.Json;

    public class Image
    {
        [JsonProperty("path")]
        public string Path { get; set; }
        
        [JsonProperty("extension")]
        public string Extension { get; set; }
    }
}