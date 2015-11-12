namespace MarvelUniverse.Communications.Interfaces
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using MarvelUniverse.Communications.Result;
    using Model.Series;

    /// <summary>
    /// Interface for a series service.
    /// </summary>
    public interface ISeriesService
    {
        /// <summary>
        /// Performs a series search.
        /// </summary>
        /// <param name="searchTerms">The search terms.</param>
        /// <param name="callback">The callback.</param>
        /// <returns>A coroutine.</returns>        
        IEnumerator Search(
            string searchTerms,
            Action<IResult<IList<Series>>> callback);

        /// <summary>
        /// Get series.
        /// </summary>
        /// <param name="seriesUri">The series URI.</param>
        /// <param name="callback">The callback.</param>
        /// <returns>A coroutine.</returns>
        IEnumerator GetSeries(
            string seriesUri,
            Action<IResult<Series>> callback);
    }
}
