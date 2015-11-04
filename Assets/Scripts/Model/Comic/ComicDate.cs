namespace MarvelUniverse.Model.Comic
{
    using Extensions;
    using System.Runtime.Serialization;
    using System;

    /// <summary>
    /// A comic date.
    /// </summary>
    [DataContract]
    public class ComicDate
    {
        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        [DataMember(Name = "type")]
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the date.
        /// </summary>
        [DataMember(Name = "date")]
        public string Date { get; set; }

        /// <summary>
        /// Gets a value indicating whether has data.
        /// </summary>
        public bool HasData
        {
            get
            {
                DateTime date = DateTime.MinValue;

                return !string.IsNullOrEmpty(this.Date) &&
                    DateTime.TryParse(this.Date, out date);
            }
        }

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
                    case "onsaleDate":
                        displayType = "On Sale";
                        break;
                    case "focDate":
                        displayType = "Final Order Cut-off";
                        break;
                    case "digitalPurchaseDate":
                        displayType = "Digital Purchase";
                        break;
                    case "unlimitedDate":
                        displayType = "Unlimited";
                        break;
                    default:
                        displayType = this.Type;
                        break;
                }

                return displayType;
            }
        }

        /// <summary>
        /// Gets the display date.
        /// </summary>
        public string DisplayDate
        {
            get
            {
                return !string.IsNullOrEmpty(this.Date) ? this.Date.ToDisplayDate() : null;
            }
        }
    }
}