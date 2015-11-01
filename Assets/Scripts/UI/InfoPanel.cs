namespace MarvelUniverse.UI
{
    using Communications.Interfaces;
    using Model.Image;
    using Model.Character;
    using UnityEngine;
    using UnityEngine.UI;
    using Zenject;
    using Communications.Result;

    public class InfoPanel : MonoBehaviour
    {
        /// <summary>
        /// The image.
        /// </summary>
        public RawImage Image;

        public CharacterDetailsPanel CharacterDetailsPanel;

        public Color DefaultImageColor;
        
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
