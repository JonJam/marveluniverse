namespace MarvelUniverse.Communications.Web
{
    using UnityEngine;

    /// <summary>
    /// Interface for a web requestor.
    /// </summary>
    public interface IWebRequestor
    {
        /// <summary>
        /// Performs a get request.
        /// </summary>
        /// <param name="requestUri">The request URI.</param>
        /// <returns>An enumerator.</returns>
        WWW PerformGetRequest(
            string requestUri);
    }
}
