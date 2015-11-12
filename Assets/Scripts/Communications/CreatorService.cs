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
    using Model.Creator;
    using UnityEngine;

    /// <summary>
    /// A creator service.
    /// </summary>
    public class CreatorService : BaseService, ICreatorService
    {
        /// <summary>
        /// The creator search request URL.
        /// </summary>
        private const string CreatorSearchRequestUrl = "http://gateway.marvel.com:80/v1/public/creators?nameStartsWith={0}&orderBy=firstName";

        /// <summary>
        /// The web requestor.
        /// </summary>
        private readonly IWebRequestor webRequestor;
        
        /// <summary>
        /// Initializes a new instance of the <see cref="CreatorService"/> class.
        /// </summary>
        /// <param name="webRequestor">The web requestor.</param>
        /// <param name="jsonSerializer">The JSON serializer.</param>
        public CreatorService(
            IWebRequestor webRequestor,
            IJsonSerializer jsonSerializer) : base(jsonSerializer)
        {
            this.webRequestor = webRequestor;
        }

        /// <summary>
        /// Performs a creator search.
        /// </summary>
        /// <param name="searchTerms">The search terms.</param>
        /// <param name="callback">The callback.</param>
        /// <returns>A coroutine.</returns>
        public IEnumerator Search(
            string searchTerms,
            Action<IResult<IList<Creator>>> callback)
        {
            searchTerms = WWW.EscapeURL(searchTerms);

            string searchRequestUrl = string.Format(CreatorService.CreatorSearchRequestUrl, searchTerms);

            WWW request = this.webRequestor.PerformAuthorizedGetRequest(searchRequestUrl);

            yield return request;

            IResult<IList<Creator>> result = null;

            if (request != null &&
                string.IsNullOrEmpty(request.error))
            {
                result = this.CreateSuccessfulListResult<Creator>(request.text);
            }
            else
            {
                result = new Result<IList<Creator>>(request.error);
            }           

            callback(result);
        }

        /// <summary>
        /// Get creator.
        /// </summary>
        /// <param name="creatorUri">The creator URI.</param>
        /// <param name="callback">The callback.</param>
        /// <returns>A coroutine.</returns>
        public IEnumerator GetCreator(
            string creatorUri,
            Action<IResult<Creator>> callback)
        {
            WWW request = this.webRequestor.PerformAuthorizedGetRequest(creatorUri);

            yield return request;

            IResult<Creator> result = null;

            if (request != null &&
                string.IsNullOrEmpty(request.error))
            {
                result = this.CreateSuccessfulResult<Creator>(request.text);
            }
            else
            {
                result = new Result<Creator>(request.error);
            }

            callback(result);
        }
    }
}
