namespace MarvelUniverse.Spawner
{
    using MarvelUniverse.Model.Character;
    using MarvelUniverse.Model.Comic;
    using MarvelUniverse.Model.Creator;
    using MarvelUniverse.Model.Series;
    using MarvelUniverse.Model.Story;
    using UnityEngine;

    /// <summary>
    /// The planet system spawner.
    /// </summary>
    public class PlanetSystemSpawner : IPlanetSystemSpawner
    {
        /// <summary>
        /// The initial planet system position.
        /// </summary>
        private readonly Vector3 initialPlanetSystemPosition;

        /// <summary>
        /// The character planet system prefab.
        /// </summary>
        private readonly GameObject characterPlanetSystemPrefab;

        /// <summary>
        /// The comic planet system prefab.
        /// </summary>
        private readonly GameObject comicPlanetSystemPrefab;

        /// <summary>
        /// The creator planet system prefab.
        /// </summary>
        private readonly GameObject creatorPlanetSystemPrefab;

        /// <summary>
        /// The event planet system prefab.
        /// </summary>
        private readonly GameObject eventPlanetSystemPrefab;

        /// <summary>
        /// The series planet system prefab.
        /// </summary>
        private readonly GameObject seriesPlanetSystemPrefab;

        /// <summary>
        /// The story planet system prefab.
        /// </summary>
        private readonly GameObject storyPlanetSystemPrefab;

        /// <summary>
        /// Initializes a new instance of the <see cref="PlanetSystemSpawner"/> class.
        /// </summary>
        /// <param name="initialPlanetSystemPosition">The initial planet system position.</param>
        /// <param name="characterPlanetSystemPrefab">The character planet system prefab.</param>
        /// <param name="comicPlanetSystemPrefab">The comic planet system prefab.</param>
        /// <param name="creatorPlanetSystemPrefab">The creator planet system prefab.</param>
        /// <param name="eventPlanetSystemPrefab">The event planet system prefab.</param>
        /// <param name="seriesPlanetSystemPrefab">The series planet system prefab.</param>
        /// <param name="storyPlanetSystemPrefab">The story planet system prefab.</param>
        public PlanetSystemSpawner(
            Vector3 initialPlanetSystemPosition,
            GameObject characterPlanetSystemPrefab,
            GameObject comicPlanetSystemPrefab,
            GameObject creatorPlanetSystemPrefab,
            GameObject eventPlanetSystemPrefab,
            GameObject seriesPlanetSystemPrefab,
            GameObject storyPlanetSystemPrefab)
        {
            this.initialPlanetSystemPosition = initialPlanetSystemPosition;

            this.characterPlanetSystemPrefab = characterPlanetSystemPrefab;
            this.comicPlanetSystemPrefab = comicPlanetSystemPrefab;
            this.creatorPlanetSystemPrefab = creatorPlanetSystemPrefab;
            this.eventPlanetSystemPrefab = eventPlanetSystemPrefab;
            this.seriesPlanetSystemPrefab = seriesPlanetSystemPrefab;
            this.storyPlanetSystemPrefab = storyPlanetSystemPrefab;
        }

        /// <summary>
        /// Instantiates a character planet system.
        /// </summary>
        /// <param name="character">The character.</param>
        public void Instantiate(Character character)
        {
            Object.Instantiate(this.characterPlanetSystemPrefab, this.initialPlanetSystemPosition, Quaternion.identity);
        }

        /// <summary>
        /// Instantiates a comic planet system.
        /// </summary>
        /// <param name="comic">The comic.</param>
        public void Instantiate(Comic comic)
        {
            Object.Instantiate(this.comicPlanetSystemPrefab, this.initialPlanetSystemPosition, Quaternion.identity);
        }

        /// <summary>
        /// Instantiates a creator planet system.
        /// </summary>
        /// <param name="creator">The creator.</param>
        public void Instantiate(Creator creator)
        {
            Object.Instantiate(this.creatorPlanetSystemPrefab, this.initialPlanetSystemPosition, Quaternion.identity);
        }

        /// <summary>
        /// Instantiates an event planet system.
        /// </summary>
        /// <param name="comicEvent">The event.</param>
        public void Instantiate(MarvelUniverse.Model.Event.Event comicEvent)
        {
            Object.Instantiate(this.eventPlanetSystemPrefab, this.initialPlanetSystemPosition, Quaternion.identity);
        }

        /// <summary>
        /// Instantiates a series planet system.
        /// </summary>
        /// <param name="series">The series.</param>
        public void Instantiate(Series series)
        {
            Object.Instantiate(this.seriesPlanetSystemPrefab, this.initialPlanetSystemPosition, Quaternion.identity);
        }

        /// <summary>
        /// Instantiates a story planet system.
        /// </summary>
        /// <param name="character">The story.</param>
        public void Instantiate(Story story)
        {
            Object.Instantiate(this.storyPlanetSystemPrefab, this.initialPlanetSystemPosition, Quaternion.identity);
        }
    }
}
