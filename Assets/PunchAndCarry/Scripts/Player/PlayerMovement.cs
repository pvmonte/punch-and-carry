using UnityEngine;
using UnityEngine.InputSystem;

namespace PunchAndCarry.Scripts.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private PlayerInput _input;
        [SerializeField] private CharacterController _characterController;
        [SerializeField] private float speed = 5;

        public Vector3 MoveVector { get; private set; }

        // Update is called once per frame
        void Update()
        {
            var moveInput = _input.actions["Move"].ReadValue<Vector2>();
            MoveVector = new Vector3(moveInput.x, 0, moveInput.y);

            if (MoveVector.magnitude > 0)
            {
                transform.forward = MoveVector.normalized;
            }
        }

        private void FixedUpdate()
        {
            var finalMoveVector = (MoveVector * speed * Time.fixedDeltaTime) + Physics.gravity;
            _characterController.Move(finalMoveVector);
        }
    }
}