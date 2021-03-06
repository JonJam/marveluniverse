﻿namespace MarvelUniverse.GameObjects.Planet
{
    using System.Linq;
    using Camera;
    using Events;
    using Jumpgate;
    using Model;
    using Model.Image;
    using Screen;
    using Spawner;
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
        /// Calculates the focus position i.e. the position to move the camera to when focusing on this.
        /// </summary>
        /// <param name="cameraTransform">The camera transform.</param>
        /// <returns>The focus position.</returns>
        public Vector3 FocusPosition(Transform cameraTransform)
        {
            Vector3 fromObjectToCamera = cameraTransform.position - this.transform.position;
            Vector3 positionToMoveTo = this.transform.position + (fromObjectToCamera.normalized * this.RestDistance);

            return positionToMoveTo;
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
        protected void SetSummaries(BaseJumpgate satellite, DataList<Summary> summariesDataList)
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
        [PostInject]
        private void InjectionInitialize(
            IEventManager eventManager,
            IScreenManager screenManager)
        {
            this.eventManager = eventManager;
            this.screenManager = screenManager;

            this.eventManager.GetEvent<CameraFocusedOnEvent>().AddListener(this.OnCameraFocusedOnEvent);
            this.eventManager.GetEvent<CameraLostFocusEvent>().AddListener(this.OnCameraLostFocus);
            this.eventManager.GetEvent<DestroyUniverseEvent>().AddListener(this.OnDestroyUniverseEvent);
        }

        /// <summary>
        /// Handles the destroy event.
        /// </summary>
        private void OnDestroy()
        {
            this.eventManager.GetEvent<CameraFocusedOnEvent>().RemoveListener(this.OnCameraFocusedOnEvent);
            this.eventManager.GetEvent<CameraLostFocusEvent>().RemoveListener(this.OnCameraLostFocus);
            this.eventManager.GetEvent<DestroyUniverseEvent>().RemoveListener(this.OnDestroyUniverseEvent);
        }

        /// <summary>
        /// Handles the mouse down event.
        /// </summary>
        private void OnMouseDown()
        {
            if (!this.isCameraFocusedOn)
            {
                this.eventManager.GetEvent<CameraFocusOnEvent>().Invoke(this.gameObject, this.FocusPosition);
            }
            else
            {
                this.DisplayInformation();
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
                this.DisplayInformation();
            }
        }

        /// <summary>
        /// Handles the camera lost focus event.
        /// </summary>
        /// <param name="focusedObject">The focused object.</param>
        private void OnCameraLostFocus(GameObject focusedObject)
        {
            if (this.gameObject == focusedObject)
            {
                this.isCameraFocusedOn = false;

                this.screenManager.OpenExplorerPanel();
            }
        }

        /// <summary>
        /// Handles the on destroy planet system event.
        /// </summary>
        private void OnDestroyUniverseEvent()
        {
            this.eventManager.GetEvent<DestroyUniverseEvent>().RemoveListener(this.OnDestroyUniverseEvent);

            GameObject.Destroy(this.transform.parent.gameObject);
        }
    }
}