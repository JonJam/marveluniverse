namespace MarvelUniverse.Communications.Interfaces
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using MarvelUniverse.Communications.Result;
    using Model.Creator;

    /// <summary>
    /// Interface for a creator service.
    /// </summary>
    public interface ICreatorService
    {
        /// <summary>
        /// Performs a creator search.
        /// </summary>
        /// <param name="searchTerms">The search terms.</param>
        /// <param name="callback">The callback.</param>
        /// <returns>A coroutine.</returns>        
        IEnumerator Search(
            string searchTerms,
            Action<IResult<IList<Creator>>> callback);

        /// <summary>
        /// Get creator.
        /// </summary>
        /// <param name="creatorUri">The creator URI.</param>
        /// <param name="callback">The callback.</param>
        /// <returns>A coroutine.</returns>
        IEnumerator GetCreator(
            string creatorUri,
            Action<IResult<Creator>> callback);
    }
}
