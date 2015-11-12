namespace MarvelUniverse.Behaviours.Planet
{
    using Satellite;
    using Model.Creator;

    /// <summary>
    /// The creator planet behaviour.
    /// </summary>
    public class CreatorPlanet : BasePlanet
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
            this.SetSummaries(this.StoriesSatellite, this.creator.Stories);
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