namespace MarvelUniverse.Responses.Comic
{
    using System;
    using Event;
    using Character;
    using Story;
    using Creator;
    using Series;
    using Newtonsoft.Json;

    public class Comic
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("digitalId")]
        public int DigitalId { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("issueNumber")]
        public double IssueNumber { get; set; }

        [JsonProperty("variantDescription")]
        public string VariantDescription { get; set; }
        
        [JsonProperty("description")]
        public string Description { get; set; }
        
        [JsonProperty("modified")]
        public DateTime Modified { get; set; }

        [JsonProperty("isbn")]
        public string Isbn { get; set; }

        [JsonProperty("upc")]
        public string Upc { get; set; }

        [JsonProperty("diamondCode")]
        public string DiamondCode { get; set; }

        [JsonProperty("ean")]
        public string Ean { get; set; }
        
        [JsonProperty("issn")]
        public string Issn { get; set; }

        [JsonProperty("format")]
        public string Format { get; set; }
        
        [JsonProperty("pageCount")]
        public int PageCount { get; set; }
        
        [JsonProperty("textObjects")]
        public TextObject[] TextObjects { get; set; }
        
        [JsonProperty("resourceURI")]
        public string ResourceURI { get; set; }

        [JsonProperty("urls")]
        public Url[] Urls { get; set; }

        [JsonProperty("series")]
        public SeriesSummary Series { get; set; }

        [JsonProperty("variants")]
        public ComicSummary[] Variants { get; set; }

        [JsonProperty("collections")]
        public ComicSummary[] Collections { get; set; }

        [JsonProperty("collectedIssues")]
        public ComicSummary[] CollectedIssues { get; set; }
        
        [JsonProperty("dates")]
        public ComicDate[] Dates { get; set; }

        [JsonProperty("prices")]
        public ComicPrice[] Prices { get; set; }

        [JsonProperty("thumbnail")]
        public Image Thumbnail { get; set; }

        [JsonProperty("images")]
        public Image[] Images { get; set; }
        
        [JsonProperty("creators")]
        public DataList<CreatorSummary> Creators { get; set; }

        [JsonProperty("characters")]
        public DataList<CharacterSummary> Characters { get; set; }
        
        [JsonProperty("stories")]
        public DataList<StorySummary> Stories { get; set; }

        [JsonProperty("events")]
        public DataList<EventSummary> Events { get; set; }
    }
}