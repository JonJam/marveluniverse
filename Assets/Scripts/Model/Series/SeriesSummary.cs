namespace MarvelUniverse.Model.Series
{
    using System.Runtime.Serialization;

    /// <summary>
    /// A series summary
    /// </summary>
    [DataContract]
    public class SeriesSummary
    {
        /// <summary>
        /// Gets or sets the resource URI.
        /// </summary>
        [DataMember(Name = "resourceURI")]
        public string ResourceURI { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        [DataMember(Name = "name")]
        public string Name { get; set; }
    }
}