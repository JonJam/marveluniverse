namespace MarvelUniverse.Behaviours.Satellite
{
    using System.Linq;
    using Camera;
    using Communications.Interfaces;
    using Communications.Result;
    using Model.Character;
    using Planet;
    using ViewModels;
    using Zenject;

    /// <summary>
    /// Characters satellite behaviour.
    /// </summary>
    public class CharactersSatellite : BaseSatellite
    {
        /// <summary>
        /// The character service.
        /// </summary>
        private ICharacterService characterService;

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

                    this.StartCoroutine(this.characterService.GetCharacter(s.ResourceURI, this.GetCharacterCompleted));
                })));
        }

        /// <summary>
        /// Injection initialization.
        /// </summary>
        /// <param name="characterService">The character service.</param>
        [PostInject]
        private void InjectionInitialize(
            ICharacterService characterService)
        {
            this.characterService = characterService;
        }

        /// <summary>
        /// Handles the completion of get character.
        /// </summary>
        /// <param name="result">The result.</param>
        private void GetCharacterCompleted(IResult<Character> result)
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
