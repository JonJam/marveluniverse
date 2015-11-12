namespace MarvelUniverse.Behaviours.Satellite
{
    using System.Linq;
    using Camera;
    using Communications.Interfaces;
    using Communications.Result;
    using Model.Creator;
    using Planet;
    using ViewModels;
    using Zenject;

    /// <summary>
    /// Creators satellite behaviour.
    /// </summary>
    public class CreatorsSatellite : BaseSatellite
    {
        /// <summary>
        /// The creator service.
        /// </summary>
        private ICreatorService creatorService;

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

                    this.StartCoroutine(this.creatorService.GetCreator(s.ResourceURI, this.GetCreatorCompleted));
                })));
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
            if (this.ResultProcessor.ProcessResult(result))
            {
                this.ScreenManager.OpenExplorerPanel();

                BasePlanet planet = this.PlanetSystemSpawner.Instantiate(result.Data, this.transform.position);

                this.EventManager.GetEvent<IsCameraMovementEnabledEvent>().Invoke(true);

                this.EventManager.GetEvent<CameraFocusOnEvent>().Invoke(planet.gameObject, planet.CameraRestPosition);
            }

            this.LoadingManager.DecrementRunningOperationCount();
        }
    }
}
