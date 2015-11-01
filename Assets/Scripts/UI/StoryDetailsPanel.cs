namespace MarvelUniverse.UI
{
    using Controls;
    using UnityEngine;
    using UnityEngine.UI;
    using System.Linq;
    using Model.Story;

    public class StoryDetailsPanel : MonoBehaviour
    {
        public Text Title;

        public Text Description;

        public Text Type;

        public void HookUp(Story story)
        {
            if (story != null)
            {
                this.Title.text = story.Title;
                this.Description.text = story.CleanDescription;
                this.Type.text = story.DisplayType;
            }
        }
    }
}
