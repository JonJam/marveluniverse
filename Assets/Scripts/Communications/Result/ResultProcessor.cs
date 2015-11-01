namespace MarvelUniverse.Communications.Result
{
    using System;
    using Events;
    using UI.Controls.MessageDialog;
    using UnityEngine;

    /// <summary>
    /// Result processor.
    /// </summary>
    public class ResultProcessor : IResultProcessor
    {
        /// <summary>
        /// The WWW object no network error.
        /// </summary>
        private const string WWWNoNetworkError = "Host not found";

        /// <summary>
        /// The WWW object unauthorized error.
        /// </summary>
        private const string WWWUnauthorizedError = "401 Unauthorized\r";

        /// <summary>
        /// The event manager.
        /// </summary>
        private readonly IEventManager eventManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="ResultProcessor"/> class.
        /// </summary>
        /// <param name="eventManager">The event manager.</param>
        public ResultProcessor(IEventManager eventManager)
        {
            this.eventManager = eventManager;
        }

        /// <summary>
        /// Processes the result.
        /// </summary>
        /// <typeparam name="T">Type of the data contained in the result.</typeparam>
        /// <param name="result">The result.</param>
        /// <returns>Flag indicating whether successfully processed the result.</returns>
        public bool ProcessResult<T>(IResult<T> result)
        {
            bool isSuccess = result != null ? result.IsSuccess : false;

            if (result != null &&
                !result.IsSuccess)
            {
                this.HandleError(result.Error);
            }

            return isSuccess;
        }

        /// <summary>
        /// Handles the error.
        /// </summary>
        /// <param name="error">The error.</param>
        private void HandleError(string error)
        {
            if (error == null)
            {
                throw new ArgumentNullException("error should not be null");
            }
            else if (error.Contains(ResultProcessor.WWWNoNetworkError))
            {
                MessageDialogDetails noNetworkMessageDetails = new MessageDialogDetails(
                    "No network connection. Please connect to the Internet and try again.",
                    new EventButtonDetails("OK", null));

                this.eventManager.GetEvent<ShowMessageDialogEvent>().Invoke(noNetworkMessageDetails);
            }
            else if (error.Contains(ResultProcessor.WWWUnauthorizedError) &&
                Debug.isDebugBuild)
            {
                MessageDialogDetails notAuthorizedMessageDetails = new MessageDialogDetails(
                    "Please check the access tokens in the Web Requestor class.",
                    new EventButtonDetails("OK", null));

                this.eventManager.GetEvent<ShowMessageDialogEvent>().Invoke(notAuthorizedMessageDetails);
            }
            else
            {
                throw new NotImplementedException();
            }
        }
    }
}
