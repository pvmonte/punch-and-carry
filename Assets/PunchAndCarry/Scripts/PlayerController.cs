using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerInput _input;
    [SerializeField] private CharacterController _characterController;
    [SerializeField] private float speed = 5;

    private Vector3 _moveVector;

    // Update is called once per frame
    void Update()
    {
        var moveInput = _input.actions["Move"].ReadValue<Vector2>();
        _moveVector = new Vector3(moveInput.x, 0, moveInput.y);
    }

    private void FixedUpdate()
    {
        var finalMoveVector = (_moveVector * speed * Time.fixedDeltaTime) + Physics.gravity;
        _characterController.Move(finalMoveVector);
    }
}
