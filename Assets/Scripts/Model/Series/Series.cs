namespace MarvelUniverse.Model.Series
{
    using System;
    using Character;
    using Comic;
    using Creator;
    using Event;
    using Image;
    using Newtonsoft.Json;
    using Story;

    /// <summary>
    /// A series.
    /// </summary>
    public class Series
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
        /// Gets or sets the start year.
        /// </summary>
        [JsonProperty("startYear")]
        public int StartYear { get; set; }

        /// <summary>
        /// Gets or sets the end year.
        /// </summary>
        [JsonProperty("endYear")]
        public int EndYear { get; set; }

        /// <summary>
        /// Gets or sets the rating.
        /// </summary>
        [JsonProperty("rating")]
        public string Rating { get; set; }

        /// <summary>
        /// Gets or sets the modified date time.
        /// </summary>
        [JsonProperty("modified")]
        public string Modified { get; set; }

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
        /// Gets or sets the events.
        /// </summary>
        [JsonProperty("events")]
        public DataList<EventSummary> Events { get; set; }

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
        /// Gets or sets the next series.
        /// </summary>
        [JsonProperty("next")]
        public SeriesSummary Next { get; set; }

        /// <summary>
        /// Gets or sets the previous series.
        /// </summary>
        [JsonProperty("previous")]
        public SeriesSummary Previous { get; set; }
    }
}