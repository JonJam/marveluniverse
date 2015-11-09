namespace MarvelUniverse.Behaviours.Planet
{
    using Model.Character;
    using Satellite;

    /// <summary>
    /// The character planet behaviour.
    /// </summary>
    public class CharacterPlanet : BasePlanet
    {
        /// <summary>
        /// The comics satellite.
        /// </summary>
        public ComicsSatellite ComicsSatellite;

        /// <summary>
        /// The events satellite.
        /// </summary>
        public EventsSatellite EventsSatellite;

        /// <summary>
        /// The series satellite.
        /// </summary>
        public SeriesSatellite SeriesSatellite;

        /// <summary>
        /// The stories satellite.
        /// </summary>
        public StoriesSatellite StoriesSatellite;

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
            this.SetSummaries(this.StoriesSatellite, this.character.Stories);
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