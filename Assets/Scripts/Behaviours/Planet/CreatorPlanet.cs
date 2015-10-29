namespace MarvelUniverse.Behaviours.Planet
{
    using Model.Creator;

    /// <summary>
    /// The creator planet behaviour.
    /// </summary>
    public class CreatorPlanet : BasePlanet
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
            this.SetImage(this.creator.Thumbnail.Path, this.creator.Thumbnail.Extension);
        }
    }
}