using System;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

namespace PunchAndCarry.Scripts.Player
{
    public class EnemyStack : MonoBehaviour
    {
        [SerializeField] private PlayerMovement _movement;
        [SerializeField] private List<Transform> _charactersPivotes;
        private Vector3 _lastPosition;
        private Vector3 _currentPosition;
        [SerializeField] private Vector3 _positionDelta;

        [SerializeField] private float _rotationSpeed = 1;
        [SerializeField] private float _maxRotation;
        [SerializeField] private float _pivotRotationDelay = 0.1f;

        [SerializeField] private Quaternion targetRotation;
        
        

        private void Update()
        {
            var rotation = targetRotation.eulerAngles;

            if (_movement.velocity.magnitude != 0)
            {
                rotation.x -= _rotationSpeed;
            }
            else
            {
                rotation.x += _rotationSpeed;
            }
            
            rotation.y = 0;
            rotation.z = 0;
            rotation.x = Mathf.Clamp(rotation.x, 345, 359);

            targetRotation = Quaternion.Euler(rotation);

            RotatePivotsDelayed(rotation);
            
        }

        private async void RotatePivotsDelayed(Vector3 rotation)
        {
            foreach (var pivot in _charactersPivotes)
            {
                pivot.localRotation = Quaternion.Euler(rotation);
                await Awaitable.WaitForSecondsAsync(_pivotRotationDelay);
            }
        }
        
        
    }
}