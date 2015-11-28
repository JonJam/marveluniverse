namespace MarvelUniverse.GameObjects.Planet
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
        /// Set image.
        /// </summary>
        /// <param name="image">The image.</param>
        public void SetImage(Image image)
        {
            if (image != null &&
                image.HasData)
            {
                this.StartCoroutine(this.imageService.DownloadImage(
                    image.Path,
                    image.Extension,
                    ImageSize.StandardFantastic,
                    this.DownloadImageCompleted));
            }
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
