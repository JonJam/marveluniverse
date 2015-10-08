namespace MarvelUniverse
{
    using System.Collections.Generic;
    using Communications;
    using Communications.Result;
    using Loading;
    using Model.Character;
    using UnityEngine;
    using UnityEngine.UI;

    /// <summary>
    /// Search.
    /// </summary>
    public class Search : MonoBehaviour
    {
        /// <summary>
        /// The character service.
        /// </summary>
        private ICharacterService characterService;

        /// <summary>
        /// The loading manager.
        /// </summary>
        private LoadingManager loadingManager;

        /// <summary>
        /// The canvas group.
        /// </summary>
        private CanvasGroup canvasGroup;

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
        
        private void Awake()
        {
            this.characterService = new CharacterService();

            this.canvasGroup = this.GetComponent<CanvasGroup>();

            GameObject gameController = GameObject.FindGameObjectWithTag(Tags.GameController);
            this.loadingManager = gameController.GetComponent<LoadingManager>();
        }

        /// <summary>
        /// Handles the search clicked event.
        /// </summary>
        private void OnSearchButtonClicked()
        {
            this.loadingManager.IncrementRunningOperationCount();

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
        private void OnSearchTextInputFieldValueChanged(string newValue)
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
        /// Handles the loading event.
        /// </summary>
        /// <param name="isLoading">A value indicating whether is loading.</param>
        private void HandleLoading(bool isLoading)
        {
            this.canvasGroup.interactable = !isLoading;
        }

        /// <summary>
        /// Handles the completion of the character search. 
        /// </summary>
        /// <param name="result">The result.</param>
        private void CharacterSearchCompleted(IResult<IList<Character>> result)
        {
            this.loadingManager.DecrementRunningOperationCount();
        }
    }
}
