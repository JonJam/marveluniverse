namespace MarvelUniverse.UI.Screens
{
    using System.Collections.Generic;
    using System.Linq;
    using Controls;
    using UnityEngine;
    using ViewModels;

    /// <summary>
    /// The jump gate panel.
    /// </summary>
    public class JumpGatePanel : MonoBehaviour, IScreen
    {
        /// <summary>
        /// The jump options list view.
        /// </summary>
        public ListView JumpOptionsListView;

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
            if (openParameter is IEnumerable<JumpOptionViewModel>)
            {
                this.DisplayJumpOptions((IEnumerable<JumpOptionViewModel>)openParameter);
            }
        }

        /// <summary>
        /// Called upon the screen being closed.
        /// </summary>
        public void OnClosing()
        {
            this.ClearJumpOptions();
        }

        /// <summary>
        /// Display the jump options.
        /// </summary>
        /// <param name="jumpOptions">The jump options.</param>
        private void DisplayJumpOptions(IEnumerable<JumpOptionViewModel> jumpOptions)
        {
            this.ClearJumpOptions();

            if (jumpOptions != null &&
                jumpOptions.Count() > 0)
            {
                this.JumpOptionsListView.gameObject.SetActive(true);
                this.JumpOptionsListView.DisplayItems(jumpOptions);
            }
            else
            {
                this.JumpOptionsListView.gameObject.SetActive(true);
            }
        }

        /// <summary>
        /// Clear the jump options.
        /// </summary>
        private void ClearJumpOptions()
        {
            this.JumpOptionsListView.gameObject.SetActive(false);
            this.JumpOptionsListView.gameObject.SetActive(false);

            this.JumpOptionsListView.ClearItems();
        }
    }
}
