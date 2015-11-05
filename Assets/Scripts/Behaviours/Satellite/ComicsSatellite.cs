namespace MarvelUniverse.Behaviours.Satellite
{
    using Communications.Interfaces;
    using Communications.Result;
    using Loading;
    using Zenject;

    /// <summary>
    /// Comics satellite behaviour.
    /// </summary>
    public class ComicsSatellite : BaseSatellite
    {        
        /// <summary>
        /// The comic service.
        /// </summary>
        private IComicService comicService;

        /// <summary>
        /// The loading manager.
        /// </summary>
        private ILoadingManager loadingManager;

        /// <summary>
        /// The result processor.
        /// </summary>
        private IResultProcessor resultProcessor;

        /// <summary>
        /// Injection initialization.
        /// </summary>
        /// <param name="comicService">The comic service.</param>
        /// <param name="loadingManager">The loading manager.</param>
        /// <param name="resultProcessor">The result processor.</param>
        [PostInject]
        private void InjectionInitialize(
            IComicService comicService,
            ILoadingManager loadingManager,
            IResultProcessor resultProcessor)
        {
            this.comicService = comicService;
            this.loadingManager = loadingManager;
            this.resultProcessor = resultProcessor;
        }
    }
}
