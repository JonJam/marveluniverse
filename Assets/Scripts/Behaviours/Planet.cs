namespace MarvelUniverse.Behaviours
{
    using Camera;
    using Events;
    using Communications.Interfaces;
    using UnityEngine;
    using Zenject;
    using Communications.Result;
    using Model.Image;

// TODO make abstract
    public class Planet : MonoBehaviour
    {
        /// <summary>
        /// The event manager.
        /// </summary>
        private IEventManager eventManager;

        /// <summary>
        /// The image service.
        /// </summary>
        private IImageService imageService;

        /// <summary>
        /// The mesh renderer.
        /// </summary>
        private MeshRenderer meshRenderer;

        /// <summary>
        /// The main camera transform.
        /// </summary>
        private Transform mainCameraTransform;
        
        /// <summary>
        /// A value indicating whether this attempted to load image.
        /// </summary>
        private bool attemptedToLoadImage;

        /// <summary>
        /// Injection initialization.
        /// </summary>
        /// <param name="eventManager">The event manager.</param>
        [PostInject]
        private void InjectionInitialize(
            IEventManager eventManager,
            IImageService imageService,
            Transform mainCameraTransform)
        {
            this.eventManager = eventManager;
            this.imageService = imageService;

            this.mainCameraTransform = mainCameraTransform;
        }
        
        // TODO Make abstract
        protected void SetImage(string imagePath, string imageExtension)
        {
            if (!this.attemptedToLoadImage)
            {
                this.attemptedToLoadImage = true;

                this.StartCoroutine(this.imageService.DownloadImage(
                    imagePath,
                    imageExtension,
                    ImageSize.StandardXLarge, this.DownloadImageCompleted));
            }
        }
        
        /// <summary>
        /// Handles the awake event.
        /// </summary>
        private void Awake()
        {
            this.meshRenderer = this.GetComponent<MeshRenderer>();
        }

        /// <summary>
        /// Handles the mouse down event.
        /// </summary>
        private void OnMouseDown()
        {
            this.eventManager.GetEvent<CameraFocusEvent>().Invoke(this.transform.position);
        }

        /// <summary>
        /// Handles the update event.
        /// </summary>
        private void Update()
        {
            this.transform.LookAt(this.transform.position + (this.mainCameraTransform.rotation * Vector3.forward), mainCameraTransform.rotation * Vector3.up);
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