namespace MarvelUniverse.Behaviours.Planet
{
    using Model;
    using Model.Series;
    using Satellite;

    /// <summary>
    /// The series planet behaviour.
    /// </summary>
    public class SeriesPlanet : BasePlanet
    {
        /// <summary>
        /// The characters satellite.
        /// </summary>
        public CharactersSatellite CharactersSatellite;

        /// <summary>
        /// The events satellite.
        /// </summary>
        public ComicsSatellite ComicsSatellite;

        /// <summary>
        /// The creators satellite.
        /// </summary>
        public CreatorsSatellite CreatorsSatellite;

        /// <summary>
        /// The events satellite.
        /// </summary>
        public EventsSatellite EventsSatellite;

        /// <summary>
        /// The next series satellite.
        /// </summary>
        public ToSeriesSatellite NextSeriesSatellite;

        /// <summary>
        /// The previous series satellite.
        /// </summary>
        public ToSeriesSatellite PreviousSeriesSatellite;

        /// <summary>
        /// The stories satellite.
        /// </summary>
        public StoriesSatellite StoriesSatellite;

        /// <summary>
        /// The series.
        /// </summary>
        private Series series;

        /// <summary>
        /// Hooks up the specified series to the planet.
        /// </summary>
        /// <param name="series">The series.</param>
        public void HookUp(Series series)
        {
            this.series = series;

            this.SetName(this.series.Title);
            this.SetImage(this.series.Thumbnail);

            this.SetSummaries(this.CharactersSatellite, this.series.Characters);
            this.SetSummaries(this.ComicsSatellite, this.series.Comics);
            this.SetSummaries(this.CreatorsSatellite, this.series.Creators);
            this.SetSummaries(this.EventsSatellite, this.series.Events);
            this.SetSummaries(this.StoriesSatellite, this.series.Stories);

            DataList<Summary> next = null;

            if (this.series.Next != null &&
                this.series.Next.HasData)
            {
                next = new DataList<Summary>()
                {
                    Available = 1,
                    Returned = 1,
                    Items = new Summary[] { this.series.Next }
                };
            }

            this.SetSummaries(this.NextSeriesSatellite, next);

            DataList<Summary> previous = null;

            if (this.series.Previous != null &&
                this.series.Previous.HasData)
            {
                previous = new DataList<Summary>()
                {
                    Available = 1,
                    Returned = 1,
                    Items = new Summary[] { this.series.Previous }
                };
            }

            this.SetSummaries(this.PreviousSeriesSatellite, previous);
        }

        /// <summary>
        /// Display information for this planet.
        /// </summary>
        protected override void DisplayInformation()
        {
            this.ScreenManager.OpenInfoPanel(this.series);
        }
    }
}