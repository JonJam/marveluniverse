namespace MarvelUniverse.UI.Screens
{
    using Behaviours.Camera;
    using Events;
    using Screen;
    using Spawner;
    using UnityEngine;
    using Zenject;

    /// <summary>
    /// The explorer panel.
    /// </summary>
    public class ExplorerPanel : MonoBehaviour, IScreen
    {
        /// <summary>
        /// The screen manager.
        /// </summary>
        private IScreenManager screenManager;

        /// <summary>
        /// The event manager.
        /// </summary>
        private IEventManager eventManager;

        /// <summary>
        /// Gets the game object.
        /// </summary>
        public GameObject GameObject
        {
            get
            {
                return this.gameObject;
            }
        }

        /// <summary>
        /// Called upon screen open.
        /// </summary>
        /// <param name="openParameter">The open parameter.</param> 
        public void OnOpen(object openParameter)
        {
        }

        /// <summary>
        /// Called upon the screen being closed.
        /// </summary>
        public void OnClosing()
        {
        }

        /// <summary>
        /// Handles the back to search button click event.
        /// </summary>
        public void OnBackToSearchClick()
        {
            this.eventManager.GetEvent<DestroyUniverseEvent>().Invoke();

            this.screenManager.OpenSearchPanel();
            
            this.eventManager.GetEvent<CameraResetEvent>().Invoke();
        }

        /// <summary>
        /// Injection initialization.
        /// </summary>
        /// <param name="screenManager">The screen manager.</param>
        /// <param name="eventManager">The event manager.</param>
        [PostInject]
        private void InjectionInitialize(
            IScreenManager screenManager,
            IEventManager eventManager)
        {
            this.screenManager = screenManager;
            this.eventManager = eventManager;
        }
    }
}
