namespace MarvelUniverse.UI.Templates
{
    using System;
    using Controls;
    using Model;
    using UnityEngine;

    /// <summary>
    /// The url item template.
    /// </summary>
    public class UrlItemTemplate : MonoBehaviour, IItemTemplate<Url>
    {        
        /// <summary>
        /// The hyperlink.
        /// </summary>
        public Hyperlink Hyperlink;
        
        /// <summary>
        /// Hook up item to template.
        /// </summary>
        /// <param name="item">The item to display.</param>
        public void Hookup(Url item)
        {
            this.Hyperlink.SetHyperlink(item.DisplayType, new Uri(item.Value));           
        }        
    }
}
