namespace MarvelUniverse.Model.Character
{
    using System.Runtime.Serialization;

    /// <summary>
    /// A character summary.
    /// </summary>
    [DataContract]
    public class CharacterSummary
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