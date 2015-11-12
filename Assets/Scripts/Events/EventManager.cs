namespace MarvelUniverse.Events
{
    using System;
    using System.Collections.Generic;
    using UnityEngine.Events;

    /// <summary>
    /// The event manager. Based upon <see cref="https://github.com/PrismLibrary/Prism/blob/master/Source/Prism/Events/EventAggregator.cs"/>
    /// </summary>
    public class EventManager : IEventManager
    {
        /// <summary>
        /// The events.
        /// </summary>
        private readonly Dictionary<Type, UnityEventBase> events;

        /// <summary>
        /// Initializes a new instance of the <see cref="EventManager"/> class.
        /// </summary>
        public EventManager()
        {
            this.events = new Dictionary<Type, UnityEventBase>();
        }

        /// <summary>
        /// Gets an event matching the specified type.
        /// </summary>
        /// <typeparam name="TEventType">The event type.</typeparam>
        /// <returns>The specified event.</returns>
        public TEventType GetEvent<TEventType>() where TEventType : UnityEventBase, new()
        {
            lock (this.events)
            {
                UnityEventBase existingEvent = null;
                TEventType eventToReturn = null;

                if (!this.events.TryGetValue(typeof(TEventType), out existingEvent))
                {
                    TEventType newEvent = new TEventType();
                    this.events[typeof(TEventType)] = newEvent;

                    eventToReturn = newEvent;
                }
                else
                {
                    eventToReturn = (TEventType)existingEvent;
                }

                return eventToReturn;
            }
        }
    }
}
