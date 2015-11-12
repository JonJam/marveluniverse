namespace MarvelUniverse.Communications
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using Interfaces;
    using MarvelUniverse.Communications.Result;
    using MarvelUniverse.Communications.Serialization;
    using MarvelUniverse.Communications.Web;
    using MarvelUniverse.Model;
    using Model.Event;
    using UnityEngine;
    using Event = MarvelUniverse.Model.Event.Event;

    /// <summary>
    /// An event service.
    /// </summary>
    public class EventService : BaseService, IEventService
    {
        /// <summary>
        /// The event search request URL.
        /// </summary>
        private const string EventSearchRequestUrl = "http://gateway.marvel.com:80/v1/public/events?nameStartsWith={0}&orderBy=name";

        /// <summary>
        /// The web requestor.
        /// </summary>
        private readonly IWebRequestor webRequestor;

        /// <summary>
        /// Initializes a new instance of the <see cref="EventService"/> class.
        /// </summary>
        /// <param name="webRequestor">The web requestor.</param>
        /// <param name="jsonSerializer">The JSON serializer.</param>
        public EventService(
            IWebRequestor webRequestor,
            IJsonSerializer jsonSerializer) : base(jsonSerializer)
        {
            this.webRequestor = webRequestor;
        }

        /// <summary>
        /// Performs an event search.
        /// </summary>
        /// <param name="searchTerms">The search terms.</param>
        /// <param name="callback">The callback.</param>
        /// <returns>A coroutine.</returns>
        public IEnumerator Search(
            string searchTerms,
            Action<IResult<IList<Event>>> callback)
        {
            searchTerms = WWW.EscapeURL(searchTerms);

            string searchRequestUrl = string.Format(EventService.EventSearchRequestUrl, searchTerms);

            WWW request = this.webRequestor.PerformAuthorizedGetRequest(searchRequestUrl);

            yield return request;

            IResult<IList<Event>> result = null;

            if (request != null &&
                string.IsNullOrEmpty(request.error))
            {
                result = this.CreateSuccessfulListResult<Event>(request.text);
            }
            else
            {
                result = new Result<IList<Event>>(request.error);
            }           

            callback(result);
        }

        /// <summary>
        /// Get event.
        /// </summary>
        /// <param name="eventUri">The event URI.</param>
        /// <param name="callback">The callback.</param>
        /// <returns>A coroutine.</returns>
        public IEnumerator GetEvent(
            string eventUri,
            Action<IResult<Event>> callback)
        {
            WWW request = this.webRequestor.PerformAuthorizedGetRequest(eventUri);

            yield return request;

            IResult<Event> result = null;

            if (request != null &&
                string.IsNullOrEmpty(request.error))
            {
                result = this.CreateSuccessfulResult<Event>(request.text);
            }
            else
            {
                result = new Result<Event>(request.error);
            }

            callback(result);
        }
    }
}
