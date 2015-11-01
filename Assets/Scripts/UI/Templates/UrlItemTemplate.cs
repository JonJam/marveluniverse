namespace MarvelUniverse.UI.Templates
{
    using Controls;
    using Model;
    using UnityEngine;

    /// <summary>
    /// The url item template.
    /// </summary>
    public class UrlItemTemplate : MonoBehaviour, IItemTemplate<Url>
    {        
        /// <summary>
        /// The hyperlink
        /// </summary>
        public Hyperlink hyperlink;
        
        /// <summary>
        /// Hook up item to template.
        /// </summary>
        /// <param name="item">The item to display.</param>
        public void Hookup(Url item)
        {
            this.hyperlink.SetHyperlink(item.DisplayText, new System.Uri(item.Value));           
        }        
    }
}
