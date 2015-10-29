namespace MarvelUniverse.Behaviours.Planet
{
    using Camera;
    using Events;
    using UnityEngine;
    using Zenject;
    
    /// <summary>
    /// The base planet.
    /// </summary>
    public abstract class BasePlanet : MonoBehaviour
    {
        /// <summary>
        /// The event manager.
        /// </summary>
        private IEventManager eventManager;
        
        /// <summary>
        /// The main camera transform.
        /// </summary>
        private Transform mainCameraTransform;

        /// <summary>
        /// The planet name.
        /// </summary>
        private PlanetName planetName;

        /// <summary>
        /// The planet image.
        /// </summary>
        private PlanetImage planetImage;
        
        /// <summary>
        /// Sets the name.
        /// </summary>
        /// <param name="name">The name.</param>
        protected void SetName(string name)
        {
            this.planetName.SetName(name);
        }

        /// <summary>
        /// Sets the image.
        /// </summary>
        /// <param name="imagePath">The image path.</param>
        /// <param name="imageExtension">The image extension.</param>
        protected void SetImage(string imagePath, string imageExtension)
        {
            this.planetImage.SetImage(imagePath, imageExtension);
        }

        /// <summary>
        /// Injection initialization.
        /// </summary>
        /// <param name="eventManager">The event manager.</param>
        /// <param name="mainCameraTransform">The main camera transform.</param>
        [PostInject]
        private void InjectionInitialize(
            IEventManager eventManager,
            Transform mainCameraTransform)
        {
            this.eventManager = eventManager;

            this.mainCameraTransform = mainCameraTransform;
        }

        /// <summary>
        /// Handles the awake event.
        /// </summary>
        private void Awake()
        {
            this.planetName = this.GetComponentInChildren<PlanetName>();
            this.planetImage = this.GetComponentInChildren<PlanetImage>();
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
    }
}