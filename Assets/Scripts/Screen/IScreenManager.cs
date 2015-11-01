namespace MarvelUniverse.Screen
{
    using System.Collections.Generic;
    using Model.Comic;
    using Model.Character;
    using ViewModels;
    using Model.Creator;
    using Model.Story;
    using Model.Series;

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
        /// Open the info panel.
        /// </summary>
        /// <param name="comicEvent">The event.</param>
        void OpenInfoPanel(Model.Event.Event comicEvent);

        /// <summary>
        /// Open the info panel.
        /// </summary>
        /// <param name="creator">The creator.</param>
        void OpenInfoPanel(Creator creator);

        /// <summary>
        /// Open the info panel.
        /// </summary>
        /// <param name="story">The story.</param>
        void OpenInfoPanel(Story story);

        /// <summary>
        /// Open the info panel.
        /// </summary>
        /// <param name="series">The series.</param>
        void OpenInfoPanel(Series series);

        /// <summary>
        /// Close the currently open screen and reverting the selected element.
        /// </summary>
        void CloseCurrent();
    }
}