namespace MarvelUniverse.UI.Screens
{
    using Controls;
    using Events;
    using Loading;
    using UnityEngine;
    using Zenject;

    /// <summary>
    /// The loading panel.
    /// </summary>
    public class LoadingPanel : MonoBehaviour
    {
        /// <summary>
        /// The loading indicator control.
        /// </summary>
        public LoadingIndicator loadingIndicator;
        
        /// <summary>
        /// The event manager.
        /// </summary>
        private IEventManager eventManager;
                       
        /// <summary>
        /// Injection initialization.
        /// </summary>
        /// <param name="eventManager">The event manager</param>
        [PostInject]
        private void InjectionInitialize(
            IEventManager eventManager)
        {
            this.eventManager = eventManager;

            this.eventManager.GetEvent<LoadingEvent>().AddListener(this.OnLoading);
        }

        /// <summary>
        /// Handles the on destroy event.
        /// </summary>
        private void OnDestroy()
        {
            this.eventManager.GetEvent<LoadingEvent>().RemoveListener(this.OnLoading);
        }

        /// <summary>
        /// Handles the loading event.
        /// </summary>
        /// <param name="isLoading">A value indicating whether is loading.</param>
        private void OnLoading(bool isLoading)
        {
            this.gameObject.SetActive(isLoading);

            this.loadingIndicator.SetAnimation(isLoading);
        }
    }
}
