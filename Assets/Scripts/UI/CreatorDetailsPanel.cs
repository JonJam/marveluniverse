namespace MarvelUniverse.UI
{
    using Controls;
    using Model.Creator;
    using UnityEngine;
    using UnityEngine.UI;
    using System.Linq;

    public class CreatorDetailsPanel : MonoBehaviour
    {
        public Text FullName;

        public ListView UrlListView;

        public void HookUp(Creator creator)
        {
            if (creator != null)
            {
                this.FullName.text = creator.FullName;

                if (creator.Urls != null &&
                    creator.Urls.Count() > 0)
                {
                    this.UrlListView.gameObject.SetActive(true);

                    this.UrlListView.DisplayItems(creator.Urls.OrderBy(u => u.DisplayText));
                }
                else
                {
                    this.UrlListView.gameObject.SetActive(false);
                }
            }
        }
    }
}
