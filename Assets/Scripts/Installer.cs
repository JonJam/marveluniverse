namespace MarvelUniverse
{
    using Communications.Interfaces;
    using MarvelUniverse.Communications;
    using MarvelUniverse.Communications.Encryption;
    using MarvelUniverse.Communications.Serialization;
    using MarvelUniverse.Communications.Web;
    using MarvelUniverse.Loading;
    using Screen;

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

            this.InstallUIBindings();
        }

        /// <summary>
        /// Install communication bindings.
        /// </summary>
        private void InstallCommunicationBindings()
        {
            this.Container.Bind<IEncryptionService>().ToSingle<EncryptionService>();
            this.Container.Bind<IJsonSerializer>().ToSingle<JsonSerializer>();
            this.Container.Bind<IWebRequestor>().ToSingle<WebRequestor>();

            this.Container.Bind<ICharacterService>().ToSingle<CharacterService>();
            this.Container.Bind<IImageService>().ToSingle<ImageService>();
        }

        /// <summary>
        /// Install UI bindings.
        /// </summary>
        private void InstallUIBindings()
        {
            this.Container.Bind<ILoadingManager>().ToSingle<LoadingManager>();
            this.Container.Bind<IScreenManager>().ToSingle<ScreenManager>();
        }
    }
}
