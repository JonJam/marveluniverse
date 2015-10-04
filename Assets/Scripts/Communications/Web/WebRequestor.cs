namespace MarvelUniverse.Communications.Web
{
    using System;
    using System.Collections;
    using MarvelUniverse.Communications.Encryption;
    using UnityEngine;

    /// <summary>
    /// The web requestor class.
    /// </summary>
    public class WebRequestor
    {
        /// <summary>
        /// The public key.
        /// </summary>
        private const string PublicKey = "";

        /// <summary>
        /// The private key.
        /// </summary>
        private const string PrivateKey = "";

        /// <summary>
        /// The authentication query parameters.
        /// </summary>
        private const string AuthenticationQueryParamters = "&ts={0}&apikey={1}&hash={2}";

        /// <summary>
        /// EPOCH time.
        /// </summary>
        private static readonly DateTime EpochTime = new DateTime(1970, 1, 1);
        
        /// <summary>
        /// The encryption service.
        /// </summary>
        private readonly EncryptionService encryptionService;

        /// <summary>
        /// Initializes a new instance of the <see cref="WebRequestor"/> class.
        /// </summary>
        public WebRequestor()
        {
            this.encryptionService = new EncryptionService();   
        }
        
        /// <summary>
        /// Performs a get request.
        /// </summary>
        /// <param name="requestUri">The request URI.</param>
        /// <param name="callback">The callback action.</param>
        /// <returns>An enumerator.</returns>
        public IEnumerator PerformGetRequest(
            string requestUri,
            Action<WWW> callback)
        {
            double timestamp = this.GetTimestamp();

            string hash = string.Concat(timestamp, WebRequestor.PrivateKey, WebRequestor.PublicKey);
            hash = this.encryptionService.MD5Hash(hash);

            string completeRequestUri = string.Concat(requestUri, 
                string.Format(
                    WebRequestor.AuthenticationQueryParamters, 
                    timestamp,
                    WebRequestor.PublicKey,
                    hash));
            
            WWW webRequest = new WWW(completeRequestUri);

            yield return webRequest;

            callback(webRequest);
        }

        /// <summary>
        /// Gets a timestamp.
        /// </summary>
        /// <returns>A timestamp.</returns>
        private double GetTimestamp()
        {
            TimeSpan timestamp = (DateTime.UtcNow - WebRequestor.EpochTime);

            return timestamp.TotalSeconds;
        }
    }
}
