namespace MarvelUniverse.GameObjects.Planet
{
    using Jumpgate;
    using Model.Creator;

    /// <summary>
    /// The creator planet behaviour.
    /// </summary>
    public class CreatorPlanet : BasePlanet
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
        /// The creator.
        /// </summary>
        private Creator creator;

        /// <summary>
        /// Hooks up the specified creator to the planet.
        /// </summary>
        /// <param name="creator">The creator.</param>
        public void HookUp(Creator creator)
        {
            this.creator = creator;

            this.SetName(this.creator.FullName);
            this.SetImage(this.creator.Thumbnail);
            
            this.SetSummaries(this.ComicsSatellite, this.creator.Comics);
            this.SetSummaries(this.EventsSatellite, this.creator.Events);
            this.SetSummaries(this.SeriesSatellite, this.creator.Series);
        }

        /// <summary>
        /// Display information for this planet.
        /// </summary>
        protected override void DisplayInformation()
        {
            this.ScreenManager.OpenInfoPanel(this.creator);
        }
    }
}