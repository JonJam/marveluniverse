namespace MarvelUniverse.UI.Screens.DetailsPanel
{
    using Model.Story;
    using UnityEngine.UI;

    /// <summary>
    /// The story details panel.
    /// </summary>
    public class StoryDetailsPanel : BaseDetailsPanel
    {
        /// <summary>
        /// The title text.
        /// </summary>
        public Text Title;

        /// <summary>
        /// The description text.
        /// </summary>
        public Text Description;

        /// <summary>
        /// The type text.
        /// </summary>
        public Text Type;

        /// <summary>
        /// Hooks up this with the specified story.
        /// </summary>
        /// <param name="story">The story.</param>
        public void HookUp(Story story)
        {
            if (story != null)
            {
                this.SetTextToDisplay(this.Title, story.Title);
                this.SetTextToDisplay(this.Description, story.CleanDescription);
                this.SetTextToDisplay(this.Type, story.DisplayType, this.Type.transform.parent.gameObject);
            }
        }
    }
}
