namespace MarvelUniverse.Behaviours.Satellite
{
    using System.Linq;
    using Camera;
    using Communications.Interfaces;
    using Communications.Result;
    using Model.Comic;
    using Planet;
    using ViewModels;
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
        /// Display jump options.
        /// </summary>
        protected override void DisplayJumpOptions()
        {
            this.ScreenManager.OpenJumpGatePanel(this.SummaryDataList.Items.Select(s => new JumpOptionViewModel(
                s.Name,
                () =>
                {
                    this.LoadingManager.IncrementRunningOperationCount();

                    this.StartCoroutine(this.comicService.GetComic(s.ResourceURI, this.GetComicCompleted));
                })));
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
