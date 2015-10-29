namespace MarvelUniverse.Behaviours
{
    using UnityEngine;

    /// <summary>
    /// Satellite behaviour.
    /// </summary>
    public class Satellite : MonoBehaviour
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
    }
}
