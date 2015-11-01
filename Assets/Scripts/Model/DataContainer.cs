namespace MarvelUniverse.Model
{
    using System.Runtime.Serialization;

    /// <summary>
    /// A data container.
    /// </summary>
    /// <typeparam name="T">The type of the data contained.</typeparam>
    [DataContract]
    public class DataContainer<T>
    {
        /// <summary>
        /// Gets or sets the offset.
        /// </summary>
        [DataMember(Name = "offset")]
        public int Offset { get; set; }

        /// <summary>
        /// Gets or sets the limit.
        /// </summary>
        [DataMember(Name = "limit")]
        public int Limit { get; set; }

        /// <summary>
        /// Gets or sets the total.
        /// </summary>
        [DataMember(Name = "total")]
        public int Total { get; set; }

        /// <summary>
        /// Gets or sets the count.
        /// </summary>
        [DataMember(Name = "count")]
        public int Count { get; set; }

        /// <summary>
        /// Gets or sets the results.
        /// </summary>
        [DataMember(Name = "results")]
        public T[] Results { get; set; }
    }
}
