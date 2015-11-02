namespace MarvelUniverse.Model.Comic
{
    using System.Runtime.Serialization;

    /// <summary>
    /// A comic price.
    /// </summary>
    [DataContract]
    public class ComicPrice
    {
        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        [DataMember(Name = "type")]
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the price.
        /// </summary>
        [DataMember(Name = "price")]
        public string Price { get; set; }
                
        /// <summary>
        /// Gets the type to display.
        /// </summary>
        public string DisplayType
        {
            get
            {
                string displayType = null;

                switch (this.Type)
                {
                    case "printPrice":
                        displayType = "Print Price";
                        break;
                    default:
                        displayType = this.Type;
                        break;
                }

                return displayType;
            }
        }
    }
}