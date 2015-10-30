namespace MarvelUniverse.Screen
{
    using ViewModels;
    using UnityEngine;
    using System.Collections.Generic;

    /// <summary>
    /// Interface for a screen manager.
    /// </summary>
    public interface IScreenManager
    {
        ///// <summary>
        ///// Open the specified panel, closing the previous and setting the new selected element.
        ///// </summary>
        ///// <param name="newScreen">The new screen.</param>
        //void OpenPanel(GameObject newScreen);

        ///// <summary>
        ///// Goes back to the previous screen.
        ///// </summary>
        //void GoBack();

        ///// <summary>
        ///// Close the currently open screen and reverting the selected element.
        ///// </summary>
        //void CloseCurrent();

        void OpenSearchPanel();

        void OpenSearchResults(IList<SearchResultViewModel> searchResults);

        void OpenInfoPanel();

        void CloseCurrent();
    }
}