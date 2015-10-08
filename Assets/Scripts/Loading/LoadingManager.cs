namespace MarvelUniverse.Loading
{
    using System.Threading;

    /// <summary>
    /// The loading manager.
    /// </summary>
    public class LoadingManager
    {
        /// <summary>
        /// The running operation count.
        /// </summary>
        private int runningOperationCount;

        /// <summary>
        /// The loading event.
        /// </summary>
        public LoadingEvent Loading;

        /// <summary>
        /// Initializes a new instance of the <see cref="LoadingManager"/> class.
        /// </summary>
        public LoadingManager()
        {
            this.Loading = new LoadingEvent();
        }

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
