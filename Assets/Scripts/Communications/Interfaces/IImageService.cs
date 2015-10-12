namespace MarvelUniverse.Communications.Interfaces
{
    using System;
    using System.Collections;
    using MarvelUniverse.Communications.Result;
    using Model.Image;
    using UnityEngine;

    /// <summary>
    /// Interface for an image service.
    /// </summary>
    public interface IImageService
    {
        /// <summary>
        /// Download image.
        /// </summary>
        /// <param name="imagePath">The image path.</param>
        /// <param name="imageExtension">The image extension.</param>
        /// <param name="imageSize">The image size.</param>
        /// <param name="callback">The callback.</param>
        /// <returns>A coroutine.</returns>
        IEnumerator DownloadImage(
           string imagePath,
           string imageExtension,
           ImageSize imageSize,
           Action<IResult<Texture2D>> callback);
    }
}
