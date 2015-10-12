namespace MarvelUniverse.UI
{
    using System.Collections.Generic;
    using Controls;
    using UnityEngine;
    using UnityEngine.UI;
    using ViewModel;

    /// <summary>
    /// The search results panel.
    /// </summary>
    public class SearchResultsPanel : MonoBehaviour
    {
        /// <summary>
        /// The search results list view.
        /// </summary>
        public ListView SearchResultsListView;

        /// <summary>
        /// The no search results text.
        /// </summary>
        public Text NoSearchResultsText;

        /// <summary>
        /// Display the search results.
        /// </summary>
        /// <param name="searchResults">The search results.</param>
        public void DisplaySearchResults(IList<SearchResultViewModel> searchResults)
        {
            this.ClearSearchResults();

            if (searchResults != null &&
                searchResults.Count > 0)
            {
                this.SearchResultsListView.DisplayItems(searchResults);
            }
        }

        /// <summary>
        /// Clear the search results.
        /// </summary>
        public void ClearSearchResults()
        {
            this.SearchResultsListView.ClearItems();            
        }
    }
}
