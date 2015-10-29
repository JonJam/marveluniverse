namespace MarvelUniverse.Behaviours.Planet
{
    using MarvelUniverse.Communications.Interfaces;
    using MarvelUniverse.Communications.Result;
    using MarvelUniverse.Model.Image;
    using UnityEngine;
    using Zenject;

    /// <summary>
    /// The planet image.
    /// </summary>
    public class PlanetImage : MonoBehaviour
    {   
        /// <summary>
        /// The image service.
        /// </summary>
        private IImageService imageService;

        /// <summary>
        /// The mesh renderer.
        /// </summary>
        private MeshRenderer meshRenderer;

        /// <summary>
        /// A value indicating whether this attempted to load image.
        /// </summary>
        private bool attemptedToLoadImage;

        /// <summary>
        /// Set image.
        /// </summary>
        /// <param name="imagePath">The image path.</param>
        /// <param name="imageExtension">The image extension.</param>
        public void SetImage(string imagePath, string imageExtension)
        {
            if (!this.attemptedToLoadImage)
            {
                this.attemptedToLoadImage = true;

                this.StartCoroutine(this.imageService.DownloadImage(
                    imagePath,
                    imageExtension,
                    ImageSize.StandardFantastic, 
                    this.DownloadImageCompleted));
            }
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

        /// <summary>
        /// Handles the awake event.
        /// </summary>
        private void Awake()
        {
            this.meshRenderer = this.GetComponent<MeshRenderer>();
        }
        
        /// <summary>
        /// Handles the download image completed event.
        /// </summary>
        /// <param name="result">The result.</param>
        private void DownloadImageCompleted(IResult<Texture2D> result)
        {
            if (result.IsSuccess)
            {
                this.meshRenderer.material.mainTexture = result.Data;
            }
        }
    }
}
