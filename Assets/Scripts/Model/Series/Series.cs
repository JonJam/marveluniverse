namespace MarvelUniverse.Model.Series
{
    using System.Runtime.Serialization;
    using Character;
    using Comic;
    using Creator;
    using Event;
    using Extensions;
    using Image;
    using Story;

    /// <summary>
    /// A series.
    /// </summary>
    [DataContract]
    public class Series
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        [DataMember(Name = "id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        [DataMember(Name = "title")]
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        [DataMember(Name = "description")]
        public string Description { get; set; }

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
        /// Gets or sets the start year.
        /// </summary>
        [DataMember(Name = "startYear")]
        public int StartYear { get; set; }

        /// <summary>
        /// Gets or sets the end year.
        /// </summary>
        [DataMember(Name = "endYear")]
        public int EndYear { get; set; }

        /// <summary>
        /// Gets or sets the rating.
        /// </summary>
        [DataMember(Name = "rating")]
        public string Rating { get; set; }

        /// <summary>
        /// Gets or sets the modified date time.
        /// </summary>
        [DataMember(Name = "modified")]
        public string Modified { get; set; }

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
        /// Gets or sets the characters.
        /// </summary>
        [DataMember(Name = "characters")]
        public DataList<Summary> Characters { get; set; }

        /// <summary>
        /// Gets or sets the creators.
        /// </summary>
        [DataMember(Name = "creators")]
        public DataList<Summary> Creators { get; set; }

        /// <summary>
        /// Gets or sets the next series.
        /// </summary>
        [DataMember(Name = "next")]
        public Summary Next { get; set; }

        /// <summary>
        /// Gets or sets the previous series.
        /// </summary>
        [DataMember(Name = "previous")]
        public Summary Previous { get; set; }

        /// <summary>
        /// Gets a unique identifier.
        /// </summary>
        public string UniqueId
        {
            get
            {
                return string.Format("series-{0}", this.Id);
            }
        }

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