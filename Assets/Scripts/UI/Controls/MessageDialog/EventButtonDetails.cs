namespace MarvelUniverse.UI.Controls.MessageDialog
{
    using UnityEngine.Events;

    /// <summary>
    /// The event button details.
    /// </summary>
    public class EventButtonDetails
    {
        /// <summary>
        /// The button title.
        /// </summary>
        private readonly string buttonTitle;

        /// <summary>
        /// The button action.
        /// </summary>
        private readonly UnityAction buttonAction;

        /// <summary>
        /// Initializes a new instance of the <see cref="EventButtonDetails"/> class.
        /// </summary>
        /// <param name="buttonTitle">The button title.</param>
        public EventButtonDetails(
            string buttonTitle) : this(buttonTitle, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EventButtonDetails"/> class.
        /// </summary>
        /// <param name="buttonTitle">The button title.</param>
        /// <param name="buttonAction">The button action.</param>
        public EventButtonDetails(
            string buttonTitle,
            UnityAction buttonAction)
        {
            this.buttonTitle = buttonTitle;
            this.buttonAction = buttonAction;
        }

        /// <summary>
        /// Gets the button title.
        /// </summary>
        public string ButtonTitle
        {
            get
            {
                return this.buttonTitle;
            }
        }

        /// <summary>
        /// Gets the button action.
        /// </summary>
        public UnityAction ButtonAction
        {
            get
            {
                return this.buttonAction;
            }
        }
    }
}
