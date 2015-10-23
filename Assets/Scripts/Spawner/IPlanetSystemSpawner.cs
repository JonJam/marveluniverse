namespace MarvelUniverse.Spawner
{
    using MarvelUniverse.Model.Character;
    using MarvelUniverse.Model.Comic;
    using MarvelUniverse.Model.Creator;
    using MarvelUniverse.Model.Series;
    using MarvelUniverse.Model.Story;
    
    /// <summary>
    /// Interface for a planet system spawner.
    /// </summary>
    public interface IPlanetSystemSpawner
    {
        /// <summary>
        /// Instantiates a character planet system.
        /// </summary>
        /// <param name="character">The character.</param>
        void Instantiate(Character character);

        /// <summary>
        /// Instantiates a comic planet system.
        /// </summary>
        /// <param name="comic">The comic.</param>
        void Instantiate(Comic comic);

        /// <summary>
        /// Instantiates a creator planet system.
        /// </summary>
        /// <param name="creator">The creator.</param>
        void Instantiate(Creator creator);
        
        /// <summary>
        /// Instantiates an event planet system.
        /// </summary>
        /// <param name="comicEvent">The event.</param>
        void Instantiate(MarvelUniverse.Model.Event.Event comicEvent);
        
        /// <summary>
        /// Instantiates a series planet system.
        /// </summary>
        /// <param name="series">The series.</param>
        void Instantiate(Series series);

        /// <summary>
        /// Instantiates a story planet system.
        /// </summary>
        /// <param name="story">The story.</param>
        void Instantiate(Story story);
    }
}