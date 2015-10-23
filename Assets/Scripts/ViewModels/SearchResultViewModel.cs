namespace MarvelUniverse.ViewModels
{
    /// <summary>
    /// The search results view model.
    /// </summary>
    public class SearchResultViewModel
    {
        /// <summary>
        /// The name.
        /// </summary>
        private readonly string name;

        /// <summary>
        /// The description.
        /// </summary>
        private readonly string description;

        /// <summary>
        /// The image path.
        /// </summary>
        private readonly string imagePath;

        /// <summary>
        /// The image extension.
        /// </summary>
        private readonly string imageExtension;

        /// <summary>
        /// Initializes a new instance of the <see cref="SearchResultViewModel"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="description">The description.</param>
        /// <param name="imagePath">The image path.</param>
        /// <param name="imageExtension">The image extension.</param>
        public SearchResultViewModel(
            string name, 
            string description,
            string imagePath,
            string imageExtension)
        {
            this.name = name;
            this.description = description;
            this.imagePath = imagePath;
            this.imageExtension = imageExtension;
        }

        /// <summary>
        /// Gets the name.
        /// </summary>
        public string Name
        {
            get
            {
                return this.name;
            }
        }

        /// <summary>
        /// Gets the description.
        /// </summary>
        public string Description
        {
            get
            {
                return this.description;
            }
        }

        /// <summary>
        /// Gets the image path.
        /// </summary>
        public string ImagePath
        {
            get
            {
                return this.imagePath;
            }
        }

        /// <summary>
        /// Gets the image extension.
        /// </summary>
        public string ImageExtension
        {
            get
            {
                return this.imageExtension;
            }
        }

        /// <summary>
        /// Performs the search result clicked action.
        /// </summary>
        public void SearchResultClicked()
        {
            // TODO Implement
        }
    }
}
