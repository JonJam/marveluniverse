namespace MarvelUniverse.GameObjects.Planet
{
    using Jumpgate;
    using Model;
    using Model.Event;

    /// <summary>
    /// The event planet behaviour.
    /// </summary>
    public class EventPlanet : BasePlanet
    {
        /// <summary>
        /// The characters jumpgate.
        /// </summary>
        public CharactersJumpgate CharactersSatellite;

        /// <summary>
        /// The events jumpgate.
        /// </summary>
        public ComicsJumpgate ComicsSatellite;

        /// <summary>
        /// The creators jumpgate.
        /// </summary>
        public CreatorsJumpgate CreatorsSatellite;

        /// <summary>
        /// The next event jumpgate.
        /// </summary>
        public ToEventJumpgate NextEventSatellite;

        /// <summary>
        /// The previous event jumpgate.
        /// </summary>
        public ToEventJumpgate PreviousEventSatellite;

        /// <summary>
        /// The series jumpgate.
        /// </summary>
        public SeriesJumpgate SeriesSatellite;

        /// <summary>
        /// The comic event.
        /// </summary>
        private Event comicEvent;

        /// <summary>
        /// Hooks up the specified comic event to the planet.
        /// </summary>
        /// <param name="comicEvent">The comic event.</param>
        public void HookUp(Event comicEvent)
        {
            this.comicEvent = comicEvent;

            this.SetName(this.comicEvent.Title);
            this.SetImage(this.comicEvent.Thumbnail);

            this.SetSummaries(this.CharactersSatellite, this.comicEvent.Characters);
            this.SetSummaries(this.ComicsSatellite, this.comicEvent.Comics);
            this.SetSummaries(this.CreatorsSatellite, this.comicEvent.Creators);
            this.SetSummaries(this.SeriesSatellite, this.comicEvent.Series);

            DataList<Summary> next = null;

            if (this.comicEvent.Next != null &&
                this.comicEvent.Next.HasData)
            {
                next = new DataList<Summary>()
                {
                    Available = 1,
                    Returned = 1,
                    Items = new Summary[] { this.comicEvent.Next }
                };
            }

            this.SetSummaries(this.NextEventSatellite, next);

            DataList<Summary> previous = null;

            if (this.comicEvent.Previous != null &&
                this.comicEvent.Previous.HasData)
            {
                previous = new DataList<Summary>()
                {
                    Available = 1,
                    Returned = 1,
                    Items = new Summary[] { this.comicEvent.Previous }
                };
            }

            this.SetSummaries(this.PreviousEventSatellite, previous);
        }

        /// <summary>
        /// Display information for this planet.
        /// </summary>
        protected override void DisplayInformation()
        {
            this.ScreenManager.OpenInfoPanel(this.comicEvent);
        }
    }
}