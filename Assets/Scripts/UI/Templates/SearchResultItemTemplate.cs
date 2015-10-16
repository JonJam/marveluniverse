namespace MarvelUniverse.UI.Templates
{
    using MarvelUniverse.Communications.Interfaces;
    using MarvelUniverse.Communications.Result;
    using MarvelUniverse.Model.Image;
    using MarvelUniverse.ViewModel;
    using UnityEngine;
    using UnityEngine.UI;
    using Zenject;

    /// <summary>
    /// The search result item template.
    /// </summary>
    public class SearchResultItemTemplate : MonoBehaviour, IItemTemplate<SearchResultViewModel>
    {
        /// <summary>
        /// The image service.
        /// </summary>
        private IImageService imageService;
        
        /// <summary>
        /// The search result.
        /// </summary>
        private SearchResultViewModel searchResult;

        /// <summary>
        /// A value indicating whether this attempted to load image.
        /// </summary>
        private bool attemptedToLoadImage;

        /// <summary>
        /// The name.
        /// </summary>
        public Text Name;

        /// <summary>
        /// The description.
        /// </summary>
        public Text Description;

        /// <summary>
        /// The image.
        /// </summary>
        public RawImage Image;

        /// <summary>
        /// The button.
        /// </summary>
        public Button Button;
        
        /// <summary>
        /// Hook up item to template.
        /// </summary>
        /// <param name="item">The item to display.</param>
        public void Hookup(SearchResultViewModel item)
        {
            this.searchResult = item;

            this.Name.text = item.Name;
            this.Description.text = item.Description;
            this.Button.onClick.AddListener(item.SearchResultClicked);
        }        

        /// <summary>
        /// Injection initialization.
        /// </summary>
        /// <param name="imageService">The image service.</param>
        [PostInject]
        private void InjectionInitialize(
            IImageService imageService)
        {
            this.imageService = imageService;
        }

        /// <summary>
        /// Handles the update event.
        /// </summary>
        private void Update()
        {
            if (this.Image.texture == null &&
                !this.attemptedToLoadImage)
            {
                this.attemptedToLoadImage = true;

                this.StartCoroutine(this.imageService.DownloadImage(searchResult.ImagePath, searchResult.ImageExtension, ImageSize.StandardXLarge, this.DownloadImageCompleted));
            }
        }

        /// <summary>
        /// Handles the download image completed event.
        /// </summary>
        /// <param name="result">The result.</param>
        private void DownloadImageCompleted(IResult<Texture2D> result)
        {
            if (result.IsSuccess)
            {
                this.Image.texture = result.Data;
            }
            else
            {
                // TODO HANDLE Failure
            }
        }
    }
}
