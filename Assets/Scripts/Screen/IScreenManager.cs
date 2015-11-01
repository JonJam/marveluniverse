namespace MarvelUniverse.Screen
{
    using System.Collections.Generic;
    using Model.Comic;
    using Model.Character;
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
        /// <param name="character">The character.</param>
        void OpenInfoPanel(Character character);

        /// <summary>
        /// Open the info panel.
        /// </summary>
        /// <param name="comic">The comic.</param>
        void OpenInfoPanel(Comic comic);

        /// <summary>
        /// Close the currently open screen and reverting the selected element.
        /// </summary>
        void CloseCurrent();
    }
}