namespace MarvelUniverse.UI
{
    using Controls;
    using UnityEngine;
    using UnityEngine.UI;
    using System.Linq;

    public class EventDetailsPanel : MonoBehaviour
    {
        public Text Title;

        public Text Description;

        public Text StartDate;

        public Text EndDate;

        public ListView UrlListView;

        public void HookUp(Model.Event.Event comicEvent)
        {
            if (comicEvent != null)
            {
                this.Title.text = comicEvent.Title;
                this.Description.text = comicEvent.CleanDescription;
                this.StartDate.text = comicEvent.DisplayStartDate;
                this.EndDate.text = comicEvent.DisplayEndDate;

                if (comicEvent.Urls != null &&
                    comicEvent.Urls.Count() > 0)
                {
                    this.UrlListView.gameObject.SetActive(true);

                    this.UrlListView.DisplayItems(comicEvent.Urls.OrderBy(u => u.DisplayText));
                }
                else
                {
                    this.UrlListView.gameObject.SetActive(false);
                }
            }
        }
    }
}
