namespace MarvelUniverse.Screen
{
    using UnityEngine;

    /// <summary>
    /// Interface for a screen manager.
    /// </summary>
    public interface IScreenManager
    {
        /// <summary>
        /// Open the specified panel, closing the previous and setting the new selected element.
        /// </summary>
        /// <param name="newScreen">The new screen.</param>
        void OpenPanel(GameObject newScreen);

        /// <summary>
        /// Goes back to the previous screen.
        /// </summary>
        void GoBack();
    }
}