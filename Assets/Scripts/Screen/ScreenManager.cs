namespace MarvelUniverse.Screen
{
    using System.Linq;
    using ViewModels;
    using UnityEngine;
    using UnityEngine.EventSystems;
    using UnityEngine.UI;
    using System.Collections.Generic;
    using UI;
    using Model.Character;
    using Model.Comic;

    /// <summary>
    /// Screen manager. Based upon <see cref="http://docs.unity3d.com/Manual/HOWTO-UIScreenTransition.html"/>.
    /// </summary>
    public class ScreenManager : IScreenManager
    {
        /// <summary>
        /// Currently open screen.
        /// </summary>
        private GameObject currentlyOpenScreen;

        /// <summary>
        /// The search panel.
        /// </summary>
        private SearchPanel searchPanel;

        /// <summary>
        /// The search results panel.
        /// </summary>
        private SearchResultsPanel searchResultsPanel;

        /// <summary>
        /// The info panel.
        /// </summary>
        private InfoPanel infoPanel;

        /// <summary>
        /// Initializes a new instance of the <see cref="ScreenManager"/>
        /// </summary>
        /// <param name="searchPanel">The search panel.</param>
        /// <param name="searchResultsPanel">The search results panel.</param>
        /// <param name="infoPanel">The info panel.</param>
        public ScreenManager(
            SearchPanel searchPanel,
            SearchResultsPanel searchResultsPanel,
            InfoPanel infoPanel)
        {
            this.searchPanel = searchPanel;
            this.searchResultsPanel = searchResultsPanel;
            this.infoPanel = infoPanel;
        }

        /// <summary>
        /// Opens the search panel.
        /// </summary>
        public void OpenSearchPanel()
        {
            this.OpenPanel(this.searchPanel.gameObject);
        }
        
        /// <summary>
        /// Opens the search results.
        /// </summary>
        /// <param name="searchResults">The search results.</param>
        public void OpenSearchResults(IList<SearchResultViewModel> searchResults)
        {
            this.OpenPanel(this.searchResultsPanel.gameObject);
            this.searchResultsPanel.DisplaySearchResults(searchResults);
        }

        /// <summary>
        /// Open the info panel.
        /// </summary>
        /// <param name="character">The character.</param>
        public void OpenInfoPanel(Character character)
        {
            this.OpenPanel(this.infoPanel.gameObject);
            this.infoPanel.DisplayInformation(character);
        }

        /// <summary>
        /// Open the info panel.
        /// </summary>
        /// <param name="comic">The comic.</param>
        public void OpenInfoPanel(Comic comic)
        {
            this.OpenPanel(this.infoPanel.gameObject);
            this.infoPanel.DisplayInformation(comic);
        }

        /// <summary>
        /// Open the info panel.
        /// </summary>
        /// <param name="comicEvent">The event.</param>
        public void OpenInfoPanel(Model.Event.Event comicEvent)
        {
            this.OpenPanel(this.infoPanel.gameObject);
            this.infoPanel.DisplayInformation(comicEvent);
        }

        /// <summary>
        /// Close the currently open screen and reverting the selected element.
        /// </summary>
        public void CloseCurrent()
        {
            if (this.currentlyOpenScreen != null)
            {
                this.currentlyOpenScreen.SetActive(false);
            }
        }

        /// <summary>
        /// Open the specified panel, closing the previous and setting the new selected element.
        /// </summary>
        /// <param name="newScreen">The new screen.</param>
        private void OpenPanel(GameObject newScreen)
        {
            if (this.currentlyOpenScreen != newScreen)
            {
                //Activate the new Screen hierarchy so we can animate it.
                newScreen.SetActive(true);

                //Save the currently selected button that was used to open this Screen. (CloseCurrent will modify it)
                GameObject newPreviouslySelected = EventSystem.current.currentSelectedGameObject;

                if (this.currentlyOpenScreen == null &&
                    newPreviouslySelected != null)
                {
                    this.currentlyOpenScreen = newPreviouslySelected.transform.parent.gameObject;
                }

                //Move the Screen to front.
                newScreen.transform.SetAsLastSibling();

                this.CloseCurrent();
                
                //Set the new Screen as then open one.
                this.currentlyOpenScreen = newScreen;

                //Set an element in the new screen as the new Selected one.
                GameObject newSelectedGameObject = this.FindFirstEnabledSelectable(newScreen);
                this.SetSelected(newSelectedGameObject);
            }
        }

        /// <summary>
        /// Finds the first Selectable element in the provided hierarchy.
        /// </summary>
        /// <param name="root">The root</param>
        /// <returns>The first selectable element in the provided hierarchy.</returns>
        private GameObject FindFirstEnabledSelectable(GameObject root)
        {
            Selectable newSelectable = root.GetComponentsInChildren<Selectable>(true).FirstOrDefault(s => s.IsActive() && s.IsInteractable());

            GameObject newSelectedGameObject = null;

            if (newSelectable != null)
            {
                newSelectedGameObject = newSelectable.gameObject;
            }

            return newSelectedGameObject;
        }
    
        /// <summary>
        /// Set the specified game object as selected.
        /// </summary>
        /// <param name="gameObject"></param>
        private void SetSelected(GameObject gameObject)
        {
            EventSystem.current.SetSelectedGameObject(gameObject);
        }
    }
}
