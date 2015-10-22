namespace MarvelUniverse.Events
{
    using UnityEngine.Events;

    /// <summary>
    /// Interface for an event manager.
    /// </summary>
    public interface IEventManager
    {
        /// <summary>
        /// Gets an event matching the specified type.
        /// </summary>
        /// <typeparam name="TEventType">The event type.</typeparam>
        /// <returns>The specified event.</returns>
        TEventType GetEvent<TEventType>() where TEventType : UnityEventBase, new();
    }
}