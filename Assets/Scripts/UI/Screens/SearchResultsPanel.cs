﻿namespace MarvelUniverse.UI.Screens
{
    using System.Collections.Generic;
    using System.Linq;
    using Controls;
    using Screen;
    using UnityEngine;
    using UnityEngine.UI;
    using ViewModels;
    using Zenject;

    /// <summary>
    /// The search results panel.
    /// </summary>
    public class SearchResultsPanel : MonoBehaviour, IScreen
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
        /// Gets the game object.
        /// </summary>
        public GameObject GameObject
        {
            get
            {
                return this.gameObject;
            }
        }

        /// <summary>
        /// Called upon screen open.
        /// </summary>
        /// <param name="openParameter">The open parameter.</param>
        public void OnOpen(object openParameter)
        {
            if (openParameter is IEnumerable<SearchResultViewModel>)
            {
                this.DisplaySearchResults((IEnumerable<SearchResultViewModel>)openParameter);
            }
        }

        /// <summary>
        /// Called upon the screen being closed.
        /// </summary>
        public void OnClosing()
        {
            this.ClearSearchResults();
        }
        
        /// <summary>
        /// Display the search results.
        /// </summary>
        /// <param name="searchResults">The search results.</param>
        private void DisplaySearchResults(IEnumerable<SearchResultViewModel> searchResults)
        {
            this.ClearSearchResults();

            if (searchResults != null &&
                searchResults.Count() > 0)
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
        private void ClearSearchResults()
        {
            this.SearchResultsListView.gameObject.SetActive(false);
            this.NoSearchResultsText.gameObject.SetActive(false);

            this.SearchResultsListView.ClearItems();
        }
    }
}
