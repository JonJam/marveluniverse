namespace MarvelUniverse.UI.Screens
{
    using System.Collections;
    using Behaviours.Camera;
    using Communications.Interfaces;
    using Communications.Result;
    using DetailsPanel;
    using Events;
    using Model.Character;
    using Model.Comic;
    using Model.Creator;
    using Model.Image;
    using Model.Series;
    using Screen;
    using UnityEngine;
    using UnityEngine.UI;
    using Zenject;

    /// <summary>
    /// The information panel.
    /// </summary>
    public class InfoPanel : MonoBehaviour, IScreen
    {
        /// <summary>
        /// The image.
        /// </summary>
        public RawImage Image;

        /// <summary>
        /// The default image color.
        /// </summary>
        public Color DefaultImageColor;

        /// <summary>
        /// The character details panel.
        /// </summary>
        public CharacterDetailsPanel CharacterDetailsPanel;

        /// <summary>
        /// The comic details panel.
        /// </summary>
        public ComicDetailsPanel ComicDetailsPanel;

        /// <summary>
        /// The event details panel.
        /// </summary>
        public EventDetailsPanel EventDetailsPanel;

        /// <summary>
        /// The creator details panel.
        /// </summary>
        public CreatorDetailsPanel CreatorDetailsPanel;
       
        /// <summary>
        /// The series details panel.
        /// </summary>
        public SeriesDetailsPanel SeriesDetailsPanel;

        /// <summary>
        /// The screen manager.
        /// </summary>
        private IScreenManager screenManager;

        /// <summary>
        /// The image service.
        /// </summary>
        private IImageService imageService;

        /// <summary>
        /// The image download coroutine.
        /// </summary>
        private IEnumerator imageDownloadCoroutine;

        /// <summary>
        /// The previous open parameter.
        /// </summary>
        private object previousOpenParameter;

        /// <summary>
        /// Gets the game object.
        /// </summary>
        public GameObject GameObject
        {
            get
            {
                return this.gameObject;
            }
        }

        /// <summary>
        /// Called upon screen open.
        /// </summary>
        /// <param name="openParameter">The open parameter.</param>
        public void OnOpen(object openParameter)
        {
            if (this.previousOpenParameter != openParameter)
            {
                if (openParameter is Character)
                {
                    this.DisplayInformation((Character)openParameter);
                }
                else if (openParameter is Comic)
                {
                    this.DisplayInformation((Comic)openParameter);
                }
                else if (openParameter is Model.Event.Event)
                {
                    this.DisplayInformation((Model.Event.Event)openParameter);
                }
                else if (openParameter is Creator)
                {
                    this.DisplayInformation((Creator)openParameter);
                }
                else if (openParameter is Series)
                {
                    this.DisplayInformation((Series)openParameter);
                }

                this.previousOpenParameter = openParameter;
            }
        }

        /// <summary>
        /// Called upon the screen being closed.
        /// </summary>
        public void OnClosing()
        {
            if (this.imageDownloadCoroutine != null)
            {
                this.StopCoroutine(this.imageDownloadCoroutine);
                this.imageDownloadCoroutine = null;
            }

            this.Reset();
        }

        /// <summary>
        /// Close click event handler.
        /// </summary>
        public void Close()
        {
            this.screenManager.OpenExplorerPanel();
        }
        
        /// <summary>
        /// Injection initialization.
        /// </summary>
        /// <param name="screenManager">The screen manager.</param>
        /// <param name="imageService">The image service.</param>
        [PostInject]
        private void InjectionInitialize(
            IScreenManager screenManager,
            IImageService imageService)
        {
            this.screenManager = screenManager;
            this.imageService = imageService;
        }

        /// <summary>
        /// Display information for the specified character.
        /// </summary>
        /// <param name="character">The character.</param>
        private void DisplayInformation(Character character)
        {
            this.Reset();

            this.CharacterDetailsPanel.gameObject.SetActive(true);

            this.SetImage(character.Thumbnail);

            this.CharacterDetailsPanel.HookUp(character);
        }

        /// <summary>
        /// Display information for the specified comic.
        /// </summary>
        /// <param name="comic">The comic.</param>
        private void DisplayInformation(Comic comic)
        {
            this.Reset();

            this.ComicDetailsPanel.gameObject.SetActive(true);

            this.SetImage(comic.Thumbnail);

            this.ComicDetailsPanel.HookUp(comic);
        }

        /// <summary>
        /// Display information for the specified event.
        /// </summary>
        /// <param name="comicEvent">The comic event.</param>
        private void DisplayInformation(Model.Event.Event comicEvent)
        {
            this.Reset();

            this.EventDetailsPanel.gameObject.SetActive(true);

            this.SetImage(comicEvent.Thumbnail);

            this.EventDetailsPanel.HookUp(comicEvent);
        }

        /// <summary>
        /// Display information for the specified event.
        /// </summary>
        /// <param name="creator">The creator.</param>
        private void DisplayInformation(Creator creator)
        {
            this.Reset();

            this.CreatorDetailsPanel.gameObject.SetActive(true);

            this.SetImage(creator.Thumbnail);

            this.CreatorDetailsPanel.HookUp(creator);
        }

        /// <summary>
        /// Display information for the specified series.
        /// </summary>
        /// <param name="series">The series.</param>
        private void DisplayInformation(Series series)
        {
            this.Reset();

            this.SeriesDetailsPanel.gameObject.SetActive(true);

            this.SetImage(series.Thumbnail);

            this.SeriesDetailsPanel.HookUp(series);
        }

        /// <summary>
        /// Resets the panel.
        /// </summary>
        private void Reset()
        {
            this.previousOpenParameter = null;

            this.Image.color = this.DefaultImageColor;
            this.Image.texture = null;

            this.CharacterDetailsPanel.gameObject.SetActive(false);
            this.ComicDetailsPanel.gameObject.SetActive(false);
            this.CreatorDetailsPanel.gameObject.SetActive(false);
            this.EventDetailsPanel.gameObject.SetActive(false);
            this.SeriesDetailsPanel.gameObject.SetActive(false);
        }

        /// <summary>
        /// Set image.
        /// </summary>
        /// <param name="image">The image.</param>
        private void SetImage(Model.Image.Image image)
        {
            if (image != null &&
                image.HasData)
            {
                this.imageDownloadCoroutine = this.imageService.DownloadImage(
                    image.Path,
                    image.Extension,
                    ImageSize.PortaitUncanny,
                    this.DownloadImageCompleted);

                this.StartCoroutine(this.imageDownloadCoroutine);
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
                this.Image.color = Color.white;
                this.Image.texture = result.Data;
            }
        }
    }
}
