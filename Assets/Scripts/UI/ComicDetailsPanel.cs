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

        public Text DiamondCode;

        public Text DigitalId;
        
        public Text Ean;

        public Text Format;

        public Text Isbn;

        public Text Issn;

        public Text IssueNumber;

        public Text PageCount;

        public Text Upc;

        public Text VariantDescription;

        public ListView ComicDateListView;

        public ListView ComicPriceListView;

        public ListView UrlListView;

        public void HookUp(Comic comic)
        {
            if (comic != null)
            {
                this.Title.text = comic.Title;
                this.Description.text = comic.CleanDescription;
                this.DiamondCode.text = comic.DiamondCode;
                this.DigitalId.text = comic.DigitalId.ToString();
                this.Ean.text = comic.Ean;
                this.Format.text = comic.Format;
                this.Isbn.text = comic.Isbn;
                this.Issn.text = comic.Issn;
                this.IssueNumber.text = comic.IssueNumber.ToString();
                this.PageCount.text = comic.PageCount.ToString();
                this.Upc.text = comic.Upc;
                this.VariantDescription.text = comic.VariantDescription;

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

                if (comic.Dates != null &&
                    comic.Dates.Count() > 0)
                {
                    this.ComicDateListView.gameObject.SetActive(true);

                    this.ComicDateListView.DisplayItems(comic.Dates.OrderBy(p => p.DisplayType));
                }
                else
                {
                    this.ComicDateListView.gameObject.SetActive(false);
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
