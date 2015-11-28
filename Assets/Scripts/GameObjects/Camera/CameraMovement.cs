namespace MarvelUniverse.GameObjects.Camera
{
    using System;
    using System.Threading;
    using Events;
    using UnityEngine;
    using Zenject;

    /// <summary>
    /// The camera movement.
    /// </summary>
    public class CameraMovement : MonoBehaviour
    {
        /// <summary>
        /// The player look speed.
        /// </summary>
        public float PlayerLookSpeed = 20f;

        /// <summary>
        /// The player movement speed.
        /// </summary>
        public float PlayerMovementSpeed = 20f;

        /// <summary>
        /// The focus look speed.
        /// </summary>
        public float FocusLookSpeed = 100f;

        /// <summary>
        /// The focus movement speed.
        /// </summary>
        public float FocusMovementSpeed = 50f;

        /// <summary>
        /// A value indicating whether to inverse vertical view direction.
        /// </summary>
        public bool InverseVertical = true;

        /// <summary>
        /// The event manager.
        /// </summary>
        private IEventManager eventManager;

        /// <summary>
        /// The default position.
        /// </summary>
        private Vector3 defaultPosition;

        /// <summary>
        /// The default rotation.
        /// </summary>
        private Quaternion defaultRotation;

        /// <summary>
        /// A value indicating whether movement is enabled.
        /// </summary>
        private bool isMovementEnabled;

        /// <summary>
        /// The focus count, where > 0 means objects require focus.
        /// </summary>
        private int focusCount;

        /// <summary>
        /// The focused object.
        /// </summary>
        private GameObject focusObject;

        /// <summary>
        /// The focused game object's position to move to.
        /// </summary>
        private Vector3 focusPositionToMoveTo;

        /// <summary>
        /// The focused game object's position to look at.
        /// </summary>
        private Vector3 focusPositionToLookAt;

        /// <summary>
        /// Injection initialization.
        /// </summary>
        /// <param name="eventManager">The event manager.</param>
        [PostInject]
        private void InjectionInitialize(
            IEventManager eventManager)
        {
            this.eventManager = eventManager;

            this.eventManager.GetEvent<IsCameraMovementEnabledEvent>().AddListener(this.OnIsCameraMovementEnabled);
            this.eventManager.GetEvent<CameraFocusOnEvent>().AddListener(this.OnCameraFocus);
            this.eventManager.GetEvent<CameraResetEvent>().AddListener(this.OnCameraReset);
        }

        /// <summary>
        /// Handles the awake event.
        /// </summary>
        private void Awake()
        {
            this.defaultPosition = this.transform.position;
            this.defaultRotation = this.transform.rotation;
        }

        /// <summary>
        /// Handles the update event.
        /// </summary>
        private void Update()
        {
            if (this.isMovementEnabled)
            {
                if (this.HasUserMoved() &&
                    this.focusObject != null)
                {
                    this.eventManager.GetEvent<CameraLostFocusEvent>().Invoke(this.focusObject);
                    this.ResetFocus();
                }

                if (this.focusCount > 0)
                {
                    this.FocusOn();
                }
                else
                {
                    if (Input.GetMouseButton(1))
                    {
                        this.Rotate();
                    }

                    this.Move();
                }
            }
        }

        /// <summary>
        /// Handles the destroy event.
        /// </summary>
        private void OnDestroy()
        {
            this.eventManager.GetEvent<IsCameraMovementEnabledEvent>().RemoveListener(this.OnIsCameraMovementEnabled);
            this.eventManager.GetEvent<CameraFocusOnEvent>().RemoveListener(this.OnCameraFocus);
            this.eventManager.GetEvent<CameraResetEvent>().RemoveListener(this.OnCameraReset);
        }

        /// <summary>
        /// Handles the is camera movement enabled event.
        /// </summary>
        /// <param name="isMovementEnabled">A value indicating whether movement is enabled.</param>
        private void OnIsCameraMovementEnabled(bool isMovementEnabled)
        {
            this.isMovementEnabled = isMovementEnabled;
        }

        /// <summary>
        /// Handles the camera focus event.
        /// </summary>
        /// <param name="objectToFocusOn">The object to focus on.</param>
        /// <param name="positionToMoveToFunc">A function to calculate the position to move to.</param>
        private void OnCameraFocus(GameObject objectToFocusOn, Func<Transform, Vector3> positionToMoveToFunc)
        {
            if (this.focusCount == 0 ||
                (this.focusCount > 0 && this.focusObject != objectToFocusOn))
            {
                Interlocked.Increment(ref this.focusCount);

                if (this.focusObject != null)
                {
                    this.eventManager.GetEvent<CameraLostFocusEvent>().Invoke(this.focusObject);
                }

                this.focusObject = objectToFocusOn;
                this.focusPositionToLookAt = objectToFocusOn.transform.position;
                this.focusPositionToMoveTo = positionToMoveToFunc(this.transform);
            }
        }

        /// <summary>
        /// Handles the camera reset event.
        /// </summary>
        private void OnCameraReset()
        {
            this.isMovementEnabled = false;

            this.ResetFocus();

            this.transform.position = this.defaultPosition;
            this.transform.rotation = this.defaultRotation;
        }

        /// <summary>
        /// Determines whether the user has moved.
        /// </summary>
        /// <returns>A value indicating whether the user has moved.</returns>
        private bool HasUserMoved()
        {
            float horizontalRotation = Input.GetAxis("Mouse X");
            float verticalRotation = Input.GetAxis("Mouse Y");
            float horizontalMovement = Input.GetAxis("Horizontal");
            float verticalMovement = Input.GetAxis("Vertical");

            bool rotated = Input.GetMouseButton(1) && (horizontalRotation != 0f || verticalRotation != 0f);
            bool moved = horizontalMovement != 0f || verticalMovement != 0f;

            return rotated || moved;
        }

        /// <summary>
        /// Focus on the specified game object.
        /// </summary>
        private void FocusOn()
        {
            Vector3 lookDirection = this.focusPositionToLookAt - this.transform.position;
            Quaternion targetRotation = Quaternion.LookRotation(lookDirection);

            if (this.transform.position == this.focusPositionToMoveTo &&
                this.transform.rotation == targetRotation)
            {
                this.eventManager.GetEvent<CameraFocusedOnEvent>().Invoke(this.focusObject);

                Interlocked.Decrement(ref this.focusCount);
            }
            else
            {
                this.transform.position = Vector3.MoveTowards(this.transform.position, this.focusPositionToMoveTo, this.FocusMovementSpeed * Time.deltaTime);

                this.transform.rotation = Quaternion.RotateTowards(this.transform.rotation, targetRotation, this.FocusLookSpeed * Time.deltaTime);
            }
        }

        /// <summary>
        /// Resets focus.
        /// </summary>
        private void ResetFocus()
        {
            this.focusCount = 0;
            this.focusObject = null;
            this.focusPositionToMoveTo = new Vector3();
            this.focusPositionToLookAt = new Vector3();
        }

        /// <summary>
        /// Rotates the camera according to the input.
        /// </summary>
        private void Rotate()
        {
            float horizontalRotation = Input.GetAxis("Mouse X");
            float verticalRotation = Input.GetAxis("Mouse Y");

            verticalRotation = this.InverseVertical ? -verticalRotation : verticalRotation;

            Vector3 rotation = new Vector3(verticalRotation, horizontalRotation, 0);
            rotation = rotation.normalized * this.PlayerLookSpeed * Time.deltaTime;

            this.transform.Rotate(verticalRotation, horizontalRotation, 0);
        }

        /// <summary>
        /// Moves the camera according to the input.
        /// </summary>
        private void Move()
        {
            float horizontalMovement = Input.GetAxis("Horizontal");
            float verticalMovement = Input.GetAxis("Vertical");

            Vector3 movement = new Vector3(horizontalMovement, 0, verticalMovement);
            movement = movement.normalized * this.PlayerMovementSpeed * Time.deltaTime;

            this.transform.Translate(movement);
        }
    }
}
