namespace MarvelUniverse.Model.Comic
{
    using System.Runtime.Serialization;
    using Extensions;
    using Image;

    /// <summary>
    /// A comic.
    /// </summary>
    [DataContract]
    public class Comic
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        [DataMember(Name = "id")]
        public int Id { get; set; }
        
        /// <summary>
        /// Gets or sets the digital identifier.
        /// </summary>
        [DataMember(Name = "digitalId")]
        public int DigitalId { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        [DataMember(Name = "title")]
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the issue number.
        /// </summary>
        [DataMember(Name = "issueNumber")]
        public double IssueNumber { get; set; }

        /// <summary>
        /// Gets or sets the variant description.
        /// </summary>
        [DataMember(Name = "variantDescription")]
        public string VariantDescription { get; set; }

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
        /// Gets or sets the ISBN.
        /// </summary>
        [DataMember(Name = "isbn")]
        public string Isbn { get; set; }

        /// <summary>
        /// Gets or sets the UPC.
        /// </summary>
        [DataMember(Name = "upc")]
        public string Upc { get; set; }

        /// <summary>
        /// Gets or sets the diamond code.
        /// </summary>
        [DataMember(Name = "diamondCode")]
        public string DiamondCode { get; set; }
        
        /// <summary>
        /// Gets or sets the EAN.
        /// </summary>
        [DataMember(Name = "ean")]
        public string Ean { get; set; }
        
        /// <summary>
        /// Gets or sets the ISSN.
        /// </summary>
        [DataMember(Name = "issn")]
        public string Issn { get; set; }

        /// <summary>
        /// Gets or sets the Format.
        /// </summary>
        [DataMember(Name = "format")]
        public string Format { get; set; }

        /// <summary>
        /// Gets or sets the page count.
        /// </summary>
        [DataMember(Name = "pageCount")]
        public int PageCount { get; set; }

        /// <summary>
        /// Gets or sets the text objects.
        /// </summary>
        [DataMember(Name = "textObjects")]
        public TextObject[] TextObjects { get; set; }

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
        /// Gets or sets the series.
        /// </summary>
        [DataMember(Name = "series")]
        public Summary Series { get; set; }

        /// <summary>
        /// Gets or sets the variants.
        /// </summary>
        [DataMember(Name = "variants")]
        public Summary[] Variants { get; set; }

        /// <summary>
        /// Gets or sets the collections.
        /// </summary>
        [DataMember(Name = "collections")]
        public Summary[] Collections { get; set; }

        /// <summary>
        /// Gets or sets the collected issues.
        /// </summary>
        [DataMember(Name = "collectedIssues")]
        public Summary[] CollectedIssues { get; set; }

        /// <summary>
        /// Gets or sets the dates.
        /// </summary>
        [DataMember(Name = "dates")]
        public ComicDate[] Dates { get; set; }

        /// <summary>
        /// Gets or sets the prices.
        /// </summary>
        [DataMember(Name = "prices")]
        public ComicPrice[] Prices { get; set; }

        /// <summary>
        /// Gets or sets the thumbnail.
        /// </summary>
        [DataMember(Name = "thumbnail")]
        public Image Thumbnail { get; set; }

        /// <summary>
        /// Gets or sets the images.
        /// </summary>
        [DataMember(Name = "images")]
        public Image[] Images { get; set; }

        /// <summary>
        /// Gets or sets the creators.
        /// </summary>
        [DataMember(Name = "creators")]
        public DataList<Summary> Creators { get; set; }

        /// <summary>
        /// Gets or sets the characters.
        /// </summary>
        [DataMember(Name = "characters")]
        public DataList<Summary> Characters { get; set; }

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
        /// Gets a unique identifier.
        /// </summary>
        public string UniqueId
        {
            get
            {
                return string.Format("comic-{0}", this.Id);
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