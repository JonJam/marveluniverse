namespace MarvelUniverse.UI.Controls
{
    using UnityEngine;

    /// <summary>
    /// Bring to front behaviour.
    /// </summary>
    public class BringToFront : MonoBehaviour
    {
        /// <summary>
        /// Handles the on enable event.
        /// </summary>
        private void OnEnable()
        {
            this.transform.SetAsLastSibling();
        }
    }
}