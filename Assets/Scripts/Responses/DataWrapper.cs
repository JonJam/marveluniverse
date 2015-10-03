namespace MarvelUniverse.Responses
{
    using Newtonsoft.Json;

    public class DataWrapper<T>
    {
        [JsonProperty("code")]
        public int Code { get; set; }
        
        [JsonProperty("status")]
        public string Status { get; set; }
        
        [JsonProperty("copyright")]
        public string Copyright { get; set; }
        
        [JsonProperty("attributionText")]
        public string AttributionText { get; set; }
        
        [JsonProperty("attributionHTML")]
        public string AttributionHTML { get; set; }
        
        [JsonProperty("data")]
        public DataContainer<T> Data { get; set; }
        
        [JsonProperty("etag")]
        public string Etag { get; set; }
    }
}