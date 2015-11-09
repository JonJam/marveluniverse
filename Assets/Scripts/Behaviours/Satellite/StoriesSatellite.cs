namespace MarvelUniverse.Behaviours.Satellite
{
    using Communications.Interfaces;
    using Communications.Result;
    using Loading;
    using Zenject;

    /// <summary>
    /// Stories satellite behaviour.
    /// </summary>
    public class StoriesSatellite : BaseSatellite
    {        
        /// <summary>
        /// The story service.
        /// </summary>
        private IStoryService storyService;

        /// <summary>
        /// Injection initialization.
        /// </summary>
        /// <param name="storyService">The story service.</param>
        /// <param name="loadingManager">The loading manager.</param>
        /// <param name="resultProcessor">The result processor.</param>
        [PostInject]
        private void InjectionInitialize(
            IStoryService storyService)
        {
            this.storyService = storyService;
        }
    }
}
