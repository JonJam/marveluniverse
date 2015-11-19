namespace MarvelUniverse.Behaviours.Satellite
{
    using System.Collections;
    using Communications.Interfaces;
    using Communications.Result;
    using Model;
    using Model.Comic;
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
        /// Gets the data for the selected jump option.
        /// </summary>
        /// <param name="selectedSummary">The selected summary.</param>
        /// <returns>An enumerator.</returns>
        protected override IEnumerator GetSelectedJumpOptionData(Summary selectedSummary)
        {
            return this.comicService.GetComic(selectedSummary.ResourceURI, this.GetComicCompleted);
        }

        /// <summary>
        /// Injection initialization.
        /// </summary>
        /// <param name="comicService">The comic service.</param>
        [PostInject]
        private void InjectionInitialize(
            IComicService comicService)
        {
            this.comicService = comicService;
        }

        /// <summary>
        /// Handles the completion of get comic.
        /// </summary>
        /// <param name="result">The result.</param>
        private void GetComicCompleted(IResult<Comic> result)
        {
            this.OnGetSelectedJumpOptionDataCompleted(result, () => { return this.PlanetSystemSpawner.Instantiate(result.Data, this.transform.position); });
        }
    }
}
