namespace MarvelUniverse.Behaviours.Satellite
{
    using System;
    using System.Collections;
    using Communications.Interfaces;
    using Communications.Result;
    using Model;
    using Model.Event;
    using Zenject;

    /// <summary>
    /// To event satellite behaviour.
    /// </summary>
    public class ToEventSatellite : BaseSatellite
    {
        /// <summary>
        /// The event service.
        /// </summary>
        private IEventService eventService;

        /// <summary>
        /// Display jump options.
        /// </summary>
        protected override void DisplayJumpOptions()
        {
            this.LoadingManager.IncrementRunningOperationCount();

            this.StartCoroutine(this.eventService.GetEvent(this.SummaryDataList.Items[0].ResourceURI, this.GetEventCompleted));
        }

        /// <summary>
        /// Gets the data for the selected jump option.
        /// </summary>
        /// <param name="selectedSummary">The selected summary.</param>
        /// <returns>An enumerator.</returns>
        protected override IEnumerator GetSelectedJumpOptionData(Summary selectedSummary)
        {
            throw new NotImplementedException();
        }

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

        /// <summary>
        /// Handles the completion of get event
        /// </summary>
        /// <param name="result">The result.</param>
        private void GetEventCompleted(IResult<Event> result)
        {
            this.OnGetSelectedJumpOptionDataCompleted(result, () => { return this.PlanetSystemSpawner.Instantiate(result.Data, this.transform.position); });
        }
    }
}
