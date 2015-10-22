namespace MarvelUniverse.UI.Controls.MessageDialog
{
    /// <summary>
    /// The message dialog details class.
    /// </summary>
    public class MessageDialogDetails
    {
        /// <summary>
        /// The title.
        /// </summary>
        private readonly string title;

        /// <summary>
        /// The message.
        /// </summary>
        private readonly string message;

        /// <summary>
        /// The button 1 details.
        /// </summary>
        private readonly EventButtonDetails button1Details;

        /// <summary>
        /// The button 2 details.
        /// </summary>
        private readonly EventButtonDetails button2Details;

        /// <summary>
        /// The button 3 details.
        /// </summary>
        private readonly EventButtonDetails button3Details;

        /// <summary>
        /// Initializes a new instance of the <see cref="MessageDialogDetails"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="button1Details">The button 1 details.</param>
        /// <param name="button2Details">The button 2 details.</param>
        /// <param name="button3Details">The button 3 details.</param>
        public MessageDialogDetails(
            string message,
            EventButtonDetails button1Details,
            EventButtonDetails button2Details = null,
            EventButtonDetails button3Details = null) : this(null, message, button1Details, button2Details, button3Details)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MessageDialogDetails"/> class.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <param name="message">The message.</param>
        /// <param name="button1Details">The button 1 details.</param>
        /// <param name="button2Details">The button 2 details.</param>
        /// <param name="button3Details">The button 3 details.</param>
        public MessageDialogDetails(
            string title,
            string message,
            EventButtonDetails button1Details,
            EventButtonDetails button2Details,
            EventButtonDetails button3Details)
        {
            this.title = title;
            this.message = message;
            this.button1Details = button1Details;
            this.button2Details = button2Details;
            this.button3Details = button3Details;
        }

        /// <summary>
        /// Gets the title.
        /// </summary>
        public string Title
        {
            get
            {
                return this.title;
            }
        }
        
        /// <summary>
        /// Gets the message.
        /// </summary>
        public string Message
        {
            get
            {
                return this.message;
            }
        }
        
        /// <summary>
        /// Gets the button 1 details.
        /// </summary>
        public EventButtonDetails Button1Details
        {
            get
            {
                return this.button1Details;
            }
        }

        /// <summary>
        /// Gets the button 2 details.
        /// </summary>
        public EventButtonDetails Button2Details
        {
            get
            {
                return this.button2Details;
            }
        }

        /// <summary>
        /// Gets the button 3 details.
        /// </summary>
        public EventButtonDetails Button3Details
        {
            get
            {
                return this.button3Details;
            }
        }
    }
}
