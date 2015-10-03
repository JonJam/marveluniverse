namespace MarvelUniverse
{
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
            
            this.StartCoroutine(webRequestor.PerformGetRequest("http://gateway.marvel.com:80/v1/public/characters?name=Spider-Man"));            
        }

    }
}
