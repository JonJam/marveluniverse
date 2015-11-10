namespace MarvelUniverse.Model
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// A summary.
    /// </summary>
    [DataContract]
    public class Summary
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
        /// Gets a value indicating whether has data.
        /// </summary>
        public bool HasData
        {
            get
            {
                Uri uri = null;

                return !string.IsNullOrEmpty(this.Name) &&
                    !string.IsNullOrEmpty(this.ResourceURI) &&
                    Uri.TryCreate(this.ResourceURI, UriKind.Absolute, out uri);
            }
        }
    }
}