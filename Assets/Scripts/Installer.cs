namespace MarvelUniverse
{
    using Communications.Interfaces;
    using Communications.Result;
    using Events;
    using MarvelUniverse.Communications;
    using MarvelUniverse.Communications.Encryption;
    using MarvelUniverse.Communications.Serialization;
    using MarvelUniverse.Communications.Web;
    using MarvelUniverse.Loading;
    using Screen;
    using ViewModels;

    /// <summary>
    /// The installer.
    /// </summary>
    public class Installer : Zenject.MonoInstaller
    {
        /// <summary>
        /// Install bindings.
        /// </summary>
        public override void InstallBindings()
        {
            this.InstallCommunicationBindings();

            this.InstallInfrastructureBindings();

            this.InstallUIBindings();

            this.InstallViewModels();            
        }

        /// <summary>
        /// Install communication bindings.
        /// </summary>
        private void InstallCommunicationBindings()
        {
            this.Container.Bind<IEncryptionService>().ToSingle<EncryptionService>();
            this.Container.Bind<IJsonSerializer>().ToSingle<JsonSerializer>();
            this.Container.Bind<IWebRequestor>().ToSingle<WebRequestor>();
            
            this.Container.Bind<IResultProcessor>().ToSingle<ResultProcessor>();

            this.Container.Bind<ICharacterService>().ToSingle<CharacterService>();
            this.Container.Bind<IComicService>().ToSingle<ComicService>();
            this.Container.Bind<ICreatorService>().ToSingle<CreatorService>();
            this.Container.Bind<ISeriesService>().ToSingle<SeriesService>();
            this.Container.Bind<IEventService>().ToSingle<EventService>();

            this.Container.Bind<IImageService>().ToSingle<ImageService>();
        }

        /// <summary>
        /// Install infrastructure bindings.
        /// </summary>
        private void InstallInfrastructureBindings()
        {
            this.Container.Bind<IEventManager>().ToSingle<EventManager>();
        }

        /// <summary>
        /// Install UI bindings.
        /// </summary>
        private void InstallUIBindings()
        {
            this.Container.Bind<ILoadingManager>().ToSingle<LoadingManager>();
            this.Container.Bind<IScreenManager>().ToSingle<ScreenManager>();
        }

        /// <summary>
        /// Install view models.
        /// </summary>
        private void InstallViewModels()
        {
            this.Container.Bind<SearchViewModel>().ToSingle();
        }
    }
}
