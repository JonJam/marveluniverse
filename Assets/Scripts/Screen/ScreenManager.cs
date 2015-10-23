namespace MarvelUniverse.Screen
{
    using System.Linq;
    using UnityEngine;
    using UnityEngine.EventSystems;
    using UnityEngine.UI;

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
        /// Previously open screen.
        /// </summary>
        private GameObject previouslyOpenScreen;

        /// <summary>
        /// The GameObject Selected before we opened the current Screen. Used when closing a Screen, so we can go back to the button that opened it.
        /// </summary>
        private GameObject previouslySelected;
        
        /// <summary>
        /// Open the specified panel, closing the previous and setting the new selected element.
        /// </summary>
        /// <param name="newScreen">The new screen.</param>
        public void OpenPanel(GameObject newScreen)
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

                this.previouslyOpenScreen = this.currentlyOpenScreen;
                this.previouslySelected = newPreviouslySelected;

                //Set the new Screen as then open one.
                this.currentlyOpenScreen = newScreen;

                //Set an element in the new screen as the new Selected one.
                GameObject newSelectedGameObject = this.FindFirstEnabledSelectable(newScreen);
                this.SetSelected(newSelectedGameObject);
            }
        }

        /// <summary>
        /// Goes back to the previous screen.
        /// </summary>
        public void GoBack()
        {
            if (this.previouslyOpenScreen != null)
            {
                this.CloseCurrent();

                this.previouslyOpenScreen.SetActive(true);

                this.currentlyOpenScreen = this.previouslyOpenScreen;

                this.previouslyOpenScreen = null;
            }
        }
        
        /// <summary>
        /// Close the currently open screen and reverting the selected element.
        /// </summary>
        public void CloseCurrent()
        {
            if (this.currentlyOpenScreen != null)
            {
                this.SetSelected(previouslySelected);

                this.currentlyOpenScreen.SetActive(false);
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
