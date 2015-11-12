namespace MarvelUniverse.UI.Screens.DetailsPanel
{
    using System.Linq;
    using Controls;
    using Model.Series;
    using UnityEngine.UI;

    /// <summary>
    /// The series details panel.
    /// </summary>
    public class SeriesDetailsPanel : BaseDetailsPanel
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
        /// The rating text.
        /// </summary>
        public Text Rating;

        /// <summary>
        /// The start year text.
        /// </summary>
        public Text StartYear;

        /// <summary>
        /// The end year text.
        /// </summary>
        public Text EndYear;

        /// <summary>
        /// The URL list view.
        /// </summary>
        public ListView UrlListView;

        /// <summary>
        /// Hooks up this with the specified series.
        /// </summary>
        /// <param name="series">The series.</param>
        public void HookUp(Series series)
        {
            if (series != null)
            {
                this.SetTextToDisplay(this.Title, series.Title);
                this.SetTextToDisplay(this.Description, series.CleanDescription);
                this.SetTextToDisplay(this.StartYear, series.StartYear > 0 ? series.StartYear.ToString() : null, this.StartYear.transform.parent.gameObject);
                this.SetTextToDisplay(this.EndYear, series.EndYear > 0 ? series.EndYear.ToString() : null, this.EndYear.transform.parent.gameObject);
                this.SetTextToDisplay(this.Rating, series.Rating, this.Rating.transform.parent.gameObject);

                this.SetListItems(this.UrlListView, series.Urls != null ? series.Urls.OrderBy(u => u.DisplayType) : null);
            }
        }
    }
}
