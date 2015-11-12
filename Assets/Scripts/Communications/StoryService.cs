namespace MarvelUniverse.Communications
{
    using System;
    using System.Collections;
    using Interfaces;
    using Model.Story;
    using Result;
    using Serialization;
    using UnityEngine;
    using Web;

    /// <summary>
    /// A story service.
    /// </summary>
    public class StoryService : BaseService, IStoryService
    {
        /// <summary>
        /// The web requestor.
        /// </summary>
        private readonly IWebRequestor webRequestor;

        /// <summary>
        /// Initializes a new instance of the <see cref="StoryService"/> class.
        /// </summary>
        /// <param name="webRequestor">The web requestor.</param>
        /// <param name="jsonSerializer">The JSON serializer.</param>
        public StoryService(
            IWebRequestor webRequestor,
            IJsonSerializer jsonSerializer) : base(jsonSerializer)
        {
            this.webRequestor = webRequestor;
        }

        /// <summary>
        /// Get story.
        /// </summary>
        /// <param name="storyUri">The story URI.</param>
        /// <param name="callback">The callback.</param>
        /// <returns>A coroutine.</returns>
        public IEnumerator GetStory(
            string storyUri,
            Action<IResult<Story>> callback)
        {
            WWW request = this.webRequestor.PerformAuthorizedGetRequest(storyUri);

            yield return request;

            IResult<Story> result = null;

            if (request != null &&
                string.IsNullOrEmpty(request.error))
            {
                result = this.CreateSuccessfulResult<Story>(request.text);
            }
            else
            {
                result = new Result<Story>(request.error);
            }

            callback(result);
        }
    }
}
