namespace MarvelUniverse.Behaviours.Satellite
{
    using System;
    using Camera;
    using Communications.Interfaces;
    using Communications.Result;
    using Model.Series;
    using Planet;
    using Zenject;

    /// <summary>
    /// To series satellite behaviour.
    /// </summary>
    public class ToSeriesSatellite : BaseSatellite
    {
        /// <summary>
        /// The series service.
        /// </summary>
        private ISeriesService seriesService;

        /// <summary>
        /// Handles the mouse down event.
        /// </summary>
        protected override void OnMouseDown()
        {
            this.LoadingManager.IncrementRunningOperationCount();

            this.StartCoroutine(this.seriesService.GetSeries(this.SummaryDataList.Items[0].ResourceURI, this.GetSeriesCompleted));
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
        /// <param name="seriesService">The series service.</param>
        [PostInject]
        private void InjectionInitialize(
            ISeriesService seriesService)
        {
            this.seriesService = seriesService;
        }

        /// <summary>
        /// Handles the completion of get series.
        /// </summary>
        /// <param name="result">The result.</param>
        private void GetSeriesCompleted(IResult<Series> result)
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
