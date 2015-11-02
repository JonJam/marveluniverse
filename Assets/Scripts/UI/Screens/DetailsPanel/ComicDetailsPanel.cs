namespace MarvelUniverse.UI.Screens.DetailsPanel
{
    using System.Linq;
    using Controls;
    using Model.Comic;
    using UnityEngine.UI;

    /// <summary>
    /// The comic details panel.
    /// </summary>
    public class ComicDetailsPanel : BaseDetailsPanel
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
        /// The diamond code text.
        /// </summary>
        public Text DiamondCode;

        /// <summary>
        /// The digital identifier text.
        /// </summary>
        public Text DigitalId;

        /// <summary>
        /// The EAN barcode text.
        /// </summary>
        public Text Ean;

        /// <summary>
        /// The format text.
        /// </summary>
        public Text Format;

        /// <summary>
        /// The ISBN barcode text.
        /// </summary>
        public Text Isbn;

        /// <summary>
        /// The ISSN barcode text.
        /// </summary>
        public Text Issn;

        /// <summary>
        /// The issue number text.
        /// </summary>
        public Text IssueNumber;

        /// <summary>
        /// The page count text.
        /// </summary>
        public Text PageCount;

        /// <summary>
        /// The UPC barcode text.
        /// </summary>
        public Text Upc;

        /// <summary>
        /// The variant description text.
        /// </summary>
        public Text VariantDescription;

        /// <summary>
        /// The comic date list view.
        /// </summary>
        public ListView ComicDateListView;

        /// <summary>
        /// The comic price list view.
        /// </summary>
        public ListView ComicPriceListView;

        /// <summary>
        /// The URL list view.
        /// </summary>
        public ListView UrlListView;

        /// <summary>
        /// Hooks up this with the specified comic.
        /// </summary>
        /// <param name="comic">The comic.</param>
        public void HookUp(Comic comic)
        {
            if (comic != null)
            {
                this.SetTextToDisplay(this.Title, comic.Title);
                this.SetTextToDisplay(this.Description, comic.CleanDescription);
                this.SetTextToDisplay(this.DiamondCode, comic.DiamondCode);
                this.SetTextToDisplay(this.DigitalId, comic.DigitalId.ToString());
                this.SetTextToDisplay(this.Ean, comic.Ean);
                this.SetTextToDisplay(this.Format, comic.Format);
                this.SetTextToDisplay(this.Isbn, comic.Isbn);
                this.SetTextToDisplay(this.Issn, comic.Issn);
                this.SetTextToDisplay(this.IssueNumber, comic.IssueNumber.ToString());
                this.SetTextToDisplay(this.PageCount, comic.PageCount.ToString());
                this.SetTextToDisplay(this.Upc, comic.Upc);
                this.SetTextToDisplay(this.VariantDescription, comic.VariantDescription);

                this.SetListItems(this.ComicPriceListView, comic.Prices != null ? comic.Prices.OrderBy(p => p.DisplayType) : null);
                this.SetListItems(this.ComicDateListView, comic.Dates != null ? comic.Dates.OrderBy(d => d.DisplayType) : null);
                this.SetListItems(this.UrlListView, comic.Urls != null ? comic.Urls.OrderBy(u => u.DisplayType) : null);
            }
        }
    }
}
