namespace MarvelUniverse.Behaviours.Camera
{
    using System;
    using UnityEngine;
    using UnityEngine.Events;

    /// <summary>
    /// The camera focus event.
    /// </summary>
    public class CameraFocusOnEvent : UnityEvent<GameObject, Func<Transform, Vector3>>
    {
    }
}
