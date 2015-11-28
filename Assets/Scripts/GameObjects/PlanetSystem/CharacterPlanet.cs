namespace MarvelUniverse.GameObjects.Planet
{
    using Jumpgate;
    using Model.Character;

    /// <summary>
    /// The character planet behaviour.
    /// </summary>
    public class CharacterPlanet : BasePlanet
    {
        /// <summary>
        /// The comics jumpgate.
        /// </summary>
        public ComicsJumpgate ComicsSatellite;

        /// <summary>
        /// The events jumpgate.
        /// </summary>
        public EventsJumpgate EventsSatellite;

        /// <summary>
        /// The series jumpgate.
        /// </summary>
        public SeriesJumpgate SeriesSatellite;

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
            this.SetImage(this.character.Thumbnail);

            this.SetSummaries(this.ComicsSatellite, this.character.Comics);
            this.SetSummaries(this.EventsSatellite, this.character.Events);
            this.SetSummaries(this.SeriesSatellite, this.character.Series);
        }

        /// <summary>
        /// Display information for this planet.
        /// </summary>
        protected override void DisplayInformation()
        {
            this.ScreenManager.OpenInfoPanel(this.character);
        }
    }
}