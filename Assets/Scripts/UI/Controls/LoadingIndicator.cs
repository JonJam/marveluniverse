namespace MarvelUniverse.UI.Controls
{
    using Loading;
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
        /// The animator.
        /// </summary>
        private Animator animator;

        /// <summary>
        /// The is loading animator parameter identifier.
        /// </summary>
        private int isLoadingAnimatorParameterId;

        /// <summary>
        /// The loading manager.
        /// </summary>
        private ILoadingManager loadingManager;

        /// <summary>
        /// Injection initialization.
        /// </summary>
        /// <param name="loadingManager">The loading mananger</param>
        [PostInject]
        private void InjectionInitialize(
            ILoadingManager loadingManager)
        {
            this.loadingManager = loadingManager;

            this.loadingManager.Loading.AddListener(this.HandleLoading);
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
            this.loadingManager.Loading.RemoveListener(this.HandleLoading);
        }

        /// <summary>
        /// Handles the loading event.
        /// </summary>
        /// <param name="isLoading">A value indicating whether is loading.</param>
        private void HandleLoading(bool isLoading)
        {
            this.gameObject.SetActive(isLoading);

            this.animator.SetBool(this.isLoadingAnimatorParameterId, isLoading);
        }
    }
}
