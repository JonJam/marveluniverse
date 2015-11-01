namespace MarvelUniverse.UI
{
    using Model.Character;
    using UnityEngine;
    using UnityEngine.UI;

    public class CharacterDetailsPanel : MonoBehaviour
    {
        public Text Name;

        public Text Description;

        public void HookUp(Character character)
        {
            if (character != null)
            {
                this.Name.text = character.Name;
                this.Description.text = character.CleanDescription;
            }
        }
    }
}
