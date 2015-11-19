namespace MarvelUniverse.Behaviours
{
    using MarvelUniverse.Behaviours.Camera;
    using MarvelUniverse.Behaviours.Planet;
    using MarvelUniverse.Events;
    using UnityEngine;
    using Zenject;

    /// <summary>
    /// The through jump gate target behaviour.
    /// </summary>
    public class ThroughJumpgateTarget : MonoBehaviour
    {
        /// <summary>
        /// The planet to focus on.
        /// </summary>
        public BasePlanet PlanetToFocusOn;
        
        /// <summary>
        /// The event manager.
        /// </summary>
        private IEventManager eventManager;

        /// <summary>
        /// Injection initialization.
        /// </summary>
        /// <param name="eventManager">The event manager.</param>
        [PostInject]
        private void InjectionInitialize(
            IEventManager eventManager)
        {
            this.eventManager = eventManager;

            this.eventManager.GetEvent<CameraFocusedOnEvent>().AddListener(this.OnCameraFocusedOnEvent);
            this.eventManager.GetEvent<CameraLostFocusEvent>().AddListener(this.OnCameraLostFocus);
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
        /// Handles the camera focused on event.
        /// </summary>
        /// <param name="objectBeingFocusedOn">The object being focused on.</param>
        private void OnCameraFocusedOnEvent(GameObject objectBeingFocusedOn)
        {
            if (this.gameObject == objectBeingFocusedOn)
            {
                this.eventManager.GetEvent<CameraFocusOnEvent>().Invoke(this.PlanetToFocusOn.gameObject, this.PlanetToFocusOn.FocusPosition);

                UnityEngine.Object.Destroy(this.gameObject);
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
                UnityEngine.Object.Destroy(this.gameObject);
            }
        }
    }
}
