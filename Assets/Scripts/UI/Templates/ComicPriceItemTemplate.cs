namespace MarvelUniverse.UI.Templates
{
    using Controls;
    using Model.Comic;
    using Model;
    using UnityEngine;
    using UnityEngine.UI;

    /// <summary>
    /// The comic price item template.
    /// </summary>
    public class ComicPriceItemTemplate : MonoBehaviour, IItemTemplate<ComicPrice>
    {        
        /// <summary>
        /// The price type.
        /// </summary>
        public Text PriceType;

        public Text Price;
        
        /// <summary>
        /// Hook up item to template.
        /// </summary>
        /// <param name="item">The item to display.</param>
        public void Hookup(ComicPrice item)
        {
            this.PriceType.text = item.DisplayType;
            this.Price.text = item.Price;
        }        
    }
}
