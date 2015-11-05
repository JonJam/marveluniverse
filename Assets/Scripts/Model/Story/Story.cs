namespace MarvelUniverse.Model.Story
{
    using System;
    using System.Runtime.Serialization;
    using Character;
    using Comic;
    using Creator;
    using Event;
    using Extensions;
    using Image;
    using Series;

    /// <summary>
    /// A story.
    /// </summary>
    [DataContract]
    public class Story
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
        /// Gets or sets the type.
        /// </summary>
        [DataMember(Name = "type")]
        public string Type { get; set; }

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
        /// Gets or sets the series.
        /// </summary>
        [DataMember(Name = "series")]
        public DataList<Summary> Series { get; set; }

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
        /// Gets or sets the original issue.
        /// </summary>
        [DataMember(Name = "originalIssue")]
        public Summary OriginalIssue { get; set; }

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
        /// Gets the type to display.
        /// </summary>
        public string DisplayType
        {
            get
            {
                string displayType = null;

                switch (this.Type)
                {
                    case "story":
                        displayType = "Story";
                        break;
                    case "cover":
                        displayType = "Cover";
                        break;
                    case "interiorStory":
                        displayType = "Interior story";
                        break;
                    default:
                        displayType = this.Type;
                        break;
                }

                return displayType;
            }
        }
    }
}
