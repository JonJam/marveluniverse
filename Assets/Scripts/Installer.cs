namespace MarvelUniverse
{
    using Behaviours.Planet;
    using Communications.Interfaces;
    using Communications.Result;
    using Events;
    using MarvelUniverse.Communications;
    using MarvelUniverse.Communications.Encryption;
    using MarvelUniverse.Communications.Serialization;
    using MarvelUniverse.Communications.Web;
    using MarvelUniverse.Loading;
    using Screen;
    using Spawner;
    using UnityEngine;
    using ViewModels;
    using Zenject;

    /// <summary>
    /// The installer.
    /// </summary>
    public class Installer : Zenject.MonoInstaller
    {
        /// <summary>
        /// The scene settings.
        /// </summary>
        public SceneSettings SceneSettings;

        /// <summary>
        /// Install bindings.
        /// </summary>
        public override void InstallBindings()
        {
            this.InstallCommunicationBindings();

            this.InstallInfrastructureBindings();

            this.InstallViewModelBindings();

            this.InstallUIBindings();

            this.InstallGameObjectBindings();
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
            this.Container.Bind<IStoryService>().ToSingle<StoryService>();

            this.Container.Bind<IImageService>().ToSingle<ImageService>();
        }

        /// <summary>
        /// Install infrastructure bindings.
        /// </summary>
        private void InstallInfrastructureBindings()
        {
            this.Container.Bind<IEventManager>().ToSingle<EventManager>();
            this.Container.Bind<IPlanetSystemSpawner>().ToInstance(new PlanetSystemSpawner(
                this.Container.Resolve<IInstantiator>(),
                this.SceneSettings.InitialPlanetSystemPosition,
                this.SceneSettings.CharacterPlanetSystemPrefab,
                this.SceneSettings.ComicPlanetSystemPrefab,
                this.SceneSettings.CreatorPlanetSystemPrefab,
                this.SceneSettings.EventPlanetSystemPrefab,
                this.SceneSettings.SeriesPlanetSystemPrefab,
                this.SceneSettings.StoryPlanetSystemPrefab,
                this.SceneSettings.SpawmSphereRadius,
                this.SceneSettings.PlanetSystemSize,
                this.SceneSettings.PlanetSize,
                this.SceneSettings.MainCamera));
        }

        /// <summary>
        /// Install UI bindings.
        /// </summary>
        private void InstallUIBindings()
        {
            this.Container.Bind<ILoadingManager>().ToSingle<LoadingManager>();

            this.Container.Bind<IScreenManager>().ToInstance(new ScreenManager(
                this.SceneSettings.SearchPanel,
                this.SceneSettings.SearchResultsPanel,
                this.SceneSettings.InfoPanel,
                this.SceneSettings.ExplorerPanel,
                this.SceneSettings.JumpGatePanel));                
        }

        /// <summary>
        /// Install view model bindings.
        /// </summary>
        private void InstallViewModelBindings()
        {
            this.Container.Bind<SearchViewModel>().ToSingle();
        }

        /// <summary>
        /// Install game object bindings.
        /// </summary>
        private void InstallGameObjectBindings()
        {
            this.Container.Bind<Camera>().ToInstance(this.SceneSettings.MainCamera);
        }
    }
}
