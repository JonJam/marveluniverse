namespace MarvelUniverse.Model
{
    using System.Runtime.Serialization;

    /// <summary>
    /// The data wrapper.
    /// </summary>
    /// <typeparam name="T">The type of the API object</typeparam>
    [DataContract]
    public class DataWrapper<T>
    {
        /// <summary>
        /// Gets or sets the code.
        /// </summary>
        [DataMember(Name = "code")]
        public int Code { get; set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        [DataMember(Name = "status")]
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets the copyright.
        /// </summary>
        [DataMember(Name = "copyright")]
        public string Copyright { get; set; }

        /// <summary>
        /// Gets or sets the attribution text.
        /// </summary>
        [DataMember(Name = "attributionText")]
        public string AttributionText { get; set; }

        /// <summary>
        /// Gets or sets the attribution HTML.
        /// </summary>
        [DataMember(Name = "attributionHTML")]
        public string AttributionHTML { get; set; }

        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        [DataMember(Name = "data")]
        public DataContainer<T> Data { get; set; }

        /// <summary>
        /// Gets or sets the ETAG.
        /// </summary>
        [DataMember(Name = "etag")]
        public string Etag { get; set; }
    }
}