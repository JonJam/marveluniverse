namespace MarvelUniverse.Responses.Creator
{
    using System;
    using Comic;
    using Event;
    using Series;
    using Story;
    using Newtonsoft.Json;

    public class Creator
    { 
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("middleName")]
        public string MiddleName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("suffix")]
        public string Suffix { get; set; }

        [JsonProperty("fullName")]
        public string FullName { get; set; }

        [JsonProperty("modified")]
        public DateTime Modified { get; set; }

        [JsonProperty("resourceURI")]
        public string ResourceURI { get; set; }

        [JsonProperty("urls")]
        public Url[] Urls { get; set; }

        [JsonProperty("thumbnail")]
        public Image Thumbnail { get; set; }

        [JsonProperty("series")]
        public DataList<SeriesSummary> Series { get; set; }

        [JsonProperty("stories")]
        public DataList<StorySummary> Stories { get; set; }

        [JsonProperty("comics")]
        public DataList<ComicSummary> Comics { get; set; }

        [JsonProperty("events")]
        public DataList<EventSummary> Events { get; set; }
    }
}