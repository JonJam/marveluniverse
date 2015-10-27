namespace MarvelUniverse.Communications
{
    using System;
    using System.Collections;
    using Interfaces;
    using MarvelUniverse.Communications.Result;
    using MarvelUniverse.Communications.Web;
    using Model.Image;
    using UnityEngine;

    /// <summary>
    /// The image service.
    /// </summary>
    public class ImageService : IImageService
    {
        /// <summary>
        /// The web requestor.
        /// </summary>
        private readonly IWebRequestor webRequestor;

        /// <summary>
        /// Initializes a new instance of the <see cref="ImageService"/> class.
        /// </summary>
        /// <param name="webRequestor">The web requestor.</param>
        public ImageService(IWebRequestor webRequestor)
        {
            this.webRequestor = webRequestor;
        }

        /// <summary>
        /// Download image.
        /// </summary>
        /// <param name="imagePath">The image path.</param>
        /// <param name="imageExtension">The image extension.</param>
        /// <param name="imageSize">The image size.</param>
        /// <param name="callback">The callback.</param>
        /// <returns>A coroutine.</returns>
        public IEnumerator DownloadImage(
            string imagePath,
            string imageExtension,
            ImageSize imageSize,
            Action<IResult<Texture2D>> callback)
        {
            string imageSizeURIPart = this.GetImageSize(imageSize);
            string requestUri = string.Concat(imagePath, "/", imageSizeURIPart, ".", imageExtension);

            WWW request = this.webRequestor.PerformGetRequest(requestUri);

            yield return request;
            
            IResult<Texture2D> result = null;

            if (request != null &&
                string.IsNullOrEmpty(request.error))
            {
                result = new Result<Texture2D>(request.texture);
            }
            else
            {
                result = new Result<Texture2D>(request.error);
            }

            callback(result);
        }

        /// <summary>
        /// Gets the image size URI part for the specified image size.
        /// </summary>
        /// <param name="imageSize">The image size.</param>
        /// <returns>The image size URI part for the specified image size.</returns>
        private string GetImageSize(ImageSize imageSize)
        {
            string imageSizeUriPart = null;

            switch (imageSize)
            {
                case ImageSize.PortaitSmall:
                    imageSizeUriPart = "portrait_small";
                    break;
                case ImageSize.PortaitMedium:
                    imageSizeUriPart = "portrait_medium";
                    break;
                case ImageSize.PortaitXLarge:
                    imageSizeUriPart = "portrait_xlarge";
                    break;
                case ImageSize.PortaitFantastic:
                    imageSizeUriPart = "portrait_fantastic";
                    break;
                case ImageSize.PortaitUncanny:
                    imageSizeUriPart = "portrait_uncanny";
                    break;
                case ImageSize.PortaitIncredible:
                    imageSizeUriPart = "portrait_incredible";
                    break;
                case ImageSize.StandardSmall:
                    imageSizeUriPart = "standard_small";
                    break;
                case ImageSize.StandardMedium:
                    imageSizeUriPart = "standard_medium";
                    break;
                case ImageSize.StandardLarge:
                    imageSizeUriPart = "standard_large";
                    break;
                case ImageSize.StandardXLarge:
                    imageSizeUriPart = "standard_xlarge";
                    break;
                case ImageSize.StandardFantastic:
                    imageSizeUriPart = "standard_fantastic";
                    break;
                case ImageSize.StandardAmazing:
                    imageSizeUriPart = "standard_amazing";
                    break;
                case ImageSize.LandscapeSmall:
                    imageSizeUriPart = "landscape_small";
                    break;
                case ImageSize.LandscapeMedium:
                    imageSizeUriPart = "landscape_medium";
                    break;
                case ImageSize.LandscapeLarge:
                    imageSizeUriPart = "landscape_large";
                    break;
                case ImageSize.LandscapeXLarge:
                    imageSizeUriPart = "landscape_xlarge";
                    break;
                case ImageSize.LandscapeAmazing:
                    imageSizeUriPart = "landscape_anazing";
                    break;
                case ImageSize.LandscapeIncredible:
                    imageSizeUriPart = "landscape_incredible";
                    break;
                case ImageSize.Detail:
                    imageSizeUriPart = "detail";
                    break;
                case ImageSize.FullSize:
                    imageSizeUriPart = "full-size image";
                    break;
            }

            return imageSizeUriPart;
        }
    }
}
