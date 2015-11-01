namespace MarvelUniverse.Model.Comic
{
    using System.Runtime.Serialization;

    /// <summary>
    /// A text object.
    /// </summary>
    [DataContract]
    public class TextObject
    {
        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        [DataMember(Name = "type")]
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the language.
        /// </summary>
        [DataMember(Name = "language")]
        public string Language { get; set; }

        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        [DataMember(Name = "text")]
        public string Text { get; set; }
    }
}