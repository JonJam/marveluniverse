namespace MarvelUniverse.Responses.Story
{
    using System;
    using Comic;
    using Character;
    using Series;
    using Event;
    using Creator;
    using Newtonsoft.Json;

    public class Story
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        
        [JsonProperty("title")]
        public string title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("resourceURI")]
        public string ResourceURI { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("modified")]
        public DateTime Modified { get; set; }

        [JsonProperty("thumbnail")]
        public Image Thumbnail { get; set; }

        [JsonProperty("comics")]
        public DataList<ComicSummary> Comics { get; set; }

        [JsonProperty("series")]
        public DataList<SeriesSummary> Series { get; set; }

        [JsonProperty("events")]
        public DataList<EventSummary> Events { get; set; }

        [JsonProperty("characters")]
        public DataList<CharacterSummary> Characters { get; set; }

        [JsonProperty("creators")]
        public DataList<CreatorSummary> Creators { get; set; }

        [JsonProperty("originalissue")]
        public ComicSummary Originalissue { get; set; }
    }
}
