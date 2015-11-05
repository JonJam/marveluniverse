namespace MarvelUniverse.Behaviours.Satellite
{
    using Communications.Interfaces;
    using Communications.Result;
    using Loading;
    using Zenject;

    /// <summary>
    /// Series satellite behaviour.
    /// </summary>
    public class SeriesSatellite : BaseSatellite
    {
        /// <summary>
        /// The series service.
        /// </summary>
        private ISeriesService seriesService;

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
        /// <param name="seriesService">The series service.</param>
        /// <param name="loadingManager">The loading manager.</param>
        /// <param name="resultProcessor">The result processor.</param>
        [PostInject]
        private void InjectionInitialize(
            ISeriesService seriesService,
            ILoadingManager loadingManager,
            IResultProcessor resultProcessor)
        {
            this.seriesService = seriesService;
            this.loadingManager = loadingManager;
            this.resultProcessor = resultProcessor;
        }
    }
}
