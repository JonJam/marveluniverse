namespace MarvelUniverse.Behaviours.Planet
{
    using Model.Story;

    /// <summary>
    /// The story planet behaviour.
    /// </summary>
    public class StoryPlanet : BasePlanet
    {
        /// <summary>
        /// The story.
        /// </summary>
        private Story story;

        /// <summary>
        /// Hooks up the specified story to the planet.
        /// </summary>
        /// <param name="story">The story.</param>
        public void HookUp(Story story)
        {
            this.story = story;

            this.SetName(this.story.Title);
            this.SetImage(this.story.Thumbnail);
        }

        /// <summary>
        /// Display information for this planet.
        /// </summary>
        protected override void DisplayInformation()
        {
            this.ScreenManager.OpenInfoPanel(this.story);
        }
    }
}