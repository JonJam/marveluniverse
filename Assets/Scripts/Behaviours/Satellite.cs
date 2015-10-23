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
        public Transform PlantTransform;

        /// <summary>
        /// The orbit radius.
        /// </summary>
        public int OrbitRadius = 5;

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
        private void Awake()
        {
            this.transform.position = this.PlantTransform.position + (Random.onUnitSphere * this.OrbitRadius);

            this.rotationAxis = Vector3.Cross(this.PlantTransform.position, this.transform.position);
        }

        /// <summary>
        /// Handles the update event.
        /// </summary>
        private void Update()
        {
            this.transform.RotateAround(this.PlantTransform.position, this.rotationAxis, this.RotationSpeed * Time.deltaTime);
        }
    }
}
