namespace MarvelUniverse.UI
{
    using Controls;
    using Model.Character;
    using UnityEngine;
    using UnityEngine.UI;
    using System.Linq;

    public class CharacterDetailsPanel : MonoBehaviour
    {
        public Text Name;

        public Text Description;

        public ListView UrlListView;

        public void HookUp(Character character)
        {
            if (character != null)
            {
                this.Name.text = character.Name;
                this.Description.text = character.CleanDescription;

                if (character.Urls != null &&
                    character.Urls.Count() > 0)
                {
                    this.UrlListView.gameObject.SetActive(true);

                    this.UrlListView.DisplayItems(character.Urls.OrderBy(u => u.DisplayText));
                }
                else
                {
                    this.UrlListView.gameObject.SetActive(false);
                }
            }
        }
    }
}
