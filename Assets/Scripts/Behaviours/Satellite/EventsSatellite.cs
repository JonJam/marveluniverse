namespace MarvelUniverse.Behaviours.Satellite
{
    using Communications.Interfaces;
    using Communications.Result;
    using Loading;
    using Zenject;

    /// <summary>
    /// Events satellite behaviour.
    /// </summary>
    public class EventsSatellite : BaseSatellite
    {
        /// <summary>
        /// The event service.
        /// </summary>
        private IEventService eventService;

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
        /// <param name="eventService">The event service.</param>
        /// <param name="loadingManager">The loading manager.</param>
        /// <param name="resultProcessor">The result processor.</param>
        [PostInject]
        private void InjectionInitialize(
            IEventService eventService,
            ILoadingManager loadingManager,
            IResultProcessor resultProcessor)
        {
            this.eventService = eventService;
            this.loadingManager = loadingManager;
            this.resultProcessor = resultProcessor;
        }
    }
}
