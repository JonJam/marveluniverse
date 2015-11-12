namespace MarvelUniverse.ViewModels
{
    using System;
    using Events;
    using Model;
    using Screen;
    using UnityEngine.Events;

    /// <summary>
    /// The jump option view model.
    /// </summary>
    public class JumpOptionViewModel
    {
        /// <summary>
        /// The name.
        /// </summary>
        private readonly string name;

        /// <summary>
        /// The jump option click action.
        /// </summary>
        private readonly UnityAction jumpOptionClick;

        /// <summary>
        /// Initializes a new instance of the <see cref="JumpOptionViewModel"/> class.
        /// </summary>
        /// <param name="name">A name.</param>
        /// <param name="jumpOptionClick">The jump option click action.</param>
        public JumpOptionViewModel(
            string name,
            UnityAction jumpOptionClick)
        {
            this.name = name;
            this.jumpOptionClick = jumpOptionClick;
        }

        /// <summary>
        /// Gets the name.
        /// </summary>
        public string Name
        {
            get
            {
                return this.name;
            }
        }

        /// <summary>
        /// Gets the jump option click.
        /// </summary>
        public UnityAction JumpOptionClick
        {
            get
            {
                return this.jumpOptionClick;
            }
        }
    }
}
