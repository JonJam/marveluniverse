namespace MarvelUniverse.Behaviours
{
    using UnityEngine;
    using Zenject;

    /// <summary>
    /// Look at camera behaviour.
    /// </summary>
    public class LookAtCamera : MonoBehaviour
    {
        /// <summary>
        /// The main camera transform.
        /// </summary>
        private Transform mainCameraTransform;

        /// <summary>
        /// Injection initialization.
        /// </summary>
        /// <param name="eventManager">The event manager.</param>
        /// <param name="screenManager">The screen manager.</param>
        [PostInject]
        private void InjectionInitialize(
            UnityEngine.Camera mainCamera)
        {
            this.mainCameraTransform = mainCamera.transform;
        }

        /// <summary>
        /// Handles the update event.
        /// </summary>
        private void Update()
        {
            this.transform.LookAt(this.transform.position + (this.mainCameraTransform.rotation * Vector3.forward), this.mainCameraTransform.rotation * Vector3.up);
        }
    }
}
