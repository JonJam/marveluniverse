namespace MarvelUniverse.Model.Story
{
    using System.Runtime.Serialization;

    /// <summary>
    /// A story summary.
    /// </summary>
    [DataContract]
    public class StorySummary
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

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        [DataMember(Name = "type")]
        public string Type { get; set; }
    }
}