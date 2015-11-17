namespace MarvelUniverse.Behaviours.Satellite
{
    using System;
    using Camera;
    using Communications.Interfaces;
    using Communications.Result;
    using Model.Event;
    using Planet;
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
        /// Handles the mouse down event.
        /// </summary>
        protected override void OnMouseDown()
        {
            this.LoadingManager.IncrementRunningOperationCount();

            this.StartCoroutine(this.eventService.GetEvent(this.SummaryDataList.Items[0].ResourceURI, this.GetEventCompleted));
        }
        
        /// <summary>
        /// Display jump options.
        /// </summary>
        protected override void DisplayJumpOptions()
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
            if (this.ResultProcessor.ProcessResult(result))
            {
                this.ScreenManager.OpenExplorerPanel();

                BasePlanet planet = this.PlanetSystemSpawner.Instantiate(result.Data, this.transform.position);

                this.EventManager.GetEvent<CameraFocusOnEvent>().Invoke(planet.gameObject, planet.CameraRestPosition);
            }

            this.LoadingManager.DecrementRunningOperationCount();
        }
    }
}
