namespace MarvelUniverse.GameObjects.Jumpgate
{
    using System.Collections;
    using Communications.Interfaces;
    using Communications.Result;
    using Model;
    using Model.Character;
    using Zenject;

    /// <summary>
    /// Characters jumpgate behaviour.
    /// </summary>
    public class CharactersJumpgate : BaseJumpgate
    {
        /// <summary>
        /// The character service.
        /// </summary>
        private ICharacterService characterService;

        /// <summary>
        /// Gets the data for the selected jump option.
        /// </summary>
        /// <param name="selectedSummary">The selected summary.</param>
        /// <returns>An enumerator.</returns>
        protected override IEnumerator GetSelectedJumpOptionData(Summary selectedSummary)
        {
            return this.characterService.GetCharacter(selectedSummary.ResourceURI, this.GetCharacterCompleted);
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
            this.OnGetSelectedJumpOptionDataCompleted(result, () => { return this.PlanetSystemSpawner.Instantiate(result.Data, this.transform.position); });
        }
    }
}
