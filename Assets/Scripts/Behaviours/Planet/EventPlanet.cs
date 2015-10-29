﻿namespace MarvelUniverse.Behaviours.Planet
{
    using Model.Event;

    /// <summary>
    /// The event planet behaviour.
    /// </summary>
    public class EventPlanet: BasePlanet
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
            this.SetImage(this.comicEvent.Thumbnail.Path, this.comicEvent.Thumbnail.Extension);
        }
    }
}