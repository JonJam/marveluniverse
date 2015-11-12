namespace MarvelUniverse.Behaviours.Satellite
{
    using System.Linq;
    using Camera;
    using Communications.Interfaces;
    using Communications.Result;
    using Model.Story;
    using Planet;
    using ViewModels;
    using Zenject;

    /// <summary>
    /// Stories satellite behaviour.
    /// </summary>
    public class StoriesSatellite : BaseSatellite
    {        
        /// <summary>
        /// The story service.
        /// </summary>
        private IStoryService storyService;

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

                    this.StartCoroutine(this.storyService.GetStory(s.ResourceURI, this.GetStoryCompleted));
                })));
        }

        /// <summary>
        /// Injection initialization.
        /// </summary>
        /// <param name="storyService">The story service.</param>
        [PostInject]
        private void InjectionInitialize(
            IStoryService storyService)
        {
            this.storyService = storyService;
        }

        /// <summary>
        /// Handles the completion of get story.
        /// </summary>
        /// <param name="result">The result.</param>
        private void GetStoryCompleted(IResult<Story> result)
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
