namespace MarvelUniverse.UI.Screens.DetailsPanel
{
    using System.Linq;
    using Controls;
    using UnityEngine.UI;

    /// <summary>
    /// The event details panel.
    /// </summary>
    public class EventDetailsPanel : BaseDetailsPanel
    {
        /// <summary>
        /// The title text.
        /// </summary>
        public Text Title;

        /// <summary>
        /// The description text.
        /// </summary>
        public Text Description;

        /// <summary>
        /// The start date text.
        /// </summary>
        public Text StartDate;

        /// <summary>
        /// The end date text.
        /// </summary>
        public Text EndDate;

        /// <summary>
        /// The URL list view.
        /// </summary>
        public ListView UrlListView;

        /// <summary>
        /// Hooks up this with the specified comic event.
        /// </summary>
        /// <param name="comicEvent">The comicEvent.</param>
        public void HookUp(Model.Event.Event comicEvent)
        {
            if (comicEvent != null)
            {
                this.SetTextToDisplay(this.Title, comicEvent.Title);
                this.SetTextToDisplay(this.Description, comicEvent.CleanDescription);
                this.SetTextToDisplay(this.StartDate, comicEvent.DisplayStartDate, this.StartDate.transform.parent.gameObject);
                this.SetTextToDisplay(this.EndDate, comicEvent.DisplayEndDate, this.EndDate.transform.parent.gameObject);

                this.SetListItems(this.UrlListView, comicEvent.Urls != null ? comicEvent.Urls.OrderBy(u => u.DisplayType) : null);
            }
        }
    }
}
