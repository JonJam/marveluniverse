namespace MarvelUniverse
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
        /// The list of stone mesh renderers.
        /// </summary>
        public MeshRenderer[] stones;

        /// <summary>
        /// Handles the awake event.
        /// </summary>
        private void Awake()
        {
            this.animator = this.GetComponent<Animator>();
            this.isLoadingAnimatorParameterId = Animator.StringToHash(LoadingIndicator.IsLoadingAnimatorParameterName);
        }

        /// <summary>
        /// Handles the loading event.
        /// </summary>
        /// <param name="isLoading">A value indicating whether is loading.</param>
        private void HandleLoading(bool isLoading)
        {
            foreach (MeshRenderer meshRenderer in this.stones)
            {
                meshRenderer.enabled = isLoading;
            }

            this.animator.SetBool(this.isLoadingAnimatorParameterId, isLoading);
        }
    }
}
