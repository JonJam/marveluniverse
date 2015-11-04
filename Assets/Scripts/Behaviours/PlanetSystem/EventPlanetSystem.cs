namespace MarvelUniverse.Behaviours.PlanetSystem
{
    using Model.Event;

    /// <summary>
    /// The event planet system behaviour.
    /// </summary>
    public class EventPlanetSystem: BasePlanetSystem
    {
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
        }

        /// <summary>
        /// Display information for this planet system.
        /// </summary>
        protected override void DisplayInformation()
        {
            this.ScreenManager.OpenInfoPanel(this.comicEvent);
        }
    }
}