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
    using Model.Comic;
    using UnityEngine;

    /// <summary>
    /// A comic service.
    /// </summary>
    public class ComicService : BaseService, IComicService
    {
        /// <summary>
        /// The comic search request URL.
        /// </summary>
        private const string ComicSearchRequestUrl = "http://gateway.marvel.com:80/v1/public/comics?titleStartsWith={0}";

        /// <summary>
        /// The web requestor.
        /// </summary>
        private readonly IWebRequestor webRequestor;
        
        /// <summary>
        /// Initializes a new instance of the <see cref="ComicService"/> class.
        /// </summary>
        /// <param name="webRequestor">The web requestor.</param>
        /// <param name="jsonSerializer">The JSON serializer.</param>
        public ComicService(
            IWebRequestor webRequestor,
            IJsonSerializer jsonSerializer) : base(jsonSerializer)
        {
            this.webRequestor = webRequestor;
        }

        /// <summary>
        /// Performs a comic search.
        /// </summary>
        /// <param name="searchTerms">The search terms.</param>
        /// <param name="callback">The callback.</param>
        /// <returns>A coroutine.</returns>
        public IEnumerator Search(
            string searchTerms,
            Action<IResult<IList<Comic>>> callback)
        {
            searchTerms = WWW.EscapeURL(searchTerms);

            string searchRequestUrl = string.Format(ComicService.ComicSearchRequestUrl, searchTerms);

            WWW request = this.webRequestor.PerformAuthorizedGetRequest(searchRequestUrl);

            yield return request;

            IResult<IList<Comic>> result = null;

            if (request != null &&
                string.IsNullOrEmpty(request.error))
            {
                result = this.CreateSuccessfulSearchResult<Comic>(request.text);
            }
            else
            {
                result = new Result<IList<Comic>>(request.error);
            }           

            callback(result);
        }
       
    }
}
