namespace MarvelUniverse.Behaviours.PlanetSystem
{
    using Model.Creator;

    /// <summary>
    /// The creator planet system behaviour.
    /// </summary>
    public class CreatorPlanetSystem : BasePlanetSystem
    {
        /// <summary>
        /// The creator.
        /// </summary>
        private Creator creator;

        /// <summary>
        /// Hooks up the specified creator to the planet.
        /// </summary>
        /// <param name="creator">The creator.</param>
        public void HookUp(Creator creator)
        {
            this.creator = creator;

            this.SetName(this.creator.FullName);
            this.SetImage(this.creator.Thumbnail);
        }

        /// <summary>
        /// Display information for this planet system.
        /// </summary>
        protected override void DisplayInformation()
        {
            this.ScreenManager.OpenInfoPanel(this.creator);
        }
    }
}