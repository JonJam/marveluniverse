namespace MarvelUniverse.Communications
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using MarvelUniverse.Communications.Result;
    using MarvelUniverse.Communications.Serialization;
    using MarvelUniverse.Communications.Web;
    using MarvelUniverse.Responses;
    using MarvelUniverse.Responses.Character;
    using UnityEngine;

    /// <summary>
    /// A character service.
    /// </summary>
    public class CharacterService : ICharacterService
    {
        /// <summary>
        /// The character search request URL.
        /// </summary>
        private const string CharacterSearchRequestUrl = "http://gateway.marvel.com:80/v1/public/characters?nameStartsWith={0}";

        /// <summary>
        /// The web requestor.
        /// </summary>
        private readonly IWebRequestor webRequestor;

        /// <summary>
        /// The JSON serializer.
        /// </summary>
        private readonly IJsonSerializer jsonSerializer;

        /// <summary>
        /// Initializes a new instance of the <see cref="CharacterService"/> class.
        /// </summary>
        public CharacterService() : this(new WebRequestor(), new JsonSerializer())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CharacterService"/> class.
        /// </summary>
        /// <param name="webRequestor">The web requestor.</param>
        /// <param name="jsonSerializer">The JSON serializer.</param>
        public CharacterService(
            IWebRequestor webRequestor,
            IJsonSerializer jsonSerializer)
        {
            this.webRequestor = webRequestor;
            this.jsonSerializer = jsonSerializer;
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
            string searchRequestUrl = string.Format(CharacterService.CharacterSearchRequestUrl, searchTerms);

            WWW request = this.webRequestor.PerformGetRequest(searchRequestUrl);

            yield return request;

            IResult<IList<Character>> result = null;

            if (string.IsNullOrEmpty(request.error))
            {
                result = this.CreateSuccessfulSearchResult(request.text);
            }
            else
            {
                result = new Result<IList<Character>>(request.error);
            }           

            callback(result);
        }
        
        /// <summary>
        /// Creates a successful search result.
        /// </summary>
        /// <param name="json">The JSON obtained.</param>
        /// <returns>A result.</returns>
        private IResult<IList<Character>> CreateSuccessfulSearchResult(string json)
        {
            DataWrapper<Character> dataWrapper = this.jsonSerializer.Deserialize<DataWrapper<Character>>(json);

            IList<Character> characters = null;

            if (dataWrapper != null &&
                dataWrapper.Data != null)
            {
                characters = dataWrapper.Data.Results;
            }

            return new Result<IList<Character>>(characters);            
        }
    }
}
