namespace MarvelUniverse.Behaviours
{
    using Camera;
    using Events;
    using UnityEngine;
    using Zenject;

    /// <summary>
    /// The planet behaviour.
    /// </summary>
    public class Planet : MonoBehaviour
    {
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
        }

        /// <summary>
        /// Handles the mouse down event.
        /// </summary>
        private void OnMouseDown()
        {
            this.eventManager.GetEvent<CameraFocusEvent>().Invoke(this.transform.position);
        }
    }
}
