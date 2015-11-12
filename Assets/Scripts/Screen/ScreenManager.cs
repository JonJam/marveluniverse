namespace MarvelUniverse.Screen
{
    using System.Collections.Generic;
    using System.Linq;
    using UI.Screens;
    using UnityEngine;
    using UnityEngine.EventSystems;
    using UnityEngine.UI;
    using ViewModels;

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
        private IScreen searchPanel;

        /// <summary>
        /// The search results panel.
        /// </summary>
        private IScreen searchResultsPanel;

        /// <summary>
        /// The info panel.
        /// </summary>
        private IScreen infoPanel;

        /// <summary>
        /// The explorer panel.
        /// </summary>
        private IScreen explorerPanel;

        /// <summary>
        /// The jump gate panel.
        /// </summary>
        private IScreen jumpGatePanel;

        /// <summary>
        /// Initializes a new instance of the <see cref="ScreenManager"/> class.
        /// </summary>
        /// <param name="searchPanel">The search panel.</param>
        /// <param name="searchResultsPanel">The search results panel.</param>
        /// <param name="infoPanel">The info panel.</param>
        /// <param name="explorerPanel">The explorer panel.</param>
        /// <param name="jumpGatePanel">The jump gate panel.</param>
        public ScreenManager(
            IScreen searchPanel,
            IScreen searchResultsPanel,
            IScreen infoPanel,
            IScreen explorerPanel,
            IScreen jumpGatePanel)
        {
            this.searchPanel = searchPanel;
            this.searchResultsPanel = searchResultsPanel;
            this.infoPanel = infoPanel;
            this.explorerPanel = explorerPanel;
            this.jumpGatePanel = jumpGatePanel;
        }

        /// <summary>
        /// Opens the search panel.
        /// </summary>
        public void OpenSearchPanel()
        {
            this.OpenPanel(this.searchPanel.GameObject);
        }
        
        /// <summary>
        /// Opens the search results.
        /// </summary>
        /// <param name="searchResults">The search results.</param>
        public void OpenSearchResults(IEnumerable<SearchResultViewModel> searchResults)
        {
            this.OpenPanel(this.searchResultsPanel.GameObject);
            this.searchResultsPanel.OnOpen(searchResults);
        }

        /// <summary>
        /// Open the info panel.
        /// </summary>
        /// <param name="openParameter">The open parameter.</param>
        public void OpenInfoPanel(object openParameter)
        {
            this.OpenPanel(this.infoPanel.GameObject);
            this.infoPanel.OnOpen(openParameter);
        }

        /// <summary>
        /// Open the explorer panel.
        /// </summary>
        public void OpenExplorerPanel()
        {
            this.OpenPanel(this.explorerPanel.GameObject);
        }

        /// <summary>
        /// Open jump gate panel.
        /// </summary>
        /// <param name="jumpOptions">The jump options.</param>
        public void OpenJumpGatePanel(IEnumerable<JumpOptionViewModel> jumpOptions)
        {
            this.OpenPanel(this.jumpGatePanel.GameObject);
            this.jumpGatePanel.OnOpen(jumpOptions);
        }

        /// <summary>
        /// Close the currently open screen and reverting the selected element.
        /// </summary>
        public void CloseCurrent()
        {
            if (this.currentlyOpenScreen != null)
            {
                IScreen screen = this.currentlyOpenScreen.GetComponent<IScreen>();

                if (screen != null)
                {
                    screen.OnClosing();
                }

                this.currentlyOpenScreen.SetActive(false);

                this.currentlyOpenScreen = null;
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
                // Save the currently selected button that was used to open this Screen. (CloseCurrent will modify it)
                GameObject newPreviouslySelected = EventSystem.current.currentSelectedGameObject;

                if (this.currentlyOpenScreen == null &&
                    newPreviouslySelected != null)
                {
                    this.currentlyOpenScreen = newPreviouslySelected.transform.parent.gameObject;
                }
                
                this.CloseCurrent();
                
                // Set the new Screen as then open one.
                this.currentlyOpenScreen = newScreen;

                // Set an element in the new screen as the new Selected one.
                GameObject newSelectedGameObject = this.FindFirstEnabledSelectable(newScreen);
                this.SetSelected(newSelectedGameObject);
                
                // Back the Screen to front.
                newScreen.transform.SetAsLastSibling();

                newScreen.SetActive(true);
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
        /// <param name="gameObject">The game object.</param>
        private void SetSelected(GameObject gameObject)
        {
            EventSystem.current.SetSelectedGameObject(gameObject);
        }
    }
}
