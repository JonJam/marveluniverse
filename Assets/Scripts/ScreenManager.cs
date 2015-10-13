namespace MarvelUniverse
{
    using UnityEngine;
    using UnityEngine.EventSystems;
    using UnityEngine.UI;
    using System.Linq;
    using System.Collections;

    /// <summary>
    /// Screen manager. Based upon <see cref="http://docs.unity3d.com/Manual/HOWTO-UIScreenTransition.html"/>.
    /// </summary>
    public class ScreenManager : MonoBehaviour
    {
        /// <summary>
        /// The open transition name.
        /// </summary>
        private const string openTransitionName = "Open";

        /// <summary>
        /// The closed state name.
        /// </summary>
        private const string closedStateName = "Closed";

        /// <summary>
        /// Currently Open Screen.
        /// </summary>
        private Animator currentOpenScreen;

        /// <summary>
        /// The open animation parameter hash identifier.
        /// </summary>
        private int openParameterId;

        /// <summary>
        /// The GameObject Selected before we opened the current Screen. Used when closing a Screen, so we can go back to the button that opened it.
        /// </summary>
        private GameObject previouslySelected;

        /// <summary>
        /// Screen to open automatically at the start of the Scene
        /// </summary>
        public Animator StartScreen;

        /// <summary>
        /// Open the specified panel, closing the previous and setting the new selected element.
        /// </summary>
        /// <param name="newScreenAnimator">The new screen to open.</param>
        public void OpenPanel(Animator newScreenAnimator)
        {
            if (this.currentOpenScreen != newScreenAnimator)
            {
                //Activate the new Screen hierarchy so we can animate it.
                newScreenAnimator.gameObject.SetActive(true);

                //Save the currently selected button that was used to open this Screen. (CloseCurrent will modify it)
                GameObject newPreviouslySelected = EventSystem.current.currentSelectedGameObject;

                //Move the Screen to front.
                newScreenAnimator.transform.SetAsLastSibling();

                this.CloseCurrent();

                this.previouslySelected = newPreviouslySelected;

                //Set the new Screen as then open one.
                this.currentOpenScreen = newScreenAnimator;
                this.currentOpenScreen.SetBool(this.openParameterId, true);

                //Set an element in the new screen as the new Selected one.
                GameObject newSelectedGameObject = this.FindFirstEnabledSelectable(newScreenAnimator.gameObject);
                this.SetSelected(newSelectedGameObject);
            }
        }

        /// <summary>
        /// Finds the first Selectable element in the provided hierarchy.
        /// </summary>
        /// <param name="root">The root</param>
        /// <returns>THe first selectable element in the provided hierarchy.</returns>
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
        /// Close the currently open screen, reverting the selected element and opening the previous screen.
        /// </summary>
        public void CloseCurrent()
        {
            if (this.currentOpenScreen != null)
            {
                this.currentOpenScreen.SetBool(this.openParameterId, false);

                this.SetSelected(previouslySelected);

                this.StartCoroutine(this.DisablePanelWhenClosingAnimationFinished(this.currentOpenScreen));

                this.currentOpenScreen = null;
            }
        }

        /// <summary>
        /// Handles the awake event.
        /// </summary>
        private void Awake()
        {
            this.openParameterId = Animator.StringToHash(openTransitionName);
        }

        /// <summary>
        /// Handles the on enable event.
        /// </summary>
        private void OnEnable()
        {
            if (this.StartScreen == null)
            {
                return;
            }

            this.OpenPanel(this.StartScreen);
        }
    
        /// <summary>
        /// Set the specified game object as selected.
        /// </summary>
        /// <param name="gameObject"></param>
        private void SetSelected(GameObject gameObject)
        {
            EventSystem.current.SetSelectedGameObject(gameObject);
        }

        /// <summary>
        /// Coroutine that will detect when the Closing animation is finished and it will deactivate the hierarchy.
        /// </summary>
        /// <param name="screenAnimator"></param>
        /// <returns></returns>
        private IEnumerator DisablePanelWhenClosingAnimationFinished(Animator screenAnimator)
        {
            bool closedStateReached = false;
            bool wantToClose = true;

            while (!closedStateReached && wantToClose)
            {
                if (!screenAnimator.IsInTransition(0))
                {
                    closedStateReached = screenAnimator.GetCurrentAnimatorStateInfo(0).IsName(ScreenManager.closedStateName);
                }

                wantToClose = !screenAnimator.GetBool(this.openParameterId);

                yield return new WaitForEndOfFrame();
            }

            if (wantToClose)
            {
                screenAnimator.gameObject.SetActive(false);
            }
        }
    }
}
