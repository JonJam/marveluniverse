namespace MarvelUniverse.UI.Controls.MessageDialog
{
    using Events;
    using UnityEngine;
    using UnityEngine.UI;
    using Zenject;

    /// <summary>
    /// The message panel.
    /// </summary>
    public class MessagePanel : MonoBehaviour
    {
        /// <summary>
        /// The title.
        /// </summary>
        public Text Title;

        /// <summary>
        /// The message.
        /// </summary>
        public Text Message;

        /// <summary>
        /// The first button.
        /// </summary>
        public Button Button1;

        /// <summary>
        /// The second button.
        /// </summary>
        public Button Button2;

        /// <summary>
        /// The second button.
        /// </summary>
        public Button Button3;

        /// <summary>
        /// The first button text.
        /// </summary>
        public Text Button1Text;

        /// <summary>
        /// The second button text.
        /// </summary>
        public Text Button2Text;
        
        /// <summary>
        /// The third button text.
        /// </summary>
        public Text Button3Text;

        /// <summary>
        /// The event manager.
        /// </summary>
        private IEventManager eventManager;

        /// <summary>
        /// Injection initialization.
        /// </summary>
        /// <param name="eventManager">The event manager.</param>
        [PostInject]
        private void InjectionInitialize(
            IEventManager eventManager)
        {
            this.eventManager = eventManager;

            this.eventManager.GetEvent<ShowMessageDialogEvent>().AddListener(this.OnShowMessageDialog);
        }

        /// <summary>
        /// Handles the on destroy event.
        /// </summary>
        private void OnDestroy()
        {
            this.eventManager.GetEvent<ShowMessageDialogEvent>().RemoveListener(this.OnShowMessageDialog);
        }

        /// <summary>
        /// Handles the show message dialog event.
        /// </summary>
        /// <param name="details">The message dialog details.</param>
        private void OnShowMessageDialog(
            MessageDialogDetails details)
        {
            this.gameObject.SetActive(true);

            this.RestoreDefault();

            if (!string.IsNullOrEmpty(details.Title))
            {
                this.Title.gameObject.SetActive(true);
                this.Title.text = details.Title;
            }
                       
            this.Message.text = details.Message;

            this.SetupButton(
                this.Button1,
                this.Button1Text,
                details.Button1Details);

            this.SetupButton(
               this.Button2,
               this.Button2Text,
               details.Button2Details);
            
            this.SetupButton(
               this.Button3,
               this.Button3Text,
               details.Button3Details);
        }

        /// <summary>
        /// Restores this back to the default state.
        /// </summary>
        private void RestoreDefault()
        {
            this.Title.gameObject.SetActive(false);

            this.Button1.gameObject.SetActive(false);
            this.Button2.gameObject.SetActive(false);
            this.Button3.gameObject.SetActive(false);

            this.Button1.onClick.RemoveAllListeners();
            this.Button2.onClick.RemoveAllListeners();
            this.Button3.onClick.RemoveAllListeners();
        }

        /// <summary>
        /// Set up button.
        /// </summary>
        /// <param name="buttonToSetup">The button to setup.</param>
        /// <param name="buttonTextToSetup">The button text to setup.</param>
        /// <param name="buttonDetails">The button details.</param>
        private void SetupButton(
            Button buttonToSetup,
            Text buttonTextToSetup,
            EventButtonDetails buttonDetails)
        {
            if (buttonDetails != null)
            {
                buttonTextToSetup.text = buttonDetails.ButtonTitle;

                if (buttonDetails.ButtonAction != null)
                {
                    buttonToSetup.onClick.AddListener(buttonDetails.ButtonAction);
                }

                buttonToSetup.onClick.AddListener(this.ClosePanel);

                buttonToSetup.gameObject.SetActive(true);
            }
        }

        /// <summary>
        /// Closes the panel.
        /// </summary>
        private void ClosePanel()
        {
            this.gameObject.SetActive(false);
        }
    }
}
