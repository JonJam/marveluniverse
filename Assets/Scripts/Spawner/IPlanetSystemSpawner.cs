namespace MarvelUniverse.Spawner
{
    using MarvelUniverse.Model.Character;
    using MarvelUniverse.Model.Comic;
    using MarvelUniverse.Model.Creator;
    using MarvelUniverse.Model.Series;
    using MarvelUniverse.Model.Story;
    using UnityEngine;

    /// <summary>
    /// Interface for a planet system spawner.
    /// </summary>
    public interface IPlanetSystemSpawner
    {
        /// <summary>
        /// Instantiates a character planet system.
        /// </summary>
        /// <param name="character">The character.</param>
        /// <returns>The position of the instantiated object.</returns>
        Vector3 Instantiate(Character character);

        /// <summary>
        /// Instantiate a character planet system based on the specified spawn origin.
        /// </summary>
        /// <param name="character">The character.</param>
        /// <param name="spawnOrigin">The spawn origin.</param>
        /// <returns>The position of the instantiated object.</returns>
        Vector3 Instantiate(Character character, Vector3 spawnOrigin);

        /// <summary>
        /// Instantiates a comic planet system.
        /// </summary>
        /// <param name="comic">The comic.</param>
        /// <returns>The position of the instantiated object.</returns>
        Vector3 Instantiate(Comic comic);

        /// <summary>
        /// Instantiate a comic planet system based on the specified spawn origin.
        /// </summary>
        /// <param name="comic">The comic.</param>
        /// <param name="spawnOrigin">The spawn origin.</param>
        /// <returns>The position of the instantiated object.</returns>
        Vector3 Instantiate(Comic comic, Vector3 spawnOrigin);

        /// <summary>
        /// Instantiates a creator planet system.
        /// </summary>
        /// <param name="creator">The creator.</param>
        /// <returns>The position of the instantiated object.</returns>
        Vector3 Instantiate(Creator creator);

        /// <summary>
        /// Instantiate a creator planet system based on the specified spawn origin.
        /// </summary>
        /// <param name="creator">The creator.</param>
        /// <param name="spawnOrigin">The spawn origin.</param>
        /// <returns>The position of the instantiated object.</returns>
        Vector3 Instantiate(Creator creator, Vector3 spawnOrigin);

        /// <summary>
        /// Instantiates an event planet system.
        /// </summary>
        /// <param name="comicEvent">The event.</param>
        /// <returns>The position of the instantiated object.</returns>
        Vector3 Instantiate(MarvelUniverse.Model.Event.Event comicEvent);

        /// <summary>
        /// Instantiate an event planet system based on the specified spawn origin.
        /// </summary>
        /// <param name="comicEvent">The comic event.</param>
        /// <param name="spawnOrigin">The spawn origin.</param>
        /// <returns>The position of the instantiated object.</returns>
        Vector3 Instantiate(MarvelUniverse.Model.Event.Event comicEvent, Vector3 spawnOrigin);

        /// <summary>
        /// Instantiates a series planet system.
        /// </summary>
        /// <param name="series">The series.</param>
        /// <returns>The position of the instantiated object.</returns>
        Vector3 Instantiate(Series series);

        /// <summary>
        /// Instantiate a series planet system based on the specified spawn origin.
        /// </summary>
        /// <param name="series">The series.</param>
        /// <param name="spawnOrigin">The spawn origin.</param>
        /// <returns>The position of the instantiated object.</returns>
        Vector3 Instantiate(Series series, Vector3 spawnOrigin);

        /// <summary>
        /// Instantiates a story planet system.
        /// </summary>
        /// <param name="character">The story.</param>
        /// <returns>The position of the instantiated object.</returns>
        Vector3 Instantiate(Story story);

        /// <summary>
        /// Instantiate a story planet system based on the specified spawn origin.
        /// </summary>
        /// <param name="story">The story.</param>
        /// <param name="spawnOrigin">The spawn origin.</param>
        /// <returns>The position of the instantiated object.</returns>
        Vector3 Instantiate(Story story, Vector3 spawnOrigin);
    }
}