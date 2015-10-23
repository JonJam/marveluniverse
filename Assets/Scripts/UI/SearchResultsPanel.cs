namespace MarvelUniverse.UI
{
    using System.Collections.Generic;
    using Controls;
    using Screen;
    using UnityEngine;
    using UnityEngine.UI;
    using ViewModels;
    using Zenject;

    /// <summary>
    /// The search results panel.
    /// </summary>
    public class SearchResultsPanel : MonoBehaviour
    {
        /// <summary>
        /// The screen manager.
        /// </summary>
        private IScreenManager screenManager;

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
                this.SearchResultsListView.gameObject.SetActive(true);
                this.SearchResultsListView.DisplayItems(searchResults);
            }
            else
            {
                this.NoSearchResultsText.gameObject.SetActive(true);
            }
        }

        /// <summary>
        /// Clear the search results.
        /// </summary>
        public void ClearSearchResults()
        {
            this.SearchResultsListView.gameObject.SetActive(false);
            this.NoSearchResultsText.gameObject.SetActive(false);

            this.SearchResultsListView.ClearItems();            
        }

        /// <summary>
        /// Injection initialization.
        /// </summary>
        /// <param name="screenManager">The screen manaager.</param>
        [PostInject]
        private void InjectionInitialize(
            IScreenManager screenManager)
        {
            this.screenManager = screenManager;
        }

        /// <summary>
        /// Handles the on back button clicked event.
        /// </summary>
        public void OnBackButtonClicked()
        {
            this.screenManager.GoBack();

            this.ClearSearchResults();
        }
    }
}
