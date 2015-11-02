namespace MarvelUniverse.UI.Screens.DetailsPanel
{
    using System.Linq;
    using Controls;
    using Model.Character;
    using UnityEngine.UI;

    /// <summary>
    /// The character details panel.
    /// </summary>
    public class CharacterDetailsPanel : BaseDetailsPanel
    {
        /// <summary>
        /// The name text.
        /// </summary>
        public Text Name;

        /// <summary>
        /// The description text.
        /// </summary>
        public Text Description;

        /// <summary>
        /// The URL list view.
        /// </summary>
        public ListView UrlListView;

        /// <summary>
        /// Hooks up this with the specified character.
        /// </summary>
        /// <param name="character">The character.</param>
        public void HookUp(Character character)
        {
            if (character != null)
            {
                this.SetTextToDisplay(this.Name, character.Name);
                this.SetTextToDisplay(this.Description, character.CleanDescription);
                this.SetListItems(this.UrlListView, character.Urls != null ? character.Urls.OrderBy(u => u.DisplayType) : null);
            }
        }      
    }
}
