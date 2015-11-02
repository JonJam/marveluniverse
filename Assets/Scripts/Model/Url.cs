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

        /// <summary>
        /// Get the type to display.
        /// </summary>
        public string DisplayType
        {
            get
            {
                string displayText = null;

                switch (this.Type)
                {
                    case "comiclink":
                        displayText = "Comic link";
                        break;
                    case "wiki":
                        displayText = "Wiki link";
                        break;
                    case "detail":
                        displayText = "Detail link";
                        break;
                    default:
                        displayText = this.Type;
                        break;
                }

                return displayText;
            }
        }
    }
}