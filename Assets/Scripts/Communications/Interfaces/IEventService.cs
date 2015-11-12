namespace MarvelUniverse.Communications.Interfaces
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using MarvelUniverse.Communications.Result;
    using Model.Event;

    /// <summary>
    /// Interface for an event service.
    /// </summary>
    public interface IEventService
    {
        /// <summary>
        /// Performs an event search.
        /// </summary>
        /// <param name="searchTerms">The search terms.</param>
        /// <param name="callback">The callback.</param>
        /// <returns>A coroutine.</returns>        
        IEnumerator Search(
            string searchTerms,
            Action<IResult<IList<Event>>> callback);

        /// <summary>
        /// Get event.
        /// </summary>
        /// <param name="eventUri">The event URI.</param>
        /// <param name="callback">The callback.</param>
        /// <returns>A coroutine.</returns>
        IEnumerator GetEvent(
            string eventUri,
            Action<IResult<Event>> callback);
    }
}
