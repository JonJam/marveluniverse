namespace MarvelUniverse.Model.Creator
{
    using System.Runtime.Serialization;

    /// <summary>
    /// A creator summary.
    /// </summary>
    [DataContract]
    public class CreatorSummary
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
        /// Gets or sets the role.
        /// </summary>
        [DataMember(Name = "role")]
        public string Role { get; set; }
    }
}