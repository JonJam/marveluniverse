namespace MarvelUniverse.Communications.Interfaces
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using MarvelUniverse.Communications.Result;
    using Model.Comic;

    /// <summary>
    /// Interface for a comic service.
    /// </summary>
    public interface IComicService
    {
        /// <summary>
        /// Performs a comic search.
        /// </summary>
        /// <param name="searchTerms">The search terms.</param>
        /// <param name="callback">The callback.</param>
        /// <returns>A coroutine.</returns>        
        IEnumerator Search(
            string searchTerms,
            Action<IResult<IList<Comic>>> callback);

        /// <summary>
        /// Get comic.
        /// </summary>
        /// <param name="comicUri">The comic URI.</param>
        /// <param name="callback">The callback.</param>
        /// <returns>A coroutine.</returns>
        IEnumerator GetComic(
            string comicUri,
            Action<IResult<Comic>> callback);
    }
}
