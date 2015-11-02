namespace MarvelUniverse.UI.Templates
{
    using Model.Comic;
    using UnityEngine;
    using UnityEngine.UI;

    /// <summary>
    /// The comic data item template.
    /// </summary>
    public class ComicDateItemTemplate : MonoBehaviour, IItemTemplate<ComicDate>
    {        
        /// <summary>
        /// The date type text.
        /// </summary>
        public Text DateType;

        /// <summary>
        /// The date text.
        /// </summary>
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
