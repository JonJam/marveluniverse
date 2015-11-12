namespace MarvelUniverse.Communications.Interfaces
{
    using System;
    using System.Collections;
    using MarvelUniverse.Communications.Result;
    using MarvelUniverse.Model.Story;

    /// <summary>
    /// Interface for a story service.
    /// </summary>
    public interface IStoryService
    {
        /// <summary>
        /// Get story.
        /// </summary>
        /// <param name="storyUri">The story URI.</param>
        /// <param name="callback">The callback.</param>
        /// <returns>A coroutine.</returns>
        IEnumerator GetStory(
            string storyUri,
            Action<IResult<Story>> callback);
    }
}
