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
    using MarvelUniverse.Model.Character;
    using UnityEngine;

    /// <summary>
    /// A character service.
    /// </summary>
    public class CharacterService : BaseService, ICharacterService
    {
        /// <summary>
        /// The character search request URL.
        /// </summary>
        private const string CharacterSearchRequestUrl = "http://gateway.marvel.com:80/v1/public/characters?nameStartsWith={0}&orderBy=name";

        /// <summary>
        /// The web requestor.
        /// </summary>
        private readonly IWebRequestor webRequestor;

        /// <summary>
        /// Initializes a new instance of the <see cref="CharacterService"/> class.
        /// </summary>
        /// <param name="webRequestor">The web requestor.</param>
        /// <param name="jsonSerializer">The JSON serializer.</param>
        public CharacterService(
            IWebRequestor webRequestor,
            IJsonSerializer jsonSerializer) : base(jsonSerializer)
        {
            this.webRequestor = webRequestor;
        }

        /// <summary>
        /// Performs a character search.
        /// </summary>
        /// <param name="searchTerms">The search terms.</param>
        /// <param name="callback">The callback.</param>
        /// <returns>A coroutine.</returns>
        public IEnumerator Search(
            string searchTerms,
            Action<IResult<IList<Character>>> callback)
        {
            searchTerms = WWW.EscapeURL(searchTerms);

            string searchRequestUrl = string.Format(CharacterService.CharacterSearchRequestUrl, searchTerms);

            WWW request = this.webRequestor.PerformAuthorizedGetRequest(searchRequestUrl);

            yield return request;

            IResult<IList<Character>> result = null;

            if (request != null &&
                string.IsNullOrEmpty(request.error))
            {
                result = this.CreateSuccessfulSearchResult<Character>(request.text);
            }
            else
            {
                result = new Result<IList<Character>>(request.error);
            }           

            callback(result);
        }
    }
}
