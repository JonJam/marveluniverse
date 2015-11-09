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
        /// Injection initialization.
        /// </summary>
        /// <param name="seriesService">The series service.</param>
        [PostInject]
        private void InjectionInitialize(
            ISeriesService seriesService)
        {
            this.seriesService = seriesService;
        }
    }
}
