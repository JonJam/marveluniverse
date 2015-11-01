namespace MarvelUniverse.UI
{
    using Controls;
    using Model.Series;
    using UnityEngine;
    using UnityEngine.UI;
    using System.Linq;

    public class SeriesDetailsPanel : MonoBehaviour
    {
        public Text Title;

        public Text Description;

        public Text Rating;

        public Text StartYear;

        public Text EndYear;

        public ListView UrlListView;

        public void HookUp(Series series)
        {
            if (series != null)
            {
                this.Title.text = series.Title;
                this.Description.text = series.CleanDescription;
                this.StartYear.text = series.StartYear.ToString();
                this.EndYear.text = series.EndYear.ToString();
                this.Rating.text = series.Rating;

                if (series.Urls != null &&
                    series.Urls.Count() > 0)
                {
                    this.UrlListView.gameObject.SetActive(true);

                    this.UrlListView.DisplayItems(series.Urls.OrderBy(u => u.DisplayText));
                }
                else
                {
                    this.UrlListView.gameObject.SetActive(false);
                }
            }
        }
    }
}
