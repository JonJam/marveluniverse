namespace MarvelUniverse.Behaviours.Camera
{
    using Events;
    using UnityEngine;
    using Zenject;

    /// <summary>
    /// The camera movement.
    /// </summary>
    public class CameraMovement : MonoBehaviour
    {
        /// <summary>
        /// The event manager.
        /// </summary>
        private IEventManager eventManager;

        /// <summary>
        /// The look speed.
        /// </summary>
        public float LookSpeed = 100f;

        /// <summary>
        /// The movement speed.
        /// </summary>
        public float MovementSpeed = 10f;

        /// <summary>
        /// A value indicating whether to inverse vertical view direction.
        /// </summary>
        public bool InverseVertical = true;

        /// <summary>
        /// A value indicating whether is movement enabled.
        /// </summary>
        private bool isMovementEnabled;

        /// <summary>
        /// Injection initialization.
        /// </summary>
        /// <param name="eventManager">The event manager.</param>
        [PostInject]
        private void InjectionInitialize(
            IEventManager eventManager)
        {
            this.eventManager = eventManager;

            this.eventManager.GetEvent<IsCameraMovementEnabledEvent>().AddListener(this.HandleIsCameraMovementEnabledEvent);
        }

        /// <summary>
        /// Handles the update event.
        /// </summary>
        private void Update()
        {
            if (this.isMovementEnabled)
            {
                this.Rotate();

                this.Move();
            }
        }

        /// <summary>
        /// Handles the destroy event.
        /// </summary>
        private void OnDestory()
        {
            this.eventManager.GetEvent<IsCameraMovementEnabledEvent>().RemoveListener(this.HandleIsCameraMovementEnabledEvent);
        }
        
        /// <summary>
        /// Handles the is camera movement enabled event.
        /// </summary>
        /// <param name="isMovementEnabled">A value indicating whether movement is enabled.</param>
        private void HandleIsCameraMovementEnabledEvent(bool isMovementEnabled)
        {
            this.isMovementEnabled = isMovementEnabled;
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
            rotation = rotation.normalized * this.LookSpeed * Time.deltaTime;

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
            movement = movement.normalized * this.MovementSpeed * Time.deltaTime;

            this.transform.Translate(movement);
        }
    }
}
