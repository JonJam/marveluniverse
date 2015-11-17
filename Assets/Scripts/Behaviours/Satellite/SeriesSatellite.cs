namespace MarvelUniverse.Behaviours.Satellite
{
    using System.Linq;
    using Camera;
    using Communications.Interfaces;
    using Communications.Result;
    using Model.Series;
    using Planet;
    using ViewModels;
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
        /// Display jump options.
        /// </summary>
        protected override void DisplayJumpOptions()
        {
            this.ScreenManager.OpenJumpGatePanel(this.SummaryDataList.Items.Select(s => new JumpOptionViewModel(
                s.Name,
                () =>
                {
                    this.LoadingManager.IncrementRunningOperationCount();

                    this.StartCoroutine(this.seriesService.GetSeries(s.ResourceURI, this.GetSeriesCompleted));
                })));
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
