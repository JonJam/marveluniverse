namespace MarvelUniverse.UI.Templates
{
    using MarvelUniverse.ViewModels;
    using UnityEngine;
    using UnityEngine.UI;

    /// <summary>
    /// The jump option item template.
    /// </summary>
    public class JumpOptionItemTemplate : MonoBehaviour, IItemTemplate<JumpOptionViewModel>
    {
        /// <summary>
        /// The name.
        /// </summary>
        public Text Name;

        /// <summary>
        /// The button.
        /// </summary>
        public Button Button;
        
        /// <summary>
        /// Hook up item to template.
        /// </summary>
        /// <param name="item">The item to display.</param>
        public void Hookup(JumpOptionViewModel item)
        {
            this.Name.text = item.Name;
            this.Button.onClick.AddListener(item.JumpOptionClick);            
        }        
    }
}
