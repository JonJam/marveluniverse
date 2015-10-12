namespace MarvelUniverse.UI
{
    using System.Collections.Generic;
    using System.Linq;
    using Communications.Interfaces;
    using Communications.Result;
    using Loading;
    using ViewModel;
    using Model.Character;
    using UnityEngine;
    using UnityEngine.UI;
    using Zenject;

    /// <summary>
    /// Search.
    /// </summary>
    public class SearchPanel : MonoBehaviour
    {
        /// <summary>
        /// The character service.
        /// </summary>
        private ICharacterService characterService;

        /// <summary>
        /// The loading manager.
        /// </summary>
        private ILoadingManager loadingManager;

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

        /// <summary>
        /// The search results panel.
        /// </summary>
        public SearchResultsPanel searchResultsPanel;

        /// <summary>
        /// Injection initialization.
        /// </summary>
        /// <param name="characterService">The character service.</param>
        /// <param name="loadingManager">The loading manager.</param>
        [PostInject]
        private void InjectionInitialize(
            ICharacterService characterService,
            ILoadingManager loadingManager)
        {
            this.characterService = characterService;
            this.loadingManager = loadingManager;

            this.loadingManager.Loading.AddListener(this.HandleLoading);
        }

        /// <summary>
        /// Handles the awake event.
        /// </summary>
        private void Awake()
        {
            this.canvasGroup = this.GetComponent<CanvasGroup>();
        }

        /// <summary>
        /// Handles the on destroy event.
        /// </summary>
        private void OnDestroy()
        {
            this.loadingManager.Loading.RemoveListener(this.HandleLoading);
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
            if (result.IsSuccess)
            {
                this.searchResultsPanel.DisplaySearchResults(result.Data.Select(c => new SearchResultViewModel(c.Name, c.Thumbnail.Extension, c.Thumbnail.Path)).ToList());
            }
            else
            {
                // TODO HANDLE Failure
            }

            this.loadingManager.DecrementRunningOperationCount();
        }
    }
}
