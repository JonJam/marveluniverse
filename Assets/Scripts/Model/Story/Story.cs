namespace MarvelUniverse.Model.Story
{
    using System;
    using Character;
    using Comic;
    using Creator;
    using Event;
    using Extensions;
    using Image;
    using Newtonsoft.Json;
    using Series;

    /// <summary>
    /// A story.
    /// </summary>
    public class Story
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
        /// Gets or sets the type.
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the modified date time.
        /// </summary>
        [JsonProperty("modified")]
        public DateTime Modified { get; set; }

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
        /// Gets or sets the series.
        /// </summary>
        [JsonProperty("series")]
        public DataList<SeriesSummary> Series { get; set; }

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
        /// Gets or sets the original issue.
        /// </summary>
        [JsonProperty("originalissue")]
        public ComicSummary Originalissue { get; set; }

        /// <summary>
        /// Gets the clean description.
        /// </summary>
        public string CleanDescription
        {
            get
            {
                return this.Description.Clean();
            }
        }
    }
}
