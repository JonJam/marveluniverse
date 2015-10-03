namespace MarvelUniverse.Responses
{
    using Newtonsoft.Json;

    public class DataContainer<T>
    {
        [JsonProperty("offset")]
        public int Offset { get; set; }

        [JsonProperty("limit")]
        public int Limit { get; set; }

        [JsonProperty("total")]
        public int Total { get; set; }

        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("results")]
        public T[] Results { get; set; }
    }
}
