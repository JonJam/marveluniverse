namespace MarvelUniverse.GameObjects.Jumpgate
{
    using System.Collections;
    using Communications.Interfaces;
    using Communications.Result;
    using Model;
    using Model.Creator;
    using Zenject;

    /// <summary>
    /// Creators jumpgate behaviour.
    /// </summary>
    public class CreatorsJumpgate : BaseJumpgate
    {
        /// <summary>
        /// The creator service.
        /// </summary>
        private ICreatorService creatorService;

        /// <summary>
        /// Gets the data for the selected jump option.
        /// </summary>
        /// <param name="selectedSummary">The selected summary.</param>
        /// <returns>An enumerator.</returns>
        protected override IEnumerator GetSelectedJumpOptionData(Summary selectedSummary)
        {
            return this.creatorService.GetCreator(selectedSummary.ResourceURI, this.GetCreatorCompleted);
        }

        /// <summary>
        /// Injection initialization.
        /// </summary>
        /// <param name="creatorService">The creator service.</param>
        [PostInject]
        private void InjectionInitialize(
            ICreatorService creatorService)
        {
            this.creatorService = creatorService;
        }

        /// <summary>
        /// Handles the completion of get creator.
        /// </summary>
        /// <param name="result">The result.</param>
        private void GetCreatorCompleted(IResult<Creator> result)
        {
            this.OnGetSelectedJumpOptionDataCompleted(result, () => { return this.PlanetSystemSpawner.Instantiate(result.Data, this.transform.position); });
        }
    }
}
