namespace MarvelUniverse.Model.Event
{
    using System.Runtime.Serialization;

    /// <summary>
    /// An event summary.
    /// </summary>
    [DataContract]
    public class EventSummary
    {
        /// <summary>
        /// Gets or sets the resource URI. This is a string but using object as some Model return JSON object incorrectly.
        /// </summary>
        [DataMember(Name = "resourceURI")]
        public object ResourceURI { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        [DataMember(Name = "name")]
        public string Name { get; set; }
    }
}