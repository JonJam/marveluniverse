namespace MarvelUniverse.Behaviours
{
    using System;
    using System.Collections;
    using System.Linq;
    using Camera;
    using Communications.Result;
    using Events;
    using Loading;
    using Model;
    using Planet;
    using Screen;
    using Spawner;
    using UI.Screens;
    using UnityEngine;
    using ViewModels;
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
        /// The through jump gate target prefab.
        /// </summary>
        public GameObject ThroughJumpgateTargetPrefab;

        /// <summary>
        /// The planet system link prefab.
        /// </summary>
        public GameObject PlanetSystemLinkPrefab;

        /// <summary>
        /// The instantiator.
        /// </summary>
        private IInstantiator instantiator;

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
        /// Hooks up the specified summary data list to the satellite.
        /// </summary>
        /// <param name="summaryDataList">The summary data list.</param>
        public void Hookup(DataList<Summary> summaryDataList)
        {
            this.SummaryDataList = summaryDataList;
        }

        /// <summary>
        /// Calculates the focus position i.e. the position to move the camera to when focusing on this.
        /// </summary>
        /// <param name="cameraTransform">The camera transform.</param>
        /// <returns>The focus position.</returns>
        public Vector3 FocusPosition(Transform cameraTransform)
        {
            return this.transform.position + (this.transform.forward.normalized * this.RestDistance);
        }

        /// <summary>
        /// Gets the data for the selected jump option.
        /// </summary>
        /// <param name="selectedSummary">The selected summary.</param>
        /// <returns>An enumerator.</returns>
        protected abstract IEnumerator GetSelectedJumpOptionData(Summary selectedSummary);

        /// <summary>
        /// Display jump options.
        /// </summary>
        protected virtual void DisplayJumpOptions()
        {
            this.screenManager.OpenJumpGatePanel(this.SummaryDataList.Items.Select(s => new JumpOptionViewModel(
               s.Name,
               () =>
               {
                   this.LoadingManager.IncrementRunningOperationCount();

                   this.StartCoroutine(this.GetSelectedJumpOptionData(s));
               })));
        }

        /// <summary>
        /// Handles the completion of getting the selected jump option data.
        /// </summary>
        /// <typeparam name="T">The type of data obtained.</typeparam>
        /// <param name="result">The result.</param>
        /// <param name="planetSystemSpawn">A function to spawn a planet system</param>
        protected void OnGetSelectedJumpOptionDataCompleted<T>(IResult<T> result, Func<BasePlanet> planetSystemSpawn)
        {
            if (this.resultProcessor.ProcessResult(result))
            {
                this.screenManager.OpenExplorerPanel();

                BasePlanet planet = planetSystemSpawn();

                this.MoveToNewPlantSystem(planet);

                this.SpawnPlanetSystemLink(planet.transform.position);
            }

            this.LoadingManager.DecrementRunningOperationCount();
        }

        /// <summary>
        /// Move to new planet system.
        /// </summary>
        /// <param name="planet">The planet.</param>
        private void MoveToNewPlantSystem(BasePlanet planet)
        {
            Vector3 targetPosition = this.transform.position - this.transform.forward.normalized;

            GameObject throughJumpgateTarget = this.instantiator.InstantiatePrefab(this.ThroughJumpgateTargetPrefab) as GameObject;
            throughJumpgateTarget.transform.position = this.transform.position + (-this.transform.forward.normalized * 2f);
            throughJumpgateTarget.GetComponent<ThroughJumpgateTarget>().PlanetToFocusOn = planet;

            this.eventManager.GetEvent<CameraFocusOnEvent>().Invoke(throughJumpgateTarget, (cameraTransform) => { return targetPosition; });
        }

        /// <summary>
        /// Spawns a planet system link.
        /// </summary>
        /// <param name="targetPlanetPosition">The target planet position.</param>
        private void SpawnPlanetSystemLink(Vector3 targetPlanetPosition)
        {
            GameObject planetSystemLink = GameObject.Instantiate(this.PlanetSystemLinkPrefab);
            planetSystemLink.transform.SetParent(this.PlanetSystemTransform);

            LineRenderer lineRenderer = planetSystemLink.GetComponent<LineRenderer>();

            lineRenderer.SetPosition(0, this.PlanetSystemTransform.transform.position);
            lineRenderer.SetPosition(1, targetPlanetPosition);
        }

        /// <summary>
        /// Handles the mouse down event.
        /// </summary>
        private void OnMouseDown()
        {
            if (!this.isCameraFocusedOn)
            {
                this.isOrbitMovementEnabled = false;

                this.eventManager.GetEvent<CameraLostFocusEvent>().AddListener(this.OnCameraLostFocus);
                this.eventManager.GetEvent<CameraFocusOnEvent>().Invoke(this.gameObject, this.FocusPosition);
            }
        }

        /// <summary>
        /// Injection initialization.
        /// </summary>
        /// <param name="instantiator">The instantiator.</param>
        /// <param name="eventManager">The event manager.</param>
        /// <param name="screenManager">The screen manager.</param>
        /// <param name="loadingManager">The loading manager.</param>
        /// <param name="resultProcessor">The result processor.</param>
        /// <param name="planetSystemSpawner">The planet system spawner.</param>
        [PostInject]
        private void InjectionInitialize(
            IInstantiator instantiator,
            IEventManager eventManager,
            IScreenManager screenManager,
            ILoadingManager loadingManager,
            IResultProcessor resultProcessor,
            IPlanetSystemSpawner planetSystemSpawner)
        {
            this.instantiator = instantiator;
            this.eventManager = eventManager;
            this.screenManager = screenManager;
            this.loadingManager = loadingManager;
            this.resultProcessor = resultProcessor;
            this.planetSystemSpawner = planetSystemSpawner;

            this.eventManager.GetEvent<CameraFocusedOnEvent>().AddListener(this.OnCameraFocusedOnEvent);
            this.eventManager.GetEvent<CameraLostFocusEvent>().AddListener(this.OnCameraLostFocus);
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
            this.transform.position = this.PlanetSystemTransform.position + (UnityEngine.Random.onUnitSphere * this.OrbitRadius);

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
            this.eventManager.GetEvent<ClosedJumpGatePanelEvent>().RemoveListener(this.OnClosedJumpGatePanel);
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
                this.childParticleSystem.Play();

                this.eventManager.GetEvent<ClosedJumpGatePanelEvent>().AddListener(this.OnClosedJumpGatePanel);

                this.DisplayJumpOptions();
            }
        }

        /// <summary>
        /// Handles the camera lost focus event.
        /// </summary>
        /// <param name="focusedObject">The focused object.</param>
        private void OnCameraLostFocus(GameObject focusedObject)
        {
            if (focusedObject == this.gameObject)
            {
                this.Reset();
            }
        }

        /// <summary>
        /// Handles the on closed jump gate panel event.
        /// </summary>
        private void OnClosedJumpGatePanel()
        {
            this.eventManager.GetEvent<ClosedJumpGatePanelEvent>().RemoveListener(this.OnClosedJumpGatePanel);

            this.Reset();
        }

        /// <summary>
        /// Resets this.
        /// </summary>
        private void Reset()
        {
            this.childParticleSystem.Stop();
            this.childParticleSystem.Clear();
            this.screenManager.OpenExplorerPanel();

            this.isCameraFocusedOn = false;
            this.isOrbitMovementEnabled = true;
        }
    }
}
