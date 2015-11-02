namespace MarvelUniverse.UI.Screens.DetailsPanel
{
    using System.Linq;
    using Controls;
    using Model.Creator;
    using UnityEngine.UI;

    /// <summary>
    /// The creator details panel.
    /// </summary>
    public class CreatorDetailsPanel : BaseDetailsPanel
    {
        /// <summary>
        /// The full name text.
        /// </summary>
        public Text FullName;

        /// <summary>
        /// The URL list view.
        /// </summary>
        public ListView UrlListView;

        /// <summary>
        /// Hooks up this with the specified creator.
        /// </summary>
        /// <param name="creator">The creator.</param>
        public void HookUp(Creator creator)
        {
            if (creator != null)
            {
                this.SetTextToDisplay(this.FullName, creator.FullName);

                this.SetListItems(this.UrlListView, creator.Urls != null ? creator.Urls.OrderBy(u => u.DisplayType) : null);
            }
        }
    }
}
