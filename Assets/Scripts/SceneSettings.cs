﻿namespace MarvelUniverse
{
    using System;
    using UI.Screens;
    using UnityEngine;

    /// <summary>
    /// The scene settings.
    /// </summary>
    [Serializable]
    public class SceneSettings
    {
        /// <summary>
        /// The search panel.
        /// </summary>
        public SearchPanel SearchPanel;

        /// <summary>
        /// The search results panel.
        /// </summary>
        public SearchResultsPanel SearchResultsPanel;

        /// <summary>
        /// The information panel.
        /// </summary>
        public InfoPanel InfoPanel;

        /// <summary>
        /// The explorer panel.
        /// </summary>
        public ExplorerPanel ExplorerPanel;

        /// <summary>
        /// The jump gate panel;
        /// </summary>
        public JumpGatePanel JumpGatePanel;

        /// <summary>
        /// The initial planet system position.
        /// </summary>
        public Vector3 InitialPlanetSystemPosition;

        /// <summary>
        /// The character planet system prefab.
        /// </summary>
        public GameObject CharacterPlanetSystemPrefab;

        /// <summary>
        /// The comic planet system prefab.
        /// </summary>
        public GameObject ComicPlanetSystemPrefab;

        /// <summary>
        /// The creator planet system prefab.
        /// </summary>
        public GameObject CreatorPlanetSystemPrefab;

        /// <summary>
        /// The event planet system prefab.
        /// </summary>
        public GameObject EventPlanetSystemPrefab;

        /// <summary>
        /// The series planet system prefab.
        /// </summary>
        public GameObject SeriesPlanetSystemPrefab;

        /// <summary>
        /// The spawn sphere radius.
        /// </summary>
        public int SpawnSphereRadius;

        /// <summary>
        /// The planet system size.
        /// </summary>
        public float PlanetSystemSize;

        /// <summary>
        /// The planet size.
        /// </summary>
        public Vector3 PlanetSize;

        /// <summary>
        /// The main camera.
        /// </summary>
        public Camera MainCamera;
    }
}
