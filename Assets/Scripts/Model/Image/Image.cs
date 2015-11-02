namespace MarvelUniverse.Model.Image
{
    using System.Runtime.Serialization;

    /// <summary>
    /// An image.
    /// </summary>
    [DataContract]
    public class Image
    {
        /// <summary>
        /// Gets or sets the path.
        /// </summary>
        [DataMember(Name = "path")]
        public string Path { get; set; }

        /// <summary>
        /// Gets or sets the extension.
        /// </summary>
        [DataMember(Name = "extension")]
        public string Extension { get; set; }

        /// <summary>
        /// Gets a value indicating whether has data.
        /// </summary>
        public bool HasData
        {
            get
            {
                return !string.IsNullOrEmpty(this.Path) &&
                    !string.IsNullOrEmpty(this.Extension);
            }
        }
    }
}