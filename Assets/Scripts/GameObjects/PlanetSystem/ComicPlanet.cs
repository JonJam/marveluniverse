﻿namespace MarvelUniverse.GameObjects.Planet
{
    using Jumpgate;
    using Model;
    using Model.Comic;

    /// <summary>
    /// The comic planet behaviour.
    /// </summary>
    public class ComicPlanet : BasePlanet
    {
        /// <summary>
        /// The characters jumpgate.
        /// </summary>
        public CharactersJumpgate CharactersSatellite;

        /// <summary>
        /// The creators jumpgate.
        /// </summary>
        public CreatorsJumpgate CreatorsSatellite;

        /// <summary>
        /// The events jumpgate.
        /// </summary>
        public EventsJumpgate EventsSatellite;

        /// <summary>
        /// The series jumpgate.
        /// </summary>
        public SeriesJumpgate SeriesSatellite;

        /// <summary>
        /// The comic.
        /// </summary>
        private Comic comic;

        /// <summary>
        /// Hooks up the specified comic to the planet.
        /// </summary>
        /// <param name="comic">The comic.</param>
        public void HookUp(Comic comic)
        {
            this.comic = comic;

            this.SetName(this.comic.Title);
            this.SetImage(this.comic.Thumbnail);
            
            this.SetSummaries(this.CharactersSatellite, this.comic.Characters);
            this.SetSummaries(this.CreatorsSatellite, this.comic.Creators);
            this.SetSummaries(this.EventsSatellite, this.comic.Events);

            DataList<Summary> series = null;

            if (this.comic.Series != null &&
                this.comic.Series.HasData)
            {
                series = new DataList<Summary>()
                {
                    Available = 1,
                    Returned = 1,
                    Items = new Summary[] { this.comic.Series }
                };
            }
            
            this.SetSummaries(this.SeriesSatellite, series);
        }

        /// <summary>
        /// Display information for this planet.
        /// </summary>
        protected override void DisplayInformation()
        {
            this.ScreenManager.OpenInfoPanel(this.comic);
        }
    }
}