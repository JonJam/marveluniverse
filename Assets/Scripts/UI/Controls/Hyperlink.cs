namespace MarvelUniverse.UI.Controls
{
    using System;
    using UnityEngine;
    using UnityEngine.UI;

    /// <summary>
    /// The hyperlink.
    /// </summary>
    public class Hyperlink : MonoBehaviour
    {
        /// <summary>
        /// The display text.
        /// </summary>
        public Text DisplayText;
        
        /// <summary>
        /// URI to navigate to.
        /// </summary>
        private Uri uriToNavigateTo;

        /// <summary>
        /// Set hyperlink.
        /// </summary>
        /// <param name="textToDisplay">The text to display.</param>
        /// <param name="uriToNavigateTo">The URI to navigate to.</param>
        public void SetHyperlink(
            string textToDisplay,
            Uri uriToNavigateTo)
        {
            this.DisplayText.text = textToDisplay;
            this.uriToNavigateTo = uriToNavigateTo;
        }

        /// <summary>
        /// Handles the hyperlink click event.
        /// </summary>
        public void OnHyperlinkClick()
        {
            Application.OpenURL(uriToNavigateTo.AbsoluteUri);
        }
    }
}
