namespace MarvelUniverse.Behaviours
{
    using System.Collections.Generic;
    using Events;
    using Loading;
    using Communications.Result;
    using Model;
    using UnityEngine;
    using Zenject;
    using Camera;

    /// <summary>
    /// Base satellite behaviour.
    /// </summary>
    public abstract class BaseSatellite : MonoBehaviour
    {
        /// <summary>
        /// The planet system transform.
        /// </summary>
        public Transform PlanetSystemTransform;

        /// <summary>
        /// The orbit radius.
        /// </summary>
        public float OrbitRadius = 14.5f;

        /// <summary>
        /// The rotation speed.
        /// </summary>
        public float RotationSpeed = 20;

        /// <summary>
        /// The rest distance.
        /// </summary>
        public float RestDistance = 2f;

        private IEventManager eventManager;

        private ILoadingManager loadingManager;

        private IResultProcessor resultProcessor;

        /// <summary>
        /// The rotation axis.
        /// </summary>
        private Vector3 rotationAxis;

        private ParticleSystem childParticleSystem;

        private bool isOrbitMovementEnabled = true;
        private bool isCameraFocusedOn;

        /// <summary>
        /// Hooks up the specified summary data list to the satellite.
        /// </summary>
        /// <param name="summaryDataList">The summary data list.</param>
        public void Hookup(DataList<Summary> summaryDataList)
        {
            this.SummaryDataList = summaryDataList;
        }

        /// <summary>
        /// Gets the summary data list.
        /// </summary>
        protected DataList<Summary> SummaryDataList
        {
            get;
            private set;
        }

        /// <summary>
        /// The camera rest position.
        /// </summary>
        private Vector3 CameraRestPosition
        {
            get
            {
                return this.transform.position + this.transform.forward.normalized * this.RestDistance;
            }
        }

        /// <summary>
        /// Injection initialization.
        /// </summary>
        /// <param name="eventManager">The event manager.</param>
        /// <param name="loadingManager">The loading manager.</param>
        /// <param name="resultProcessor">The result processor.</param>
        [PostInject]
        private void InjectionInitialize(
            IEventManager eventManager,
            ILoadingManager loadingManager,
            IResultProcessor resultProcessor)
        {
            this.eventManager = eventManager;
            this.loadingManager = loadingManager;
            this.resultProcessor = resultProcessor;

            this.eventManager.GetEvent<CameraFocusedOnEvent>().AddListener(this.OnCameraFocusedOnEvent);
        }

        private void Awake()
        {
            this.childParticleSystem = this.GetComponentInChildren<ParticleSystem>();
            this.childParticleSystem.Stop();
            this.childParticleSystem.Clear();
        }

        /// <summary>
        /// Handles the awake event.
        /// </summary>
        private void Start()
        {
            this.transform.position = this.PlanetSystemTransform.position + (Random.onUnitSphere * this.OrbitRadius);

            this.rotationAxis = Vector3.Cross(this.PlanetSystemTransform.position, this.transform.position);
        }

        /// <summary>
        /// Handles the update event.
        /// </summary>
        private void Update()
        {
            if (this.isOrbitMovementEnabled)
            {
                this.transform.LookAt(this.PlanetSystemTransform.position);
                this.transform.RotateAround(this.PlanetSystemTransform.position, this.rotationAxis, this.RotationSpeed * Time.deltaTime);
            }
        }


        /// <summary>
        /// Handles the destroy event.
        /// </summary>
        private void OnDestroy()
        {
            this.eventManager.GetEvent<CameraFocusedOnEvent>().RemoveListener(this.OnCameraFocusedOnEvent);
            this.eventManager.GetEvent<CameraLostFocusEvent>().RemoveListener(this.OnCameraLostFocus);
        }

        /// <summary>
        /// Handles the mouse down event.
        /// </summary>
        private void OnMouseDown()
        {
            if (!this.isCameraFocusedOn)
            {
                this.isOrbitMovementEnabled = false;
                this.childParticleSystem.Play();

                this.eventManager.GetEvent<CameraFocusOnEvent>().Invoke(this.gameObject, this.CameraRestPosition);
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
        /// Handles the camera lost focus event.
        /// </summary>
        /// <param name="focusedObject">The focused object.</param>
        private void OnCameraLostFocus(GameObject focusedObject)
        {
            this.eventManager.GetEvent<CameraLostFocusEvent>().RemoveListener(this.OnCameraLostFocus);

            this.childParticleSystem.Stop();
            this.childParticleSystem.Clear();

            this.isCameraFocusedOn = false;
            this.isOrbitMovementEnabled = true;
        }
    }
}
