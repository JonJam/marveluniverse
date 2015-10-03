namespace MarvelUniverse.Responses.Character
{
    using Newtonsoft.Json;

    public class CharacterSummary
    {
        [JsonProperty("resourceURI")]
        public string ResourceURI { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("role")]
        public string Role { get; set; }
    }
}