namespace MarvelUniverse.Model.Comic
{
    using System.Runtime.Serialization;

    /// <summary>
    /// A comic date.
    /// </summary>
    [DataContract]
    public class ComicDate
    {
        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        [DataMember(Name = "type")]
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the date.
        /// </summary>
        [DataMember(Name = "date")]
        public string Date { get; set; }
    }
}