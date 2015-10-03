namespace MarvelUniverse.Responses.Event
{
    using System;
    using Comic;
    using Creator;
    using Character;
    using Series;
    using Story;
    using Newtonsoft.Json;

    public class Event
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

        [JsonProperty("modified")]
        public DateTime Modified { get; set; }

        [JsonProperty("start")]
        public DateTime Start { get; set; }

        [JsonProperty("end")]
        public DateTime End { get; set; }

        [JsonProperty("thumbnail")]
        public Image Thumbnail { get; set; }

        [JsonProperty("comics")]
        public DataList<ComicSummary> Comics { get; set; }

        [JsonProperty("stories")]
        public DataList<StorySummary> Stories { get; set; }

        [JsonProperty("series")]
        public DataList<SeriesSummary> Series { get; set; }

        [JsonProperty("characters")]
        public DataList<CharacterSummary> Characters { get; set; }

        [JsonProperty("creators")]
        public DataList<CreatorSummary> Creators { get; set; }

        [JsonProperty("next")]
        public EventSummary Next { get; set; }

        [JsonProperty("previous")]
        public EventSummary Previous { get; set; }
    }
}