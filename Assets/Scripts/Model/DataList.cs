namespace MarvelUniverse.Model
{
    using System.Runtime.Serialization;

    /// <summary>
    /// A data list.
    /// </summary>
    /// <typeparam name="T">The type of the data contained.</typeparam>
    [DataContract]
    public class DataList<T>
    {
        /// <summary>
        /// Gets or sets the amount of items available.
        /// </summary>
        [DataMember(Name = "available")]
        public int Available { get; set; }

        /// <summary>
        /// Gets or sets the amount of items returned.
        /// </summary>
        [DataMember(Name = "returned")]
        public int Returned { get; set; }

        /// <summary>
        /// Gets or sets the collection URI.
        /// </summary>
        [DataMember(Name = "collectionURI")]
        public string CollectionURI { get; set; }

        /// <summary>
        /// Gets or sets the items.
        /// </summary>
        [DataMember(Name = "items")]
        public T[] Items { get; set; }
    }
}