namespace MarvelUniverse.Spawner
{
    using Behaviours.Planet;
    using MarvelUniverse.Model.Character;
    using MarvelUniverse.Model.Comic;
    using MarvelUniverse.Model.Creator;
    using MarvelUniverse.Model.Series;
    using MarvelUniverse.Model.Story;
    using UnityEngine;
    using Zenject;

    /// <summary>
    /// The planet system spawner.
    /// </summary>
    public class PlanetSystemSpawner : IPlanetSystemSpawner
    {
        /// <summary>
        /// The instantiator.
        /// </summary>
        private readonly IInstantiator instantiator;

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
        /// The spawn sphere radius.
        /// </summary>
        private readonly int spawnSphereRadius;

        /// <summary>
        /// The planet system size.
        /// </summary>
        private readonly float planetSystemSize;

        /// <summary>
        /// The planet size.
        /// </summary>
        private readonly Vector3 planetSize;

        /// <summary>
        /// The main camera.
        /// </summary>
        private readonly Camera mainCamera;

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
        /// <param name="spawnSphereRadius">The spawn sphere radius.</param>
        /// <param name="planetSystemSize">The planet system size.</param>
        /// <param name="planetSize">The planet size.</param>
        /// <param name="mainCamera">The main camera.</param>
        public PlanetSystemSpawner(
            IInstantiator instantiator,
            Vector3 initialPlanetSystemPosition,
            GameObject characterPlanetSystemPrefab,
            GameObject comicPlanetSystemPrefab,
            GameObject creatorPlanetSystemPrefab,
            GameObject eventPlanetSystemPrefab,
            GameObject seriesPlanetSystemPrefab,
            GameObject storyPlanetSystemPrefab,            
            int spawnSphereRadius,
            float planetSystemSize,
            Vector3 planetSize,
            Camera mainCamera)
        {
            this.instantiator = instantiator;

            this.initialPlanetSystemPosition = initialPlanetSystemPosition;

            this.characterPlanetSystemPrefab = characterPlanetSystemPrefab;
            this.comicPlanetSystemPrefab = comicPlanetSystemPrefab;
            this.creatorPlanetSystemPrefab = creatorPlanetSystemPrefab;
            this.eventPlanetSystemPrefab = eventPlanetSystemPrefab;
            this.seriesPlanetSystemPrefab = seriesPlanetSystemPrefab;
            this.storyPlanetSystemPrefab = storyPlanetSystemPrefab;
            
            this.spawnSphereRadius = spawnSphereRadius;
            this.planetSystemSize = planetSystemSize;
            this.planetSize = planetSize;
            this.mainCamera = mainCamera;
        }

        /// <summary>
        /// Instantiates a character planet system.
        /// </summary>
        /// <param name="character">The character.</param>
        /// <returns>The position of the instantiated object.</returns>
        public Vector3 Instantiate(Character character)
        {
            GameObject objectInstaniated = this.Instantiate(this.characterPlanetSystemPrefab, this.initialPlanetSystemPosition);

            CharacterPlanet characterPlanet = objectInstaniated.GetComponentInChildren<CharacterPlanet>();
            characterPlanet.HookUp(character);

            return objectInstaniated.transform.position;
        }

        /// <summary>
        /// Instantiate a character planet system based on the specified spawn origin.
        /// </summary>
        /// <param name="character">The character.</param>
        /// <param name="spawnOrigin">The spawn origin.</param>
        /// <returns>The position of the instantiated object.</returns>
        public Vector3 Instantiate(Character character, Vector3 spawnOrigin)
        {
            Vector3 randomSpawnPosition = this.CreateRandomSpawnPositionInView(spawnOrigin);

            GameObject objectInstaniated = this.Instantiate(this.characterPlanetSystemPrefab, randomSpawnPosition);

            CharacterPlanet characterPlanet = objectInstaniated.GetComponentInChildren<CharacterPlanet>();
            characterPlanet.HookUp(character);

            return objectInstaniated.transform.position;
        }

        /// <summary>
        /// Instantiates a comic planet system.
        /// </summary>
        /// <param name="comic">The comic.</param>
        /// <returns>The position of the instantiated object.</returns>
        public Vector3 Instantiate(Comic comic)
        {
            GameObject objectInstaniated = this.Instantiate(this.comicPlanetSystemPrefab, this.initialPlanetSystemPosition);

            ComicPlanet comicPlanet = objectInstaniated.GetComponentInChildren<ComicPlanet>();
            comicPlanet.HookUp(comic);

            return objectInstaniated.transform.position;
        }

        /// <summary>
        /// Instantiate a comic planet system based on the specified spawn origin.
        /// </summary>
        /// <param name="comic">The comic.</param>
        /// <param name="spawnOrigin">The spawn origin.</param>
        /// <returns>The position of the instantiated object.</returns>
        public Vector3 Instantiate(Comic comic, Vector3 spawnOrigin)
        {
            Vector3 randomSpawnPosition = this.CreateRandomSpawnPositionInView(spawnOrigin);

            GameObject objectInstaniated = this.Instantiate(this.comicPlanetSystemPrefab, randomSpawnPosition);

            ComicPlanet comicPlanet = objectInstaniated.GetComponentInChildren<ComicPlanet>();
            comicPlanet.HookUp(comic);

            return objectInstaniated.transform.position;
        }

        /// <summary>
        /// Instantiates a creator planet system.
        /// </summary>
        /// <param name="creator">The creator.</param>
        /// <returns>The position of the instantiated object.</returns>
        public Vector3 Instantiate(Creator creator)
        {
            GameObject objectInstaniated = this.Instantiate(this.creatorPlanetSystemPrefab, this.initialPlanetSystemPosition);

            CreatorPlanet creatorPlanet = objectInstaniated.GetComponentInChildren<CreatorPlanet>();
            creatorPlanet.HookUp(creator);

            return objectInstaniated.transform.position;
        }

        /// <summary>
        /// Instantiate a creator planet system based on the specified spawn origin.
        /// </summary>
        /// <param name="creator">The creator.</param>
        /// <param name="spawnOrigin">The spawn origin.</param>
        /// <returns>The position of the instantiated object.</returns>
        public Vector3 Instantiate(Creator creator, Vector3 spawnOrigin)
        {
            Vector3 randomSpawnPosition = this.CreateRandomSpawnPositionInView(spawnOrigin);

            GameObject objectInstaniated = this.Instantiate(this.creatorPlanetSystemPrefab, randomSpawnPosition);

            CreatorPlanet creatorPlanet = objectInstaniated.GetComponentInChildren<CreatorPlanet>();
            creatorPlanet.HookUp(creator);

            return objectInstaniated.transform.position;
        }

        /// <summary>
        /// Instantiates an event planet system.
        /// </summary>
        /// <param name="comicEvent">The event.</param>
        /// <returns>The position of the instantiated object.</returns>
        public Vector3 Instantiate(MarvelUniverse.Model.Event.Event comicEvent)
        {
            GameObject objectInstaniated = this.Instantiate(this.eventPlanetSystemPrefab, this.initialPlanetSystemPosition);

            EventPlanet eventPlanet = objectInstaniated.GetComponentInChildren<EventPlanet>();
            eventPlanet.HookUp(comicEvent);

            return objectInstaniated.transform.position;
        }

        /// <summary>
        /// Instantiate an event planet system based on the specified spawn origin.
        /// </summary>
        /// <param name="comicEvent">The comic event.</param>
        /// <param name="spawnOrigin">The spawn origin.</param>
        /// <returns>The position of the instantiated object.</returns>
        public Vector3 Instantiate(MarvelUniverse.Model.Event.Event comicEvent, Vector3 spawnOrigin)
        {
            Vector3 randomSpawnPosition = this.CreateRandomSpawnPositionInView(spawnOrigin);

            GameObject objectInstaniated = this.Instantiate(this.eventPlanetSystemPrefab, randomSpawnPosition);

            EventPlanet eventPlanet = objectInstaniated.GetComponentInChildren<EventPlanet>();
            eventPlanet.HookUp(comicEvent);

            return objectInstaniated.transform.position;
        }

        /// <summary>
        /// Instantiates a series planet system.
        /// </summary>
        /// <param name="series">The series.</param>
        /// <returns>The position of the instantiated object.</returns>
        public Vector3 Instantiate(Series series)
        {
            GameObject objectInstaniated = this.Instantiate(this.seriesPlanetSystemPrefab, this.initialPlanetSystemPosition);

            SeriesPlanet seriesPlanet = objectInstaniated.GetComponentInChildren<SeriesPlanet>();
            seriesPlanet.HookUp(series);

            return objectInstaniated.transform.position;
        }

        /// <summary>
        /// Instantiate a series planet system based on the specified spawn origin.
        /// </summary>
        /// <param name="series">The series.</param>
        /// <param name="spawnOrigin">The spawn origin.</param>
        /// <returns>The position of the instantiated object.</returns>
        public Vector3 Instantiate(Series series, Vector3 spawnOrigin)
        {
            Vector3 randomSpawnPosition = this.CreateRandomSpawnPositionInView(spawnOrigin);

            GameObject objectInstaniated = this.Instantiate(this.seriesPlanetSystemPrefab, randomSpawnPosition);

            SeriesPlanet seriesPlanet = objectInstaniated.GetComponentInChildren<SeriesPlanet>();
            seriesPlanet.HookUp(series);

            return objectInstaniated.transform.position;
        }

        /// <summary>
        /// Instantiates a story planet system.
        /// </summary>
        /// <param name="character">The story.</param>
        /// <returns>The position of the instantiated object.</returns>
        public Vector3 Instantiate(Story story)
        {
            GameObject objectInstaniated = this.Instantiate(this.storyPlanetSystemPrefab, this.initialPlanetSystemPosition);

            StoryPlanet storyPlanet = objectInstaniated.GetComponentInChildren<StoryPlanet>();
            storyPlanet.HookUp(story);

            return objectInstaniated.transform.position;
        }

        /// <summary>
        /// Instantiate a story planet system based on the specified spawn origin.
        /// </summary>
        /// <param name="story">The story.</param>
        /// <returns>The position of the instantiated object.</returns>
        public Vector3 Instantiate(Story story, Vector3 spawnOrigin)
        {
            Vector3 randomSpawnPosition = this.CreateRandomSpawnPositionInView(spawnOrigin);

            GameObject objectInstaniated = this.Instantiate(this.storyPlanetSystemPrefab, randomSpawnPosition);
            
            StoryPlanet storyPlanet = objectInstaniated.GetComponentInChildren<StoryPlanet>();
            storyPlanet.HookUp(story);

            return objectInstaniated.transform.position;
        }

        /// <summary>
        /// Instantiate the prefab at the specified position.
        /// </summary>
        /// <param name="planetSystemPrefab">The planet system prefab.</param>
        /// <param name="spawnPosition">The spawn position.</param>
        /// <returns>The position of the instantiated object.</returns>
        private GameObject Instantiate(GameObject planetSystemPrefab, Vector3 spawnPosition)
        {
            GameObject planetSystem = this.instantiator.InstantiatePrefab(planetSystemPrefab) as GameObject;

            planetSystem.transform.position = spawnPosition;

            return planetSystem;
        }

        /// <summary>
        /// Creates a random spawn position in view.
        /// </summary>
        /// <param name="spawnOrigin">The spawn origin.</param>
        /// <returns>A random spawn position.</returns>
        private Vector3 CreateRandomSpawnPositionInView(Vector3 spawnOrigin)
        {
            Vector3 spawnPosition = new Vector3();
            bool isCollision = false;
            bool isViewable = false;

            do
            {
                spawnPosition = this.CreateRandomSpawnPosition(spawnOrigin);

                isCollision = Physics.CheckSphere(spawnPosition, this.planetSystemSize);

                Plane[] planes = GeometryUtility.CalculateFrustumPlanes(this.mainCamera);
                isViewable = GeometryUtility.TestPlanesAABB(planes, new Bounds(spawnPosition, this.planetSize));
            }
            while (isCollision || !isViewable);

            return spawnPosition;
        }

        /// <summary>
        /// Create a random spawn position.
        /// </summary>
        /// <param name="spawnOrigin">The spawn origin.</param>
        /// <returns>A random spawn position.</returns>
        private Vector3 CreateRandomSpawnPosition(Vector3 spawnOrigin)
        {
            Vector3 randomSpherePosition = Random.insideUnitSphere * this.spawnSphereRadius;

            return spawnOrigin + randomSpherePosition;
        }
    }
}
