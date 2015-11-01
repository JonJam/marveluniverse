namespace MarvelUniverse.UI.Templates
{
    using Controls;
    using Model.Comic;
    using Model;
    using UnityEngine;
    using UnityEngine.UI;

    /// <summary>
    /// The comic data item template.
    /// </summary>
    public class ComicDateItemTemplate : MonoBehaviour, IItemTemplate<ComicDate>
    {        
        /// <summary>
        /// The date type.
        /// </summary>
        public Text DateType;

        public Text Date;
        
        /// <summary>
        /// Hook up item to template.
        /// </summary>
        /// <param name="item">The item to display.</param>
        public void Hookup(ComicDate item)
        {
            this.DateType.text = item.DisplayType;
            this.Date.text = item.Date;
        }        
    }
}
