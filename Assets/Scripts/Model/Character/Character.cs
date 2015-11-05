//-----------------------------------------------------------------------
// <copyright file="Character.cs" company="">
// Copyright (c) 2015 Microsoft Corporation. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace MarvelUniverse.Model.Character
{
    using System;
    using System.Runtime.Serialization;
    using Comic;
    using Event;
    using Extensions;
    using Image;
    using Series;
    using Story;

    /// <summary>
    /// A character
    /// </summary>
    [DataContract]
    public class Character
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        [DataMember(Name = "id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        [DataMember(Name = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        [DataMember(Name = "description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the modified date time.
        /// </summary>
        [DataMember(Name = "modified")]
        public string Modified { get; set; }

        /// <summary>
        /// Gets or sets the resource URI.
        /// </summary>
        [DataMember(Name = "resourceURI")]
        public string ResourceURI { get; set; }

        /// <summary>
        /// Gets or sets the URLs.
        /// </summary>
        [DataMember(Name = "urls")]
        public Url[] Urls { get; set; }

        /// <summary>
        /// Gets or sets the thumbnail.
        /// </summary>
        [DataMember(Name = "thumbnail")]
        public Image Thumbnail { get; set; }

        /// <summary>
        /// Gets or sets the comics.
        /// </summary>
        [DataMember(Name = "comics")]
        public DataList<Summary> Comics { get; set; }

        /// <summary>
        /// Gets or sets the stories.
        /// </summary>
        [DataMember(Name = "stories")]
        public DataList<Summary> Stories { get; set; }

        /// <summary>
        /// Gets or sets the events.
        /// </summary>
        [DataMember(Name = "events")]
        public DataList<Summary> Events { get; set; }

        /// <summary>
        /// Gets or sets the series.
        /// </summary>
        [DataMember(Name = "series")]
        public DataList<Summary> Series { get; set; }

        /// <summary>
        /// Gets the clean description.
        /// </summary>
        public string CleanDescription
        {
            get
            {
                return !string.IsNullOrEmpty(this.Description) ? this.Description.Clean() : null;
            }
        }
    }
}