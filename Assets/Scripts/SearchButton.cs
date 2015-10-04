namespace MarvelUniverse
{
    using System;
    using Communications.Web;
    using UnityEngine;

    /// <summary>
    /// Search button behaviour.
    /// </summary>
    public class SearchButton : MonoBehaviour
    {
        /// <summary>
        /// Handles the search clicked event.
        /// </summary>
        public void SearchClicked()
        {
            WebRequestor webRequestor = new WebRequestor();

            this.StartCoroutine(webRequestor.PerformGetRequest("http://gateway.marvel.com:80/v1/public/characters?name=Spider-Man", this.HandleWebRequest));
        }

        /// <summary>
        /// Handles the web request.
        /// </summary>
        /// <param name="webRequest">The web request.</param>
        private void HandleWebRequest(WWW webRequest)
        {
            if (string.IsNullOrEmpty(webRequest.error))
            {
                Debug.Log("Success");
            }
            else
            {
                Debug.Log("fail");
            }

        }
    }
}
