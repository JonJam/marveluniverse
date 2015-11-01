namespace MarvelUniverse.UI
{
    using Communications.Interfaces;
    using Model.Image;
    using Model.Character;
    using UnityEngine;
    using UnityEngine.UI;
    using Zenject;
    using Communications.Result;
    using Model.Comic;
    using Model.Creator;

    public class InfoPanel : MonoBehaviour
    {
        /// <summary>
        /// The image.
        /// </summary>
        public RawImage Image;

        public Color DefaultImageColor;

        public CharacterDetailsPanel CharacterDetailsPanel;

        public ComicDetailsPanel ComicDetailsPanel;

        public EventDetailsPanel EventDetailsPanel;

        public CreatorDetailsPanel CreatorDetailsPanel;

        /// <summary>
        /// The image service.
        /// </summary>
        private IImageService imageService;

        private Coroutine imageDownloadCoroutine;
        
        public void DisplayInformation(Character character)
        {
            this.CharacterDetailsPanel.gameObject.SetActive(true);

            this.SetImage(character.Thumbnail.Path, character.Thumbnail.Extension);

            this.CharacterDetailsPanel.HookUp(character);
        }

        public void DisplayInformation(Comic comic)
        {
            this.ComicDetailsPanel.gameObject.SetActive(true);

            this.SetImage(comic.Thumbnail.Path, comic.Thumbnail.Extension);

            this.ComicDetailsPanel.HookUp(comic);
        }

        public void DisplayInformation(Model.Event.Event comicEvent)
        {
            this.EventDetailsPanel.gameObject.SetActive(true);

            this.SetImage(comicEvent.Thumbnail.Path, comicEvent.Thumbnail.Extension);

            this.EventDetailsPanel.HookUp(comicEvent);
        }

        public void DisplayInformation(Creator creator)
        {
            this.CreatorDetailsPanel.gameObject.SetActive(true);

            this.SetImage(creator.Thumbnail.Path, creator.Thumbnail.Extension);

            this.CreatorDetailsPanel.HookUp(creator);
        }

        public void Close()
        {
            if (this.imageDownloadCoroutine != null)
            {
                this.StopCoroutine(this.imageDownloadCoroutine);
                this.imageDownloadCoroutine = null;
            }

            this.Reset();
        }
        
        /// <summary>
        /// Injection initialization.
        /// </summary>
        /// <param name="eventManager">The event manager.</param>
        [PostInject]
        private void InjectionInitialize(
            IImageService imageService)
        {
            this.imageService = imageService;
        }

        
        private void Reset()
        {
            this.Image.color = this.DefaultImageColor;
            this.Image.texture = null;

            this.CharacterDetailsPanel.gameObject.SetActive(false);
        }       
        
        /// <summary>
        /// Set image.
        /// </summary>
        /// <param name="imagePath">The image path.</param>
        /// <param name="imageExtension">The image extension.</param>
        private void SetImage(string imagePath, string imageExtension)
        {
            this.imageDownloadCoroutine = this.StartCoroutine(this.imageService.DownloadImage(
                    imagePath,
                    imageExtension,
                    ImageSize.PortaitUncanny,
                    this.DownloadImageCompleted));
        }        

        /// <summary>
        /// Handles the download image completed event.
        /// </summary>
        /// <param name="result">The result.</param>
        private void DownloadImageCompleted(IResult<Texture2D> result)
        {
            if (result.IsSuccess)
            {
                this.Image.color = Color.white;
                this.Image.texture = result.Data;
            }
        }
    }
}
