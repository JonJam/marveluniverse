namespace MarvelUniverse.Behaviours.Planet
{
    using System.Linq;
    using Camera;
    using Events;
    using Model;
    using Model.Image;
    using Screen;
    using Spawner;
    using UI.Screens;
    using UnityEngine;
    using Zenject;

    /// <summary>
    /// The base planet
    /// </summary>
    public abstract class BasePlanet : MonoBehaviour
    {
        /// <summary>
        /// The planet name.
        /// </summary>
        public PlanetName PlanetName;

        /// <summary>
        /// The planet image.
        /// </summary>
        public PlanetImage PlanetImage;

        /// <summary>
        /// The rest distance.
        /// </summary>
        public float RestDistance = -35;

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
        /// Gets the camera rest position.
        /// </summary>
        public Vector3 CameraRestPosition
        {
            get
            {
                return this.transform.position + (this.transform.forward.normalized * this.RestDistance);
            }
        }

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
        /// Set summaries.
        /// </summary>
        /// <param name="satellite">The satellite.</param>
        /// <param name="summariesDataList">The summaries data list.</param>
        protected void SetSummaries(BaseSatellite satellite, DataList<Summary> summariesDataList)
        {
            if (summariesDataList != null &&
                summariesDataList.Available > 0 &&
                summariesDataList.Returned > 0 &&
                summariesDataList.Items != null &&
                summariesDataList.Items.Count() > 0)
            {
                satellite.gameObject.SetActive(true);
                satellite.Hookup(summariesDataList);
            }
            else
            {
                satellite.gameObject.SetActive(false);
            }
        }

        /// <summary>
        /// Display information for this planet.
        /// </summary>
        protected abstract void DisplayInformation();

        /// <summary>
        /// Injection initialization.
        /// </summary>
        /// <param name="eventManager">The event manager.</param>
        /// <param name="screenManager">The screen manager.</param>
        /// <param name="mainCamera">The main camera.</param>
        [PostInject]
        private void InjectionInitialize(
            IEventManager eventManager,
            IScreenManager screenManager,
            Camera mainCamera)
        {
            this.eventManager = eventManager;
            this.screenManager = screenManager;

            this.mainCameraTransform = mainCamera.transform;

            this.eventManager.GetEvent<CameraFocusedOnEvent>().AddListener(this.OnCameraFocusedOnEvent);
            this.eventManager.GetEvent<DestroyPlanetSystemEvent>().AddListener(this.OnDestroyPlanetSystemEvent);
        }
        
        /// <summary>
        /// Handles the update event.
        /// </summary>
        private void Update()
        {
            this.transform.LookAt(this.transform.position + (this.mainCameraTransform.rotation * Vector3.forward), this.mainCameraTransform.rotation * Vector3.up);
        }

        /// <summary>
        /// Handles the destroy event.
        /// </summary>
        private void OnDestroy()
        {
            this.eventManager.GetEvent<CameraFocusedOnEvent>().RemoveListener(this.OnCameraFocusedOnEvent);
            this.eventManager.GetEvent<ClosedInfoPanelEvent>().RemoveListener(this.OnClosedInfoPanel);
            this.eventManager.GetEvent<CameraLostFocusEvent>().RemoveListener(this.OnCameraLostFocus);
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
                    this.eventManager.GetEvent<CameraFocusOnEvent>().Invoke(this.gameObject, this.CameraRestPosition);
                }
            }
        }

        /// <summary>
        /// Handles the camera focused on event.
        /// </summary>
        /// <param name="objectBeingFocusedOn">The object being focused on.</param>
        private void OnCameraFocusedOnEvent(GameObject objectBeingFocusedOn)
        {
            this.isCameraFocusedOn = objectBeingFocusedOn == this.gameObject;

            if (this.isCameraFocusedOn)
            {
                this.eventManager.GetEvent<CameraLostFocusEvent>().AddListener(this.OnCameraLostFocus);
            }
        }
        
        /// <summary>
        /// Handles the closed information panel.
        /// </summary>
        private void OnClosedInfoPanel()
        {
            this.eventManager.GetEvent<ClosedInfoPanelEvent>().RemoveListener(this.OnClosedInfoPanel);

            this.displayingInformation = false;
        }

        /// <summary>
        /// Handles the camera lost focus event.
        /// </summary>
        /// <param name="focusedObject">The focused object.</param>
        private void OnCameraLostFocus(GameObject focusedObject)
        {
            this.eventManager.GetEvent<CameraLostFocusEvent>().RemoveListener(this.OnCameraLostFocus);
            
            this.isCameraFocusedOn = false;
        }

        /// <summary>
        /// Handles the on destroy planet system event.
        /// </summary>
        private void OnDestroyPlanetSystemEvent()
        {
            this.eventManager.GetEvent<DestroyPlanetSystemEvent>().RemoveListener(this.OnDestroyPlanetSystemEvent);

            GameObject.Destroy(this.transform.parent.gameObject);
        }
    }
}