namespace MarvelUniverse.Responses.Series
{
    using System;
    using Comic;
    using Event;
    using Character;
    using Story;
    using Creator;
    using Newtonsoft.Json;

    public class Series
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }
        
        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("resourceURI")]
        public string ResourceURI { get; set; }

        [JsonProperty("urls")]
        public Url[] Urls { get; set; }

        [JsonProperty("startYear")]
        public int StartYear { get; set; }

        [JsonProperty("endYear")]
        public int EndYear { get; set; }

        [JsonProperty("rating")]
        public string Rating { get; set; }

        [JsonProperty("modified")]
        public DateTime Modified { get; set; }

        [JsonProperty("thumbnail")]
        public Image Thumbnail { get; set; }

        [JsonProperty("comics")]
        public DataList<ComicSummary> Comics { get; set; }

        [JsonProperty("stories")]
        public DataList<StorySummary> Stories { get; set; }

        [JsonProperty("events")]
        public DataList<EventSummary> Events { get; set; }

        [JsonProperty("characters")]
        public DataList<CharacterSummary> Characters { get; set; }

        [JsonProperty("creators")]
        public DataList<CreatorSummary> Creators { get; set; }

        [JsonProperty("next")]
        public SeriesSummary Next { get; set; }
        
        [JsonProperty("previous")]
        public SeriesSummary Previous { get; set; }
    }
}