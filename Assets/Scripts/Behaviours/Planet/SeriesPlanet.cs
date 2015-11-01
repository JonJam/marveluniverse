namespace MarvelUniverse.Behaviours.Planet
{
    using Model.Series;

    /// <summary>
    /// The series planet behaviour.
    /// </summary>
    public class SeriesPlanet: BasePlanet
    {
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
        }

        /// <summary>
        /// Display information for this planet system.
        /// </summary>
        protected override void DisplayInformation()
        {
            // TODO implement
        }
    }
}