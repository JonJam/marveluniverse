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
        /// Injection initialization.
        /// </summary>
        /// <param name="eventService">The event service.</param>
        [PostInject]
        private void InjectionInitialize(
            IEventService eventService)
        {
            this.eventService = eventService;
        }
    }
}
