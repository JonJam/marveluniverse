namespace MarvelUniverse.Model
{
    using System.Runtime.Serialization;

    /// <summary>
    /// A URL.
    /// </summary>
    [DataContract]
    public class Url
    {
        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        [DataMember(Name = "type")]
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        [DataMember(Name = "url")]
        public string Value { get; set; }
    }
}