namespace MarvelUniverse.Behaviours.Planet
{
    using System;
    using Camera;
    using Events;
    using Model.Image;
    using Screen;
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
        /// The screen manager.
        /// </summary>
        private IScreenManager screenManager;
        
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
        /// A value indicating whether the camera is focused on this instance.
        /// </summary>
        private bool isCameraFocusedOn;

        /// <summary>
        /// Gets the screen manager.
        /// </summary>
        protected IScreenManager ScreenManager
        {
            get
            {
                return this.screenManager;
            }
        }
        
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
        /// <param name="image">The image.</param>
        protected void SetImage(Image image)
        {
            this.planetImage.SetImage(image);
        }

        /// <summary>
        /// Display information for this planet system.
        /// </summary>
        protected abstract void DisplayInformation();

        /// <summary>
        /// Injection initialization.
        /// </summary>
        /// <param name="eventManager">The event manager.</param>
        /// <param name="screenManager">The screen manager.</param>
        /// <param name="mainCameraTransform">The main camera transform.</param>
        [PostInject]
        private void InjectionInitialize(
            IEventManager eventManager,
            IScreenManager screenManager,
            Transform mainCameraTransform)
        {
            this.eventManager = eventManager;
            this.screenManager = screenManager;

            this.mainCameraTransform = mainCameraTransform;

            this.eventManager.GetEvent<CameraFocusedOnEvent>().AddListener(this.OnCameraFocusedOnEvent);
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
        /// Handles the update event.
        /// </summary>
        private void Update()
        {
            this.transform.LookAt(this.transform.position + (this.mainCameraTransform.rotation * Vector3.forward), mainCameraTransform.rotation * Vector3.up);
        }

        /// <summary>
        /// Handles the destroy event.
        /// </summary>
        private void OnDestroy()
        {
            this.eventManager.GetEvent<CameraFocusedOnEvent>().RemoveListener(this.OnCameraFocusedOnEvent);
        }
        
        /// <summary>
        /// Handles the mouse down event.
        /// </summary>
        private void OnMouseDown()
        {
            if (this.isCameraFocusedOn)
            {
                this.DisplayInformation();
                this.eventManager.GetEvent<IsCameraMovementEnabledEvent>().Invoke(false);
            }
            else
            {
                this.eventManager.GetEvent<CameraFocusOnEvent>().Invoke(this.gameObject);
            }
        }

        /// <summary>
        /// Handles the camera focused on event.
        /// </summary>
        /// <param name="objectBeingFocusedOn">The object being focused on.</param>
        private void OnCameraFocusedOnEvent(GameObject objectBeingFocusedOn)
        {
            this.isCameraFocusedOn = objectBeingFocusedOn == this.gameObject;
        }
    }
}