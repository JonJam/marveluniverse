namespace MarvelUniverse.UI
{
    using System.Collections.Generic;
    using System.Linq;
    using Communications.Interfaces;
    using Communications.Result;
    using Events;
    using Loading;
    using Communications.Serialization;
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
    using Model.Story;
    using Model;

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
            //this.loadingManager.IncrementRunningOperationCount();

            this.searchViewModel.SearchTerms = this.SearchTextInputField.text;
            this.searchViewModel.SearchTypeIndex = this.SearchTypeDropdown.value;

            string selectedSearchType = this.SearchTypeDropdown.options[this.searchViewModel.SearchTypeIndex].text;

            //switch (selectedSearchType)
            //{
            //    case "Character":
            //        this.StartCoroutine(this.characterService.Search(this.searchViewModel.SearchTerms, this.CharacterSearchCompleted));
            //        break;
            //    case "Comic":
            //        this.StartCoroutine(this.comicService.Search(this.searchViewModel.SearchTerms, this.ComicSearchCompleted));
            //        break;
            //    case "Creator":
            //        this.StartCoroutine(this.creatorService.Search(this.searchViewModel.SearchTerms, this.CreatorSearchCompleted));
            //        break;
            //    case "Event":
            //        this.StartCoroutine(this.eventService.Search(this.searchViewModel.SearchTerms, this.EventSearchCompleted));
            //        break;
            //    case "Series":
            //        this.StartCoroutine(this.seriesService.Search(this.searchViewModel.SearchTerms, this.SeriesSearchCompleted));
            //        break;
            //}

            JsonSerializer test = new JsonSerializer();
            DataWrapper<Story> test2 = test.Deserialize<DataWrapper<Story>>("{   \"code\": 200,   \"status\": \"Ok\",   \"copyright\": \"© 2015 MARVEL\",   \"attributionText\": \"Data provided by Marvel. © 2015 MARVEL\",   \"attributionHTML\": \"\",   \"etag\": \"e786157a502734d640ef9a80855e26d8278f864f\",   \"data\": {     \"offset\": 0,     \"limit\": 20,     \"total\": 1,     \"count\": 1,     \"results\": [       {         \"id\": 5873,         \"title\": \"1 of 7 - 7XLS\",         \"description\": \"\",         \"resourceURI\": \"http://gateway.marvel.com/v1/public/stories/5873\",         \"type\": \"story\",         \"modified\": \"1969-12-31T19:00:00-0500\",         \"thumbnail\": null,         \"creators\": {           \"available\": 5,           \"collectionURI\": \"http://gateway.marvel.com/v1/public/stories/5873/creators\",           \"items\": [             {               \"resourceURI\": \"http://gateway.marvel.com/v1/public/creators/452\",               \"name\": \"Chris Eliopoulos\",               \"role\": \"letterer\"             },             {               \"resourceURI\": \"http://gateway.marvel.com/v1/public/creators/774\",               \"name\": \"Morry Hollowell\",               \"role\": \"colorist\"             },             {               \"resourceURI\": \"http://gateway.marvel.com/v1/public/creators/9484\",               \"name\": \"Steve McNiven\",               \"role\": \"penciller\"             },             {               \"resourceURI\": \"http://gateway.marvel.com/v1/public/creators/88\",               \"name\": \"Mark Millar\",               \"role\": \"writer\"             },             {               \"resourceURI\": \"http://gateway.marvel.com/v1/public/creators/471\",               \"name\": \"Dexter Vines\",               \"role\": \"inker\"             }           ],           \"returned\": 5         },         \"characters\": {           \"available\": 0,           \"collectionURI\": \"http://gateway.marvel.com/v1/public/stories/5873/characters\",           \"items\": [],           \"returned\": 0         },         \"series\": {           \"available\": 2,           \"collectionURI\": \"http://gateway.marvel.com/v1/public/stories/5873/series\",           \"items\": [             {               \"resourceURI\": \"http://gateway.marvel.com/v1/public/series/1893\",               \"name\": \"Civil War (2007)\"             },             {               \"resourceURI\": \"http://gateway.marvel.com/v1/public/series/1067\",               \"name\": \"Civil War (2006 - 2007)\"             }           ],           \"returned\": 2         },         \"comics\": {           \"available\": 3,           \"collectionURI\": \"http://gateway.marvel.com/v1/public/stories/5873/comics\",           \"items\": [             {               \"resourceURI\": \"http://gateway.marvel.com/v1/public/comics/6415\",               \"name\": \"Civil War (Trade Paperback)\"             },             {               \"resourceURI\": \"http://gateway.marvel.com/v1/public/comics/6133\",               \"name\": \"Civil War (Trade Paperback)\"             },             {               \"resourceURI\": \"http://gateway.marvel.com/v1/public/comics/4216\",               \"name\": \"Civil War (2006) #1\"             }           ],           \"returned\": 3         },         \"events\": {           \"available\": 1,           \"collectionURI\": \"http://gateway.marvel.com/v1/public/stories/5873/events\",           \"items\": [             {               \"resourceURI\": \"http://gateway.marvel.com/v1/public/events/238\",               \"name\": \"Civil War\"             }           ],           \"returned\": 1         },         \"originalIssue\": {           \"resourceURI\": \"http://gateway.marvel.com/v1/public/comics/4216\",           \"name\": \"Civil War (2006) #1\"         }       }     ]   } }");

            screenManager.OpenInfoPanel(test2.Data.Results[0]);
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
