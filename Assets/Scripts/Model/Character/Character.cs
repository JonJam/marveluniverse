//-----------------------------------------------------------------------
// <copyright file="Character.cs" company="">
// Copyright (c) 2015 Microsoft Corporation. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace MarvelUniverse.Model.Character
{
    using System;
    using Comic;
    using Event;
    using Image;
    using Newtonsoft.Json;
    using Series;
    using Story;

    /// <summary>
    /// A character
    /// </summary>
    public class Character
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the modified date time.
        /// </summary>
        [JsonProperty("modified")]
        public DateTime Modified { get; set; }

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
        /// Gets or sets the series.
        /// </summary>
        [JsonProperty("series")]
        public DataList<SeriesSummary> Series { get; set; }
    }
}