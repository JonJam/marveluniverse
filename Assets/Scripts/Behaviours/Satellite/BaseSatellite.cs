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
        /// The planet transform.
        /// </summary>
        public Transform PlanetTransform;

        /// <summary>
        /// The orbit radius.
        /// </summary>
        public float OrbitRadius = 14.5f;

        /// <summary>
        /// The rotation speed.
        /// </summary>
        public float RotationSpeed = 20;

        private IEventManager eventManager;

        private ILoadingManager loadingManager;

        private IResultProcessor resultProcessor;

        /// <summary>
        /// The rotation axis.
        /// </summary>
        private Vector3 rotationAxis;

        private ParticleSystem childParticleSystem;

        private bool isOrbitMovementEnabled = true;
        private object comicService;

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
            this.transform.position = this.PlanetTransform.position + (Random.onUnitSphere * this.OrbitRadius);

            this.rotationAxis = Vector3.Cross(this.PlanetTransform.position, this.transform.position);
        }
        
        /// <summary>
        /// Handles the update event.
        /// </summary>
        private void Update()
        {
            if (this.isOrbitMovementEnabled)
            {
                this.transform.LookAt(this.PlanetTransform.position);
                this.transform.Rotate(new Vector3(0, 90, 0));
                this.transform.RotateAround(this.PlanetTransform.position, this.rotationAxis, this.RotationSpeed * Time.deltaTime);
            }
        }

        /// <summary>
        /// Handles the mouse down event.
        /// </summary>
        private void OnMouseDown()
        {
            this.isOrbitMovementEnabled = false;

            this.eventManager.GetEvent<CameraFocusOnEvent>().Invoke(this.gameObject);
        }
    }
}
