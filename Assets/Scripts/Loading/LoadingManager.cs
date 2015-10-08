namespace MarvelUniverse.Loading
{
    using System.Threading;
    using UnityEngine;

    /// <summary>
    /// The loading manager.
    /// </summary>
    public class LoadingManager : MonoBehaviour
    {
        /// <summary>
        /// The running operation count.
        /// </summary>
        private int runningOperationCount;

        /// <summary>
        /// The loading event.
        /// </summary>
        [SerializeField]
        public LoadingEvent Loading;

        /// <summary>
        /// Increments the operation count.
        /// </summary>
        public void IncrementRunningOperationCount()
        {
            Interlocked.Increment(ref this.runningOperationCount);
            
            this.Loading.Invoke(true);
        }

        /// <summary>
        /// Decrements the operation count.
        /// </summary>
        public void DecrementRunningOperationCount()
        {
            int newCount = Interlocked.Decrement(ref this.runningOperationCount);

            if (newCount == 0)
            {
                this.Loading.Invoke(false);
            }
        }
    }
}
