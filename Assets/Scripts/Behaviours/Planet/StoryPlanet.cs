namespace MarvelUniverse.Behaviours.Planet
{
    using Model.Story;

    /// <summary>
    /// The story planet behaviour.
    /// </summary>
    public class StoryPlanet: BasePlanet
    {
        /// <summary>
        /// The story.
        /// </summary>
        private Story story;

        /// <summary>
        /// Hooks up the specified story to the planet.
        /// </summary>
        /// <param name="comicEvent">The story.</param>
        public void HookUp(Story story)
        {
            this.story = story;

            this.SetName(this.story.Title);
            this.SetImage(this.story.Thumbnail.Path, this.story.Thumbnail.Extension);
        }
    }
}