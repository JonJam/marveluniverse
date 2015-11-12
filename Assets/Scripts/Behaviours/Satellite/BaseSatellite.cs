namespace MarvelUniverse.Behaviours
{
    using Camera;
    using Communications.Result;
    using Events;
    using Loading;
    using Model;
    using Screen;
    using Spawner;
    using UnityEngine;
    using Zenject;

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
        public float RestDistance = 10f;

        /// <summary>
        /// The event manager.
        /// </summary>
        private IEventManager eventManager;

        /// <summary>
        /// The screen manager.
        /// </summary>
        private IScreenManager screenManager;

        /// <summary>
        /// The loading manager.
        /// </summary>
        private ILoadingManager loadingManager;

        /// <summary>
        /// The result processor.
        /// </summary>
        private IResultProcessor resultProcessor;

        /// <summary>
        /// The planet system spawner.
        /// </summary>
        private IPlanetSystemSpawner planetSystemSpawner;

        /// <summary>
        /// The rotation axis.
        /// </summary>
        private Vector3 rotationAxis;

        /// <summary>
        /// The child particle system.
        /// </summary>
        private ParticleSystem childParticleSystem;

        /// <summary>
        ///  A value indicating whether orbit movement is enabled.
        /// </summary>
        private bool isOrbitMovementEnabled = true;

        /// <summary>
        /// A value indicating whether the camera is focused on this.
        /// </summary>
        private bool isCameraFocusedOn;

        /// <summary>
        /// Gets the event manager.
        /// </summary>
        protected IEventManager EventManager
        {
            get
            {
                return this.eventManager;
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
        /// Gets the loading manager.
        /// </summary>
        protected ILoadingManager LoadingManager
        {
            get
            {
                return this.loadingManager;
            }
        }

        /// <summary>
        /// Gets the result processor.
        /// </summary>
        protected IResultProcessor ResultProcessor
        {
            get
            {
                return this.resultProcessor;
            }
        }

        /// <summary>
        /// Gets the planet system spawner.
        /// </summary>
        protected IPlanetSystemSpawner PlanetSystemSpawner
        {
            get
            {
                return this.planetSystemSpawner;
            }
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
        /// Gets the camera rest position.
        /// </summary>
        private Vector3 CameraRestPosition
        {
            get
            {
                return this.transform.position + (this.transform.forward.normalized * this.RestDistance);
            }
        }

        /// <summary>
        /// Hooks up the specified summary data list to the satellite.
        /// </summary>
        /// <param name="summaryDataList">The summary data list.</param>
        public void Hookup(DataList<Summary> summaryDataList)
        {
            this.SummaryDataList = summaryDataList;
        }

        /// <summary>
        /// Handles the mouse down event.
        /// </summary>
        protected virtual void OnMouseDown()
        {
            if (!this.isCameraFocusedOn)
            {
                this.isOrbitMovementEnabled = false;

                this.EventManager.GetEvent<CameraFocusOnEvent>().Invoke(this.gameObject, this.CameraRestPosition);
            }
        }

        /// <summary>
        /// Display jump options.
        /// </summary>
        protected abstract void DisplayJumpOptions();

        /// <summary>
        /// Injection initialization.
        /// </summary>
        /// <param name="eventManager">The event manager.</param>
        /// <param name="screenManager">The screen manager.</param>
        /// <param name="loadingManager">The loading manager.</param>
        /// <param name="resultProcessor">The result processor.</param>
        /// <param name="planetSystemSpawner">The planet system spawner.</param>
        [PostInject]
        private void InjectionInitialize(
            IEventManager eventManager,
            IScreenManager screenManager,
            ILoadingManager loadingManager,
            IResultProcessor resultProcessor,
            IPlanetSystemSpawner planetSystemSpawner)
        {
            this.eventManager = eventManager;
            this.screenManager = screenManager;
            this.loadingManager = loadingManager;
            this.resultProcessor = resultProcessor;
            this.planetSystemSpawner = planetSystemSpawner;

            this.EventManager.GetEvent<CameraFocusedOnEvent>().AddListener(this.OnCameraFocusedOnEvent);
        }

        /// <summary>
        /// Handles the awake event.
        /// </summary>
        private void Awake()
        {
            this.childParticleSystem = this.GetComponentInChildren<ParticleSystem>();
            this.childParticleSystem.Stop();
            this.childParticleSystem.Clear();
        }

        /// <summary>
        /// Handles the start event.
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
            this.EventManager.GetEvent<CameraFocusedOnEvent>().RemoveListener(this.OnCameraFocusedOnEvent);
            this.EventManager.GetEvent<CameraLostFocusEvent>().RemoveListener(this.OnCameraLostFocus);
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
                this.EventManager.GetEvent<CameraLostFocusEvent>().AddListener(this.OnCameraLostFocus);
                
                this.childParticleSystem.Play();

                this.DisplayJumpOptions();
            }
        }

        /// <summary>
        /// Handles the camera lost focus event.
        /// </summary>
        /// <param name="focusedObject">The focused object.</param>
        private void OnCameraLostFocus(GameObject focusedObject)
        {
            this.EventManager.GetEvent<CameraLostFocusEvent>().RemoveListener(this.OnCameraLostFocus);

            this.childParticleSystem.Stop();
            this.childParticleSystem.Clear();
            this.ScreenManager.CloseCurrent();

            this.isCameraFocusedOn = false;
            this.isOrbitMovementEnabled = true;
        }
    }
}
