namespace MarvelUniverse.Model.Comic
{
    using System;
    using Character;
    using Creator;
    using Event;
    using Image;
    using Newtonsoft.Json;
    using Series;
    using Story;

    /// <summary>
    /// A comic.
    /// </summary>
    public class Comic
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }
        
        /// <summary>
        /// Gets or sets the digital identifier.
        /// </summary>
        [JsonProperty("digitalId")]
        public int DigitalId { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the issue number.
        /// </summary>
        [JsonProperty("issueNumber")]
        public double IssueNumber { get; set; }

        /// <summary>
        /// Gets or sets the variant description.
        /// </summary>
        [JsonProperty("variantDescription")]
        public string VariantDescription { get; set; }

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
        /// Gets or sets the ISBN.
        /// </summary>
        [JsonProperty("isbn")]
        public string Isbn { get; set; }

        /// <summary>
        /// Gets or sets the UPC.
        /// </summary>
        [JsonProperty("upc")]
        public string Upc { get; set; }

        /// <summary>
        /// Gets or sets the diamond code.
        /// </summary>
        [JsonProperty("diamondCode")]
        public string DiamondCode { get; set; }
        
        /// <summary>
        /// Gets or sets the EAN.
        /// </summary>
        [JsonProperty("ean")]
        public string Ean { get; set; }
        
        /// <summary>
        /// Gets or sets the ISSN.
        /// </summary>
        [JsonProperty("issn")]
        public string Issn { get; set; }

        /// <summary>
        /// Gets or sets the Format.
        /// </summary>
        [JsonProperty("format")]
        public string Format { get; set; }

        /// <summary>
        /// Gets or sets the page count.
        /// </summary>
        [JsonProperty("pageCount")]
        public int PageCount { get; set; }

        /// <summary>
        /// Gets or sets the text objects.
        /// </summary>
        [JsonProperty("textObjects")]
        public TextObject[] TextObjects { get; set; }

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
        /// Gets or sets the series.
        /// </summary>
        [JsonProperty("series")]
        public SeriesSummary Series { get; set; }

        /// <summary>
        /// Gets or sets the variants.
        /// </summary>
        [JsonProperty("variants")]
        public ComicSummary[] Variants { get; set; }

        /// <summary>
        /// Gets or sets the collections.
        /// </summary>
        [JsonProperty("collections")]
        public ComicSummary[] Collections { get; set; }

        /// <summary>
        /// Gets or sets the collected issues.
        /// </summary>
        [JsonProperty("collectedIssues")]
        public ComicSummary[] CollectedIssues { get; set; }

        /// <summary>
        /// Gets or sets the dates.
        /// </summary>
        [JsonProperty("dates")]
        public ComicDate[] Dates { get; set; }

        /// <summary>
        /// Gets or sets the prices.
        /// </summary>
        [JsonProperty("prices")]
        public ComicPrice[] Prices { get; set; }

        /// <summary>
        /// Gets or sets the thumbnail.
        /// </summary>
        [JsonProperty("thumbnail")]
        public Image Thumbnail { get; set; }

        /// <summary>
        /// Gets or sets the images.
        /// </summary>
        [JsonProperty("images")]
        public Image[] Images { get; set; }

        /// <summary>
        /// Gets or sets the creators.
        /// </summary>
        [JsonProperty("creators")]
        public DataList<CreatorSummary> Creators { get; set; }

        /// <summary>
        /// Gets or sets the characters.
        /// </summary>
        [JsonProperty("characters")]
        public DataList<CharacterSummary> Characters { get; set; }

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
    }
}