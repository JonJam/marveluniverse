namespace MarvelUniverse.Screen
{
    using System.Collections.Generic;
    using ViewModels;

    /// <summary>
    /// Interface for a screen manager.
    /// </summary>
    public interface IScreenManager
    {
        /// <summary>
        /// Opens the search panel.
        /// </summary>
        void OpenSearchPanel();

        /// <summary>
        /// Opens the search results.
        /// </summary>
        /// <param name="searchResults">The search results.</param>
        void OpenSearchResults(IList<SearchResultViewModel> searchResults);

        /// <summary>
        /// Open the info panel.
        /// </summary>
        /// <param name="openParameter">The open parameter.</param>
        void OpenInfoPanel(object openParameter);

        /// <summary>
        /// Open the explorer panel.
        /// </summary>
        void OpenExplorerPanel();

        /// <summary>
        /// Close the currently open screen and reverting the selected element.
        /// </summary>
        void CloseCurrent();
    }
}