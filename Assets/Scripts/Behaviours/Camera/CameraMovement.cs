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
        public float LookSpeed = 10f;

        /// <summary>
        /// The movement speed.
        /// </summary>
        public float MovementSpeed = 10f;

        /// <summary>
        /// A value indicating whether to inverse vertical view direction.
        /// </summary>
        public bool InverseVertical = true;

        /// <summary>
        /// The camera rest position.
        /// </summary>
        public Vector3 CameraRestPosition;

        /// <summary>
        /// A value indicating whether movement is enabled.
        /// </summary>
        private bool isMovementEnabled;

        /// <summary>
        /// A value indicating whether this instance is focusing on an object.
        /// </summary>
        private bool isFocusing;

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
            this.eventManager.GetEvent<CameraFocusEvent>().AddListener(this.OnCameraFocus);
        }

        /// <summary>
        /// Handles the update event.
        /// </summary>
        private void Update()
        {
            if (this.isFocusing)
            {
                this.FocusOn();
            }
            else if (this.isMovementEnabled)
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
            this.eventManager.GetEvent<IsCameraMovementEnabledEvent>().RemoveListener(this.OnIsCameraMovementEnabled);
            this.eventManager.GetEvent<CameraFocusEvent>().RemoveListener(this.OnCameraFocus);
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
        private void OnCameraFocus(GameObject objectToFocusOn)
        {
            this.isMovementEnabled = false;
            this.isFocusing = true;
            this.focusPositionToLookAt = objectToFocusOn.transform.position;
            this.focusPositionToMoveTo = this.focusPositionToLookAt + this.CameraRestPosition;
        }
        
        /// <summary>
        /// Focus on the specified game object.
        /// </summary>
        private void FocusOn()
        {
            if (this.transform.position == this.focusPositionToMoveTo)
            {
                this.isFocusing = false;
                this.isMovementEnabled = true;
                this.focusPositionToMoveTo = new Vector3();
                this.focusPositionToLookAt = new Vector3();
            }
            else
            {
                this.MoveTowardsFocusedPosition();

                this.RotateTowardsFocusedPosition();
            }
        }

        /// <summary>
        /// Move towards the focused position.
        /// </summary>
        private void MoveTowardsFocusedPosition()
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, this.focusPositionToMoveTo, this.MovementSpeed * Time.deltaTime);
        }

        /// <summary>
        /// Rotate towards the focused position.
        /// </summary>
        private void RotateTowardsFocusedPosition()
        {
            Vector3 lookDirection = this.focusPositionToLookAt - this.transform.position;

            Quaternion targetRotation = Quaternion.LookRotation(lookDirection);

            this.transform.rotation = Quaternion.RotateTowards(this.transform.rotation, targetRotation, this.LookSpeed * Time.deltaTime);
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
