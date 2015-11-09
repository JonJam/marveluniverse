namespace MarvelUniverse.Behaviours.Satellite
{
    using Communications.Interfaces;
    using Communications.Result;
    using Loading;
    using Zenject;

    /// <summary>
    /// Comics satellite behaviour.
    /// </summary>
    public class ComicsSatellite : BaseSatellite
    {        
        /// <summary>
        /// The comic service.
        /// </summary>
        private IComicService comicService;

        /// <summary>
        /// Injection initialization.
        /// </summary>
        /// <param name="comicService">The comic service.</param>
        [PostInject]
        private void InjectionInitialize(
            IComicService comicService)
        {
            this.comicService = comicService;
        }
    }
}
