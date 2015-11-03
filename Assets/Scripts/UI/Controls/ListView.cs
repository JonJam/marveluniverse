namespace MarvelUniverse.UI.Controls
{
    using System.Collections.Generic;
    using Templates;
    using UnityEngine;
    using UnityEngine.UI;
    using Zenject;

    /// <summary>
    /// A list view.
    /// </summary>
    public class ListView : MonoBehaviour
    {
        /// <summary>
        /// The content panel.
        /// </summary>
        public Transform ContentPanel;

        /// <summary>
        /// The item template.
        /// </summary>
        public GameObject ItemTemplate;

        /// <summary>
        /// The instantiator.
        /// </summary>
        private IInstantiator instantiator;

        /// <summary>
        /// The list view items.
        /// </summary>
        private IList<GameObject> listViewItems = new List<GameObject>();

        /// <summary>
        /// The scroll rect.
        /// </summary>
        private ScrollRect scrollRect;

        /// <summary>
        /// Display the specified items.
        /// </summary>
        /// <typeparam name="T">The type of items to display.</typeparam>
        /// <param name="itemsToDisplay">The items to display.</param>
        public void DisplayItems<T>(IEnumerable<T> itemsToDisplay)
        {
            this.ClearItems();

            foreach (T itemToDisplay in itemsToDisplay)
            {
                GameObject listItem = this.instantiator.InstantiatePrefab(this.ItemTemplate) as GameObject;

                IItemTemplate<T> itemTemplate = listItem.GetComponent<IItemTemplate<T>>();
                itemTemplate.Hookup(itemToDisplay);

                listItem.transform.SetParent(this.ContentPanel, false);

                this.listViewItems.Add(listItem);
            }
        }

        /// <summary>
        /// Clear items.
        /// </summary>
        public void ClearItems()
        {
            foreach (GameObject listItem in this.listViewItems)
            {
                GameObject.Destroy(listItem);
            }

            if (this.scrollRect != null)
            {
                this.scrollRect.verticalNormalizedPosition = 1;
            }

            this.listViewItems = new List<GameObject>();                
        }

        /// <summary>
        /// Injection initialization.
        /// </summary>
        /// <param name="IInstantiator">The instantiator.</param>
        [PostInject]
        private void InjectionInitialize(
            IInstantiator instantiator)
        {
            this.instantiator = instantiator;
        }

        /// <summary>
        /// Handles the awake event.
        /// </summary>
        private void Awake()
        {
            this.scrollRect = this.GetComponent<ScrollRect>();
        }
    }
}
