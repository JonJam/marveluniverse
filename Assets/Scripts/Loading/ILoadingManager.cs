namespace MarvelUniverse.Loading
{
    /// <summary>
    /// Interface for a loading manager.
    /// </summary>
    public interface ILoadingManager
    {
        /// <summary>
        /// The loading event.
        /// </summary>
        LoadingEvent Loading { get; }

        /// <summary>
        /// Increments the operation count.
        /// </summary>
        void IncrementRunningOperationCount();
                
        /// <summary>
        /// Decrements the operation count.
        /// </summary>
        void DecrementRunningOperationCount();
    }
}
