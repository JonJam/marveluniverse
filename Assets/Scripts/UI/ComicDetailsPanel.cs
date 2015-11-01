namespace MarvelUniverse.UI
{
    using Controls;
    using Model.Comic;
    using UnityEngine;
    using UnityEngine.UI;
    using System.Linq;

    public class ComicDetailsPanel : MonoBehaviour
    {
        public Text Title;

        public Text Description;

        public ListView ComicPriceListView;

        public ListView UrlListView;

        public void HookUp(Comic comic)
        {
            if (comic != null)
            {
                this.Title.text = comic.Title;
                this.Description.text = comic.CleanDescription;

                if (comic.Prices != null &&
                   comic.Prices.Count() > 0)
                {
                    this.ComicPriceListView.gameObject.SetActive(true);

                    this.ComicPriceListView.DisplayItems(comic.Prices.OrderBy(p => p.DisplayType));
                }
                else
                {
                    this.ComicPriceListView.gameObject.SetActive(false);
                }

                if (comic.Urls != null &&
                    comic.Urls.Count() > 0)
                {
                    this.UrlListView.gameObject.SetActive(true);

                    this.UrlListView.DisplayItems(comic.Urls.OrderBy(u => u.DisplayText));
                }
                else
                {
                    this.UrlListView.gameObject.SetActive(false);
                }
            }
        }
    }
}
