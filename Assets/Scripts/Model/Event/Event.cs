namespace MarvelUniverse.Model.Event
{
    using System;
    using System.Runtime.Serialization;
    using Character;
    using Comic;
    using Creator;
    using Extensions;
    using Image;
    using Series;
    using Story;

    /// <summary>
    /// An event.
    /// </summary>
    [DataContract]
    public class Event
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
        /// Gets or sets the modified date time.
        /// </summary>
        [DataMember(Name = "modified")]
        public string Modified { get; set; }

        /// <summary>
        /// Gets or sets the start date.
        /// </summary>
        [DataMember(Name = "start")]
        public string Start { get; set; }

        /// <summary>
        /// Gets or sets the end date.
        /// </summary>
        [DataMember(Name = "end")]
        public string End { get; set; }

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
        /// Gets or sets the series.
        /// </summary>
        [DataMember(Name = "series")]
        public DataList<Summary> Series { get; set; }

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
        /// Gets or sets a summary of the next event.
        /// </summary>
        [DataMember(Name = "next")]
        public Summary Next { get; set; }

        /// <summary>
        /// Gets or sets a summary of the previous event.
        /// </summary>
        [DataMember(Name = "previous")]
        public Summary Previous { get; set; }

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
                
        /// <summary>
        /// Gets the start date to display.
        /// </summary>
        public string DisplayStartDate
        {
            get
            {
                return !string.IsNullOrEmpty(this.Start) ? this.Start.ToDisplayDate() : null;
            }
        }
        
        /// <summary>
        /// Gets the end date to display.
        /// </summary>
        public string DisplayEndDate
        {
            get
            {
                return !string.IsNullOrEmpty(this.End) ? this.End.ToDisplayDate() : null;
            }
        }
    }
}