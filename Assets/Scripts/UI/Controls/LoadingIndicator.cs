namespace MarvelUniverse.UI.Controls
{
    using UnityEngine;

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
        /// Set animation.
        /// </summary>
        /// <param name="isLoading">A value indicating whether the game is performing an operation.</param>
        public void SetAnimation(bool isLoading)
        {
            this.animator.SetBool(this.isLoadingAnimatorParameterId, isLoading);
        }

        /// <summary>
        /// Handles the awake event.
        /// </summary>
        private void Awake()
        {
            this.animator = this.GetComponent<Animator>();
            this.isLoadingAnimatorParameterId = Animator.StringToHash(LoadingIndicator.IsLoadingAnimatorParameterName);            
        }
    }
}
