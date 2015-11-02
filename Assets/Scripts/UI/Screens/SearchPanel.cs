namespace MarvelUniverse.UI.Screens
{
    using System.Collections.Generic;
    using System.Linq;
    using Communications.Interfaces;
    using Communications.Result;
    using Events;
    using Loading;
    using Model.Character;
    using Model.Comic;
    using Model.Creator;
    using Model.Series;
    using Screen;
    using Spawner;
    using UnityEngine;
    using UnityEngine.UI;
    using ViewModels;
    using Zenject;
    using Event = MarvelUniverse.Model.Event.Event;

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
        /// The comic service.
        /// </summary>
        private IComicService comicService;

        /// <summary>
        /// The creator service.
        /// </summary>
        private ICreatorService creatorService;

        /// <summary>
        /// The series service.
        /// </summary>
        private ISeriesService seriesService;

        /// <summary>
        /// The event service.
        /// </summary>
        private IEventService eventService;

        /// <summary>
        /// The loading manager.
        /// </summary>
        private ILoadingManager loadingManager;

        /// <summary>
        /// The screen manager.
        /// </summary>
        private IScreenManager screenManager;

        /// <summary>
        /// The event manager.
        /// </summary>
        private IEventManager eventManager;

        /// <summary>
        /// The result processor.
        /// </summary>
        private IResultProcessor resultProcessor;

        /// <summary>
        /// The planet system spawner.
        /// </summary>
        private IPlanetSystemSpawner planetSystemSpawner;

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
        /// Injection initialization.
        /// </summary>
        /// <param name="characterService">The character service.</param>
        /// <param name="comicService">The comic service.</param>
        /// <param name="creatorService">The creator service.</param>
        /// <param name="seriesService">The series service.</param>
        /// <param name="eventService">The event service.</param>
        /// <param name="loadingManager">The loading manager.</param>
        /// <param name="screenManager">The screen manaager.</param>
        /// <param name="eventManager">The event manager.</param>
        /// <param name="resultProcessor">The result processor.</param>
        /// <param name="planetSystemSpawner">The planet system spawner.</param>
        /// <param name="searchViewModel">The search view model.</param>
        [PostInject]
        private void InjectionInitialize(
            ICharacterService characterService,
            IComicService comicService,
            ICreatorService creatorService,
            ISeriesService seriesService,
            IEventService eventService,
            ILoadingManager loadingManager,
            IScreenManager screenManager,
            IEventManager eventManager,
            IResultProcessor resultProcessor,
            IPlanetSystemSpawner planetSystemSpawner,
            SearchViewModel searchViewModel)
        {
            this.characterService = characterService;
            this.comicService = comicService;
            this.creatorService = creatorService;
            this.seriesService = seriesService;
            this.eventService = eventService;

            this.loadingManager = loadingManager;
            this.screenManager = screenManager;
            this.eventManager = eventManager;
            this.resultProcessor = resultProcessor;
            this.planetSystemSpawner = planetSystemSpawner;

            this.searchViewModel = searchViewModel;

            this.eventManager.GetEvent<LoadingEvent>().AddListener(this.OnLoading);
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
                    this.StartCoroutine(this.characterService.Search(this.searchViewModel.SearchTerms, this.CharacterSearchCompleted));
                    break;
                case "Comic":
                    this.StartCoroutine(this.comicService.Search(this.searchViewModel.SearchTerms, this.ComicSearchCompleted));
                    break;
                case "Creator":
                    this.StartCoroutine(this.creatorService.Search(this.searchViewModel.SearchTerms, this.CreatorSearchCompleted));
                    break;
                case "Event":
                    this.StartCoroutine(this.eventService.Search(this.searchViewModel.SearchTerms, this.EventSearchCompleted));
                    break;
                case "Series":
                    this.StartCoroutine(this.seriesService.Search(this.searchViewModel.SearchTerms, this.SeriesSearchCompleted));
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
        /// Handles the update event.
        /// </summary>
        private void Update()
        {
            // The isFocused property on this.SearchTextInputField isn't reliable. Below check fixes this.
            // When interacting with input field, isFocused not set to true until Return key is pressed once; therefore user has to press twice.
            GameObject focusedGameObject = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject;

            bool isSearchTextInputFieldFocused = focusedGameObject != null ? focusedGameObject == this.SearchTextInputField.gameObject : false;            

            if (isSearchTextInputFieldFocused &&
                this.canvasGroup.interactable &&
                this.SearchButton.interactable &&
                Input.GetKey(KeyCode.Return))
            {
                this.OnSearchButtonClicked();
            }
        }

        /// <summary>
        /// Handles the on destroy event.
        /// </summary>
        private void OnDestroy()
        {
            this.eventManager.GetEvent<LoadingEvent>().RemoveListener(this.OnLoading);
        }

        /// <summary>
        /// Handles the loading event.
        /// </summary>
        /// <param name="isLoading">A value indicating whether is loading.</param>
        private void OnLoading(bool isLoading)
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
            if (this.resultProcessor.ProcessResult(result))
            {
                this.screenManager.OpenSearchResults(result.Data.Select(c => new SearchResultViewModel(
                    this.screenManager,
                    this.eventManager,
                    c.Name,
                    c.CleanDescription,
                    c.Thumbnail.Path,
                    c.Thumbnail.Extension,
                    () => { return this.planetSystemSpawner.Instantiate(c); })).ToList());
            }

            this.loadingManager.DecrementRunningOperationCount();
        }

        /// <summary>
        /// Handles the completion of the comic search. 
        /// </summary>
        /// <param name="result">The result.</param>
        private void ComicSearchCompleted(IResult<IList<Comic>> result)
        {
            if (this.resultProcessor.ProcessResult(result))
            {
                this.screenManager.OpenSearchResults(result.Data.Select(c => new SearchResultViewModel(
                    this.screenManager,
                    this.eventManager,
                    c.Title,
                    c.CleanDescription,
                    c.Thumbnail.Path,
                    c.Thumbnail.Extension,
                    () => { return this.planetSystemSpawner.Instantiate(c); })).ToList());
            }

            this.loadingManager.DecrementRunningOperationCount();
        }

        /// <summary>
        /// Handles the completion of the creator search. 
        /// </summary>
        /// <param name="result">The result.</param>
        private void CreatorSearchCompleted(IResult<IList<Creator>> result)
        {
            if (this.resultProcessor.ProcessResult(result))
            {
                this.screenManager.OpenSearchResults(result.Data.Select(c => new SearchResultViewModel(
                    this.screenManager,
                    this.eventManager,
                    c.FullName,
                    null,
                    c.Thumbnail.Path,
                    c.Thumbnail.Extension,
                    () => { return this.planetSystemSpawner.Instantiate(c); })).ToList());
            }

            this.loadingManager.DecrementRunningOperationCount();
        }

        /// <summary>
        /// Handles the completion of the character series. 
        /// </summary>
        /// <param name="result">The result.</param>
        private void SeriesSearchCompleted(IResult<IList<Series>> result)
        {
            if (this.resultProcessor.ProcessResult(result))
            {
                this.screenManager.OpenSearchResults(result.Data.Select(s => new SearchResultViewModel(
                    this.screenManager,
                    this.eventManager,
                    s.Title,
                    s.CleanDescription,
                    s.Thumbnail.Path,
                    s.Thumbnail.Extension,
                    () => { return this.planetSystemSpawner.Instantiate(s); })).ToList());
            }

            this.loadingManager.DecrementRunningOperationCount();
        }

        /// <summary>
        /// Handles the completion of the event search. 
        /// </summary>
        /// <param name="result">The result.</param>
        private void EventSearchCompleted(IResult<IList<Event>> result)
        {
            if (this.resultProcessor.ProcessResult(result))
            {
                this.screenManager.OpenSearchResults(result.Data.Select(e => new SearchResultViewModel(
                    this.screenManager,
                    this.eventManager,
                    e.Title,
                    e.CleanDescription,
                    e.Thumbnail.Path,
                    e.Thumbnail.Extension,
                    () => { return this.planetSystemSpawner.Instantiate(e); })).ToList());
            }

            this.loadingManager.DecrementRunningOperationCount();
        }
    }
}
