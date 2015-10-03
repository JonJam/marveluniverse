namespace MarvelUniverse.Responses
{
    using Newtonsoft.Json;

    public class DataList<T>
    {
        [JsonProperty("available")]
        public int Available { get; set; }

        [JsonProperty("returned")]
        public int Returned { get; set; }

        [JsonProperty("collectionURI")]
        public string CollectionURI { get; set; }
        
        [JsonProperty("items")]
        public T[] Items { get; set; }
    }
}