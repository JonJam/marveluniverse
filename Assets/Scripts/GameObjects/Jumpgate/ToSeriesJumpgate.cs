namespace MarvelUniverse.GameObjects.Jumpgate
{
    using System;
    using System.Collections;
    using Communications.Interfaces;
    using Communications.Result;
    using Model;
    using Model.Series;
    using Zenject;

    /// <summary>
    /// To series jumpgate behaviour.
    /// </summary>
    public class ToSeriesJumpgate : BaseJumpgate
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
            this.LoadingManager.IncrementRunningOperationCount();

            this.StartCoroutine(this.seriesService.GetSeries(this.SummaryDataList.Items[0].ResourceURI, this.GetSeriesCompleted));
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
            this.OnGetSelectedJumpOptionDataCompleted(result, () => { return this.PlanetSystemSpawner.Instantiate(result.Data, this.transform.position); });
        }
    }
}
