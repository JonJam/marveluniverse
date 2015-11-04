namespace MarvelUniverse.Behaviours.PlanetSystem
{
    using Camera;
    using Events;
    using Model.Image;
    using Screen;
    using Spawner;
    using UI.Screens;
    using UnityEngine;
    using Zenject;

    /// <summary>
    /// The base planet system
    /// </summary>
    public abstract class BasePlanetSystem : MonoBehaviour
    {
        /// <summary>
        /// The planet.
        /// </summary>
        public GameObject Planet;

        /// <summary>
        /// The planet name.
        /// </summary>
        public PlanetName PlanetName;

        /// <summary>
        /// The planet image.
        /// </summary>
        public PlanetImage PlanetImage;

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
        /// A value indicating whether the camera is focused on this instance.
        /// </summary>
        private bool isCameraFocusedOn;

        /// <summary>
        /// A value indicating whether displaying information about this planet system.
        /// </summary>
        private bool displayingInformation;

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
            this.PlanetName.SetName(name);
        }

        /// <summary>
        /// Sets the image.
        /// </summary>
        /// <param name="image">The image.</param>
        protected void SetImage(Image image)
        {
            this.PlanetImage.SetImage(image);
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
            this.eventManager.GetEvent<DestroyPlanetSystemEvent>().AddListener(this.OnDestroyPlanetSystemEvent);
        }
        
        /// <summary>
        /// Handles the update event.
        /// </summary>
        private void Update()
        {
            Transform planetTransform = this.Planet.transform;

            planetTransform.LookAt(planetTransform.position + (this.mainCameraTransform.rotation * Vector3.forward), mainCameraTransform.rotation * Vector3.up);
        }

        /// <summary>
        /// Handles the destroy event.
        /// </summary>
        private void OnDestroy()
        {
            this.eventManager.GetEvent<CameraFocusedOnEvent>().RemoveListener(this.OnCameraFocusedOnEvent);
            this.eventManager.GetEvent<ClosedInfoPanelEvent>().RemoveListener(this.OnClosedInfoPanel);
            this.eventManager.GetEvent<DestroyPlanetSystemEvent>().RemoveListener(this.OnDestroyPlanetSystemEvent);
        }
        
        /// <summary>
        /// Handles the mouse down event.
        /// </summary>
        private void OnMouseDown()
        {
            if (!this.displayingInformation)
            {
                if (this.isCameraFocusedOn)
                {
                    this.displayingInformation = true;

                    this.eventManager.GetEvent<ClosedInfoPanelEvent>().AddListener(this.OnClosedInfoPanel);
                    this.DisplayInformation();

                    this.eventManager.GetEvent<IsCameraMovementEnabledEvent>().Invoke(false);
                }
                else
                {
                    this.eventManager.GetEvent<CameraFocusOnEvent>().Invoke(this.Planet);
                }
            }
        }

        /// <summary>
        /// Handles the camera focused on event.
        /// </summary>
        /// <param name="objectBeingFocusedOn">The object being focused on.</param>
        private void OnCameraFocusedOnEvent(GameObject objectBeingFocusedOn)
        {
            this.isCameraFocusedOn = objectBeingFocusedOn == this.Planet;
        }
        
        /// <summary>
        /// Handles the closed information panel.
        /// </summary>
        private void OnClosedInfoPanel()
        {
            this.eventManager.GetEvent<ClosedInfoPanelEvent>().RemoveListener(this.OnClosedInfoPanel);

            this.displayingInformation = false;
            this.isCameraFocusedOn = false;
        }

        /// <summary>
        /// Handles the on destory planet system event.
        /// </summary>
        private void OnDestroyPlanetSystemEvent()
        {
            GameObject.Destroy(this.gameObject);
        }
    }
}