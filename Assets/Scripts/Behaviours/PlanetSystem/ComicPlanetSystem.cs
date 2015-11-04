namespace MarvelUniverse.Behaviours.PlanetSystem
{
    using Model.Comic;

    /// <summary>
    /// The comic planet system behaviour.
    /// </summary>
    public class ComicPlanetSystem : BasePlanetSystem
    {
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
        }

        /// <summary>
        /// Display information for this planet system.
        /// </summary>
        protected override void DisplayInformation()
        {
            this.ScreenManager.OpenInfoPanel(this.comic);
        }
    }
}