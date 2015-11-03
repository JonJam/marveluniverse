namespace MarvelUniverse.UI.Screens
{
    using UnityEngine;

    /// <summary>
    /// Interface for a screen.
    /// </summary>
    public interface IScreen
    {
        /// <summary>
        /// Gets the game object.
        /// </summary>
        GameObject GameObject { get; }
        
        /// <summary>
        /// Called upon screen open.
        /// </summary>
        /// <param name="openParameter">The open parameter.</param>
        void OnOpen(object openParameter);

        /// <summary>
        /// Called upon the screen being closed.
        /// </summary>
        void OnClosing();
    }
}