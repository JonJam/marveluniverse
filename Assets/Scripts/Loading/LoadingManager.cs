namespace MarvelUniverse.Loading
{
    using System.Threading;
    using Events;

    /// <summary>
    /// The loading manager.
    /// </summary>
    public class LoadingManager : ILoadingManager
    {
        /// <summary>
        /// The event manager.
        /// </summary>
        private readonly IEventManager eventManager;

        /// <summary>
        /// The running operation count.
        /// </summary>
        private int runningOperationCount;

        /// <summary>
        /// Initializes a new instance of the <see cref="LoadingManager"/> class.
        /// </summary>
        /// <param name="eventManager">The event manager.</param>
        public LoadingManager(IEventManager eventManager)
        {
            this.eventManager = eventManager;  
        }

        /// <summary>
        /// Increments the operation count.
        /// </summary>
        public void IncrementRunningOperationCount()
        {
            Interlocked.Increment(ref this.runningOperationCount);
            
            this.eventManager.GetEvent<LoadingEvent>().Invoke(true);
        }

        /// <summary>
        /// Decrements the operation count.
        /// </summary>
        public void DecrementRunningOperationCount()
        {
            int newCount = Interlocked.Decrement(ref this.runningOperationCount);

            if (newCount == 0)
            {
                this.eventManager.GetEvent<LoadingEvent>().Invoke(false);
            }
        }
    }
}
