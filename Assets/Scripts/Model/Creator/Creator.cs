namespace MarvelUniverse.Model.Creator
{
    using System;
    using System.Runtime.Serialization;
    using Comic;
    using Event;
    using Image;
    using Series;
    using Story;

    /// <summary>
    /// A creator.
    /// </summary>
    [DataContract]
    public class Creator
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        [DataMember(Name = "id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        [DataMember(Name = "firstName")]
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the middle name.
        /// </summary>
        [DataMember(Name = "middleName")]
        public string MiddleName { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        [DataMember(Name = "lastName")]
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the suffix.
        /// </summary>
        [DataMember(Name = "suffix")]
        public string Suffix { get; set; }

        /// <summary>
        /// Gets or sets the full name.
        /// </summary>
        [DataMember(Name = "fullName")]
        public string FullName { get; set; }

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
        /// Gets or sets the series.
        /// </summary>
        [DataMember(Name = "series")]
        public DataList<Summary> Series { get; set; }

        /// <summary>
        /// Gets or sets the stories.
        /// </summary>
        [DataMember(Name = "stories")]
        public DataList<Summary> Stories { get; set; }

        /// <summary>
        /// Gets or sets the comics.
        /// </summary>
        [DataMember(Name = "comics")]
        public DataList<Summary> Comics { get; set; }

        /// <summary>
        /// Gets or sets the events.
        /// </summary>
        [DataMember(Name = "events")]
        public DataList<Summary> Events { get; set; }

        /// <summary>
        /// Gets a unique identifier.
        /// </summary>
        public string UniqueId
        {
            get
            {
                return string.Format("creator-{0}", this.Id);
            }
        }
    }
}