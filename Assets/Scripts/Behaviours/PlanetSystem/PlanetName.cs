namespace MarvelUniverse.Behaviours.PlanetSystem
{
    using UnityEngine;

    /// <summary>
    /// The planet name.
    /// </summary>
    public class PlanetName : MonoBehaviour
    {
        /// <summary>
        /// The truncate limit.
        /// </summary>
        public int TruncateLimit = 20;

        /// <summary>
        /// The test mesh.
        /// </summary>
        private TextMesh textMesh;
       
        /// <summary>
        /// Set name.
        /// </summary>
        /// <param name="name">The name.</param>
        public void SetName(string name)
        {
            if (!string.IsNullOrEmpty(name) && 
                name.Length > this.TruncateLimit)
            {
                name = string.Format("{0}...", name.Trim().Substring(0, this.TruncateLimit));                
            }

            this.textMesh.text = name;
        }

        /// <summary>
        /// Handles the awake event.
        /// </summary>
        private void Awake()
        {
            this.textMesh = this.GetComponent<TextMesh>();
        }
    }
}
