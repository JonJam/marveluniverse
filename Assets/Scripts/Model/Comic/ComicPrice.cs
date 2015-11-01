namespace MarvelUniverse.Model.Comic
{
    using System.Runtime.Serialization;

    /// <summary>
    /// A comic price.
    /// </summary>
    [DataContract]
    public class ComicPrice
    {
        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        [DataMember(Name = "type")]
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the price.
        /// </summary>
        [DataMember(Name = "price")]
        public string Price { get; set; }
    }
}