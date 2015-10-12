namespace MarvelUniverse.Communications.Web
{
    using UnityEngine;

    /// <summary>
    /// Interface for a web requestor.
    /// </summary>
    public interface IWebRequestor
    {
        /// <summary>
        /// Performs an authorized get request.
        /// </summary>
        /// <param name="requestUri">The request URI.</param>
        /// <returns>An enumerator.</returns>
        WWW PerformAuthorizedGetRequest(
            string requestUri);

        /// <summary>
        /// Performs a get request.
        /// </summary>
        /// <param name="requestUri">The request URI.</param>
        /// <returns>An enumerator.</returns>
        WWW PerformGetRequest(
            string requestUri);
    }
}
