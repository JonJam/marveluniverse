namespace MarvelUniverse
{
    using System.Collections.Generic;
    using Communications;
    using Communications.Result;
    using Model.Character;
    using UnityEngine;
    using UnityEngine.UI;

    /// <summary>
    /// Search.
    /// </summary>
    public class Search : MonoBehaviour
    {
        /// <summary>
        /// The search button.
        /// </summary>
        public Button SearchButton;

        /// <summary>
        /// The search type dropdown.
        /// </summary>
        public Dropdown SearchTypeDropdown;

        /// <summary>
        /// The search text input field.
        /// </summary>
        public InputField SearchTextInputField;

        /// <summary>
        /// The character service.
        /// </summary>
        private ICharacterService characterService;
        
        /// <summary>
        /// Handles the search clicked event.
        /// </summary>
        public void OnSearchButtonClicked()
        {
            string searchTerms = this.SearchTextInputField.text;
            string selectedSearchType = this.SearchTypeDropdown.options[this.SearchTypeDropdown.value].text;

            switch (selectedSearchType)
            {
                case "Character":
                    this.StartCoroutine(this.characterService.Search(searchTerms, CharacterSearchCompleted));
                    break;
                case "Comic":
                    break;
                case "Creator":
                    break;
                case "Event":
                    break;
                case "Series":
                    break;
                case "Story":
                    break;
            }
        }

        /// <summary>
        /// Handles the search text input field value changed event.
        /// </summary>
        /// <param name="newValue">The new value.</param>
        public void OnSearchTextInputFieldValueChanged(string newValue)
        {
            newValue = newValue.Trim();

            if (!string.IsNullOrEmpty(newValue))
            {
                this.SearchButton.interactable = true;
            }
            else
            {
                this.SearchButton.interactable = false;
            }
        }

        /// <summary>
        /// Handles the start event.
        /// </summary>
        private void Start()
        {
            this.characterService = new CharacterService();
        }

        /// <summary>
        /// Handles the completion of the character search. 
        /// </summary>
        /// <param name="result">The result.</param>
        private void CharacterSearchCompleted(IResult<IList<Character>> result)
        {
        }
    }
}
