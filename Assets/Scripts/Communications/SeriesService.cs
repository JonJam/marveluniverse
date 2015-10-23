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
    using Model.Series;
    using Model.Creator;
    using UnityEngine;

    /// <summary>
    /// A series service.
    /// </summary>
    public class SeriesService : BaseService, ISeriesService
    {
        /// <summary>
        /// The series search request URL.
        /// </summary>
        private const string SeriesSearchRequestUrl = "http://gateway.marvel.com:80/v1/public/series?titleStartsWith={0}";

        /// <summary>
        /// The web requestor.
        /// </summary>
        private readonly IWebRequestor webRequestor;
                
        /// <summary>
        /// Initializes a new instance of the <see cref="SeriesService"/> class.
        /// </summary>
        /// <param name="webRequestor">The web requestor.</param>
        /// <param name="jsonSerializer">The JSON serializer.</param>
        public SeriesService(
            IWebRequestor webRequestor,
            IJsonSerializer jsonSerializer) : base(jsonSerializer)
        {
            this.webRequestor = webRequestor;
        }

        /// <summary>
        /// Performs a series search.
        /// </summary>
        /// <param name="searchTerms">The search terms.</param>
        /// <param name="callback">The callback.</param>
        /// <returns>A coroutine.</returns>
        public IEnumerator Search(
            string searchTerms,
            Action<IResult<IList<Series>>> callback)
        {
            searchTerms = WWW.EscapeURL(searchTerms);

            string searchRequestUrl = string.Format(SeriesService.SeriesSearchRequestUrl, searchTerms);

            WWW request = this.webRequestor.PerformAuthorizedGetRequest(searchRequestUrl);

            yield return request;

            IResult<IList<Series>> result = null;

            if (request != null &&
                string.IsNullOrEmpty(request.error))
            {
                result = this.CreateSuccessfulSearchResult<Series>(request.text);
            }
            else
            {
                result = new Result<IList<Series>>(request.error);
            }           

            callback(result);
        }
    }
}
