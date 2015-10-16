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
    using Screen;

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
        /// The screen manager.
        /// </summary>
        private IScreenManager screenManager;

        /// <summary>
        /// The search view model.
        /// </summary>
        private SearchViewModel searchViewModel;

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
        /// <param name="screenManager">The screen manaager.</param>
        /// <param name="searchViewModel">The search view model.</param>
        [PostInject]
        private void InjectionInitialize(
            ICharacterService characterService,
            ILoadingManager loadingManager,
            IScreenManager screenManager,
            SearchViewModel searchViewModel)
        {
            this.characterService = characterService;
            this.loadingManager = loadingManager;
            this.screenManager = screenManager;
            this.searchViewModel = searchViewModel;

            this.loadingManager.Loading.AddListener(this.HandleLoading);
        }

        /// <summary>
        /// Handles the search clicked event.
        /// </summary>
        public void OnSearchButtonClicked()
        {
            this.loadingManager.IncrementRunningOperationCount();

            this.searchViewModel.SearchTerms = this.SearchTextInputField.text;
            this.searchViewModel.SearchTypeIndex = this.SearchTypeDropdown.value;

            string selectedSearchType = this.SearchTypeDropdown.options[this.searchViewModel.SearchTypeIndex].text;

            switch (selectedSearchType)
            {
                case "Character":
                    this.StartCoroutine(this.characterService.Search(this.searchViewModel.SearchTerms, CharacterSearchCompleted));
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
        public void OnSearchTextInputFieldValueChanged()
        {
            this.searchViewModel.SearchTerms = this.SearchTextInputField.text.Trim();

            if (!string.IsNullOrEmpty(this.searchViewModel.SearchTerms))
            {
                this.SearchButton.interactable = true;
            }
            else
            {
                this.SearchButton.interactable = false;
            }
        }

        /// <summary>
        /// Handles the search type dropdown value changed event.
        /// </summary>
        public void OnSearchTypeDropdownValueChanged()
        {
            this.searchViewModel.SearchTypeIndex = this.SearchTypeDropdown.value;
        }

        /// <summary>
        /// Handles the awake event.
        /// </summary>
        private void Awake()
        {
            this.canvasGroup = this.GetComponent<CanvasGroup>();
        }

        /// <summary>
        /// Handles the on enable event.
        /// </summary>
        private void OnEnable()
        {
            this.SearchTypeDropdown.value = this.searchViewModel.SearchTypeIndex;
            this.SearchTextInputField.text = this.searchViewModel.SearchTerms;
        }

        /// <summary>
        /// Handles the on destroy event.
        /// </summary>
        private void OnDestroy()
        {
            this.loadingManager.Loading.RemoveListener(this.HandleLoading);
        }

        /// <summary>
        /// Handles the loading event.
        /// </summary>
        /// <param name="isLoading">A value indicating whether is loading.</param>
        private void HandleLoading(bool isLoading)
        {
            if (this.canvasGroup != null)
            {
                this.canvasGroup.interactable = !isLoading;
            }
        }

        /// <summary>
        /// Handles the completion of the character search. 
        /// </summary>
        /// <param name="result">The result.</param>
        private void CharacterSearchCompleted(IResult<IList<Character>> result)
        {
            //List<SearchResultViewModel> test = new List<SearchResultViewModel>()
            //{
            //    new SearchResultViewModel("Spiderman", "Bitten by a radioactive spider, high school student Peter Parker gained the speed, strength and powers of a spider. Adopting the name Spider-Man, Peter hoped to start a career using his new abilities. Taught that with great power comes great responsibility, Spidey has vowed to use his powers to help people.", "http://i.annihil.us/u/prod/marvel/i/mg/3/50/526548a343e4b", "jpg"),
            //    new SearchResultViewModel("Captain America", "Bitten by a radioactive spider, high school student Peter Parker gained the speed, strength and powers of a spider. Adopting the name Spider-Man, Peter hoped to start a career using his new abilities. Taught that with great power comes great responsibility, Spidey has vowed to use his powers to help people.", "http://i.annihil.us/u/prod/marvel/i/mg/3/50/526548a343e4b", "jpg"),
            //    new SearchResultViewModel("The Incredible Hulk", "Bitten by a radioactive spider, high school student Peter Parker gained the speed, strength and powers of a spider. Adopting the name Spider-Man, Peter hoped to start a career using his new abilities. Taught that with great power comes great responsibility, Spidey has vowed to use his powers to help people.", "http://i.annihil.us/u/prod/marvel/i/mg/3/50/526548a343e4b", "jpg"),
            //    new SearchResultViewModel("Invinicble Iron Man", "Bitten by a radioactive spider, high school student Peter Parker gained the speed, strength and powers of a spider. Adopting the name Spider-Man, Peter hoped to start a career using his new abilities. Taught that with great power comes great responsibility, Spidey has vowed to use his powers to help people.", "http://i.annihil.us/u/prod/marvel/i/mg/3/50/526548a343e4b", "jpg"),
            //    new SearchResultViewModel("The Vision", "Bitten by a radioactive spider, high school student Peter Parker gained the speed, strength and powers of a spider. Adopting the name Spider-Man, Peter hoped to start a career using his new abilities. Taught that with great power comes great responsibility, Spidey has vowed to use his powers to help people.", "http://i.annihil.us/u/prod/marvel/i/mg/3/50/526548a343e4b", "jpg")
            //};

            //this.screenManager.OpenPanel(this.searchResultsPanel.gameObject);
            //this.searchResultsPanel.DisplaySearchResults(test);

            if (result.IsSuccess)
            {
                this.screenManager.OpenPanel(this.searchResultsPanel.gameObject);
                this.searchResultsPanel.DisplaySearchResults(result.Data.Select(c => new SearchResultViewModel(c.Name, c.Description, c.Thumbnail.Path, c.Thumbnail.Extension)).ToList());
            }
            else
            {
                // TODO HANDLE Failure
            }

            this.loadingManager.DecrementRunningOperationCount();
        }
    }
}
