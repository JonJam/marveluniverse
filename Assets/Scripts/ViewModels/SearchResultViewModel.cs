﻿namespace MarvelUniverse.ViewModels
{
    using System;
    using Events;
    using GameObjects.Camera;
    using GameObjects.Planet;
    using Screen;

    /// <summary>
    /// The search results view model.
    /// </summary>
    public class SearchResultViewModel
    {
        /// <summary>
        /// The screen manager.
        /// </summary>
        private readonly IScreenManager screenManager;

        /// <summary>
        /// The event manager.
        /// </summary>
        private readonly IEventManager eventManager;

        /// <summary>
        /// The search view model.
        /// </summary>
        private readonly SearchViewModel searchViewModel;

        /// <summary>
        /// The name.
        /// </summary>
        private readonly string name;

        /// <summary>
        /// The description.
        /// </summary>
        private readonly string description;

        /// <summary>
        /// The image path.
        /// </summary>
        private readonly string imagePath;

        /// <summary>
        /// The image extension.
        /// </summary>
        private readonly string imageExtension;
                
        /// <summary>
        /// The spawn function.
        /// </summary>
        private readonly Func<BasePlanet> spawnFunction;

        /// <summary>
        /// Initializes a new instance of the <see cref="SearchResultViewModel"/> class.
        /// </summary>
        /// <param name="screenManager">The screen manager.</param>
        /// <param name="eventManager">The event manager.</param>
        /// <param name="searchViewModel">The search view model.</param>
        /// <param name="name">The name.</param>
        /// <param name="description">The description.</param>
        /// <param name="imagePath">The image path.</param>
        /// <param name="imageExtension">The image extension.</param>
        /// <param name="spawnFunction">The spawn function.</param>
        public SearchResultViewModel(
            IScreenManager screenManager,
            IEventManager eventManager,
            SearchViewModel searchViewModel,
            string name, 
            string description,
            string imagePath,
            string imageExtension,
            Func<BasePlanet> spawnFunction)
        {
            this.screenManager = screenManager;
            this.eventManager = eventManager;

            this.searchViewModel = searchViewModel;

            this.name = name;
            this.description = description;
            this.imagePath = imagePath;
            this.imageExtension = imageExtension;

            this.spawnFunction = spawnFunction;
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
        /// Gets the description.
        /// </summary>
        public string Description
        {
            get
            {
                return this.description;
            }
        }

        /// <summary>
        /// Gets the image path.
        /// </summary>
        public string ImagePath
        {
            get
            {
                return this.imagePath;
            }
        }

        /// <summary>
        /// Gets the image extension.
        /// </summary>
        public string ImageExtension
        {
            get
            {
                return this.imageExtension;
            }
        }

        /// <summary>
        /// Performs the search result clicked action.
        /// </summary>
        public void SearchResultClicked()
        {
            this.screenManager.OpenExplorerPanel();

            this.searchViewModel.Reset();

            BasePlanet planet = this.spawnFunction();
            
            this.eventManager.GetEvent<IsCameraMovementEnabledEvent>().Invoke(true);
                    
            this.eventManager.GetEvent<CameraFocusOnEvent>().Invoke(planet.gameObject, planet.FocusPosition);
        }
    }
}
