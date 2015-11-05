namespace MarvelUniverse.Behaviours
{
    using System.Collections.Generic;
    using Model;
    using UnityEngine;

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

        /// <summary>
        /// The rotation axis.
        /// </summary>
        private Vector3 rotationAxis;

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
            this.transform.RotateAround(this.PlanetTransform.position, this.rotationAxis, this.RotationSpeed * Time.deltaTime);
        }

        /// <summary>
        /// Handles the mouse down event.
        /// </summary>
        private void OnMouseDown()
        {
        }
    }
}
