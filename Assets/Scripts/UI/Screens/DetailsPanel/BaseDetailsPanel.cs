namespace MarvelUniverse.UI.Screens.DetailsPanel
{
    using System.Collections.Generic;
    using System.Linq;
    using Controls;
    using UnityEngine;
    using UnityEngine.UI;

    /// <summary>
    /// The base details panel.
    /// </summary>
    public abstract class BaseDetailsPanel : MonoBehaviour
    {
        /// <summary>
        /// Sets the text of the Text object.
        /// </summary>
        /// <param name="text">The Text object.</param>
        /// <param name="stringToDisplay">The string to display.</param>
        protected void SetTextToDisplay(Text text, string stringToDisplay)
        {
            if (!string.IsNullOrEmpty(stringToDisplay))
            {
                text.gameObject.SetActive(true);
                text.text = stringToDisplay;
            }
            else
            {
                text.gameObject.SetActive(false);
                text.text = null;
            }
        }

        /// <summary>
        /// Sets the list items of the ListView object.
        /// </summary>
        /// <typeparam name="T">The type of the list item.</typeparam>
        /// <param name="listView">The list view.</param>
        /// <param name="listItems">The list items.</param>
        protected void SetListItems<T>(ListView listView, IEnumerable<T> listItems)
        {
            if (listItems != null &&
                listItems.Count() > 0)
            {
                listView.gameObject.SetActive(true);
                listView.DisplayItems(listItems);
            }
            else
            {
                listView.gameObject.SetActive(false);
                listView.ClearItems();
            }
        }
    }
}
