namespace MarvelUniverse.UI.Controls
{
    using Loading;
    using Events;
    using UnityEngine;
    using Zenject;

    /// <summary>
    /// The loading indicator.
    /// </summary>
    public class LoadingIndicator : MonoBehaviour
    {
        /// <summary>
        /// The is loading animator parameter name.
        /// </summary>
        private const string IsLoadingAnimatorParameterName = "IsLoading";
        
        /// <summary>
        /// The event manager.
        /// </summary>
        private IEventManager eventManager;

        /// <summary>
        /// The animator.
        /// </summary>
        private Animator animator;

        /// <summary>
        /// The is loading animator parameter identifier.
        /// </summary>
        private int isLoadingAnimatorParameterId;

        /// <summary>
        /// Injection initialization.
        /// </summary>
        /// <param name="eventManager">The event mananger</param>
        [PostInject]
        private void InjectionInitialize(
            IEventManager eventManager)
        {
            this.eventManager = eventManager;

            this.eventManager.GetEvent<LoadingEvent>().AddListener(this.OnLoading);
        }

        /// <summary>
        /// Handles the awake event.
        /// </summary>
        private void Awake()
        {
            this.animator = this.GetComponent<Animator>();
            this.isLoadingAnimatorParameterId = Animator.StringToHash(LoadingIndicator.IsLoadingAnimatorParameterName);            
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

            this.animator.SetBool(this.isLoadingAnimatorParameterId, isLoading);
        }
    }
}
