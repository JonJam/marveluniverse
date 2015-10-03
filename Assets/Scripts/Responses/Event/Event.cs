namespace MarvelUniverse.Responses.Event
{
    using System;
    using Character;
    using Comic;
    using Creator;
    using Newtonsoft.Json;
    using Series;
    using Story;

    /// <summary>
    /// An event.
    /// </summary>
    public class Event
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the resource URI.
        /// </summary>
        [JsonProperty("resourceURI")]
        public string ResourceURI { get; set; }

        /// <summary>
        /// Gets or sets the URLs.
        /// </summary>
        [JsonProperty("urls")]
        public Url[] Urls { get; set; }

        /// <summary>
        /// Gets or sets the modified date time.
        /// </summary>
        [JsonProperty("modified")]
        public DateTime Modified { get; set; }

        /// <summary>
        /// Gets or sets the start date.
        /// </summary>
        [JsonProperty("start")]
        public DateTime Start { get; set; }

        /// <summary>
        /// Gets or sets the end date.
        /// </summary>
        [JsonProperty("end")]
        public DateTime End { get; set; }

        /// <summary>
        /// Gets or sets the thumbnail.
        /// </summary>
        [JsonProperty("thumbnail")]
        public Image Thumbnail { get; set; }

        /// <summary>
        /// Gets or sets the comics.
        /// </summary>
        [JsonProperty("comics")]
        public DataList<ComicSummary> Comics { get; set; }

        /// <summary>
        /// Gets or sets the stories.
        /// </summary>
        [JsonProperty("stories")]
        public DataList<StorySummary> Stories { get; set; }

        /// <summary>
        /// Gets or sets the series.
        /// </summary>
        [JsonProperty("series")]
        public DataList<SeriesSummary> Series { get; set; }

        /// <summary>
        /// Gets or sets the characters.
        /// </summary>
        [JsonProperty("characters")]
        public DataList<CharacterSummary> Characters { get; set; }

        /// <summary>
        /// Gets or sets the creators.
        /// </summary>
        [JsonProperty("creators")]
        public DataList<CreatorSummary> Creators { get; set; }

        /// <summary>
        /// Gets or sets a summary of the next event.
        /// </summary>
        [JsonProperty("next")]
        public EventSummary Next { get; set; }

        /// <summary>
        /// Gets or sets a summary of the previous event.
        /// </summary>
        [JsonProperty("previous")]
        public EventSummary Previous { get; set; }
    }
}