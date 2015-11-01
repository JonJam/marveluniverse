namespace MarvelUniverse.Behaviours.Planet
{
    using Model.Character;

    /// <summary>
    /// The character planet behaviour.
    /// </summary>
    public class CharacterPlanet : BasePlanet
    {
        /// <summary>
        /// The character.
        /// </summary>
        private Character character;

        /// <summary>
        /// Hooks up the specified character to the planet.
        /// </summary>
        /// <param name="character">The character.</param>
        public void HookUp(Character character)
        {
            this.character = character;

            this.SetName(this.character.Name);
            this.SetImage(this.character.Thumbnail.Path, this.character.Thumbnail.Extension);
        }

        /// <summary>
        /// Display information for this planet system.
        /// </summary>
        protected override void DisplayInformation()
        {
            this.ScreenManager.OpenInfoPanel(this.character);
        }
    }
}