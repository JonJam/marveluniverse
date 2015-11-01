namespace MarvelUniverse.UI.Controls
{
    using System;
    using UnityEngine;
    using UnityEngine.UI;

    public class Hyperlink : MonoBehaviour
    {
        public Text Text;
        
        private Uri uriToNavigateTo;

        public void SetHyperlink(
            string textToDisplay,
            Uri uriToNavigateTo)
        {
            this.Text.text = textToDisplay;
            this.uriToNavigateTo = uriToNavigateTo;
        }

        public void OnHyperlinkClick()
        {
            Application.OpenURL(uriToNavigateTo.AbsoluteUri);
        }
    }
}
