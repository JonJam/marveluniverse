﻿namespace MarvelUniverse.ViewModel
{
    /// <summary>
    /// The search view model.
    /// </summary>
    public class SearchViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SearchViewModel"/> class.
        /// </summary>
        public SearchViewModel()
        {
            this.SearchTerms = string.Empty;
        }

        /// <summary>
        /// Gets or sets the search terms.
        /// </summary>
        public string SearchTerms
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the search type index.
        /// </summary>
        public int SearchTypeIndex
        {
            get;
            set;
        }
    }
}
