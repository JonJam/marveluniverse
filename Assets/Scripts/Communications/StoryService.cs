namespace MarvelUniverse.Communications
{
    using Interfaces;
    using Serialization;
    using Web;

    /// <summary>
    /// A story service.
    /// </summary>
    public class StoryService : BaseService, IStoryService
    {
        /// <summary>
        /// The web requestor.
        /// </summary>
        private readonly IWebRequestor webRequestor;

        /// <summary>
        /// Initializes a new instance of the <see cref="StoryService"/> class.
        /// </summary>
        /// <param name="webRequestor">The web requestor.</param>
        /// <param name="jsonSerializer">The JSON serializer.</param>
        public StoryService(
            IWebRequestor webRequestor,
            IJsonSerializer jsonSerializer) : base(jsonSerializer)
        {
            this.webRequestor = webRequestor;
        }
    }
}
