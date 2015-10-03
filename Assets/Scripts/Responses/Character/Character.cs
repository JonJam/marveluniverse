
namespace MarvelUniverse.Responses.Character
{
    using System;
    using Comic;
    using Event;
    using Story;
    using Series;
    using Newtonsoft.Json;

    public class Character
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("modified")]
        public DateTime Modified { get; set; }

        [JsonProperty("resourceURI")]
        public string ResourceURI { get; set; }

        [JsonProperty("urls")]
        public Url[] Urls { get; set; }

        [JsonProperty("thumbnail")]
        public Image Thumbnail { get; set; }

        [JsonProperty("comics")]
        public DataList<ComicSummary> comics { get; set; }

        [JsonProperty("stories")]
        public DataList<StorySummary> Stories { get; set; }

        [JsonProperty("events")]
        public DataList<EventSummary> Events { get; set; }

        [JsonProperty("series")]
        public DataList<SeriesSummary> Series { get; set; }
    }
}