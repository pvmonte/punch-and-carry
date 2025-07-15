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

        [SerializeField] private float _rotationSpeed = 0.35f;
        [SerializeField] private float _pivotRotationDelay = 0.125f;

        private Quaternion _targetRotation;

        private int _currentPivotIndex = 0;
        public Transform CurrentPivot => _charactersPivotes[_currentPivotIndex];

        private List<Transform> _characters = new ();

        private void Update()
        {
            var rotation = _targetRotation.eulerAngles;

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
            _targetRotation = Quaternion.Euler(rotation);
            RotatePivotsDelayed(rotation);
            
            PositionAndRotationCharacter();
        }

        private async void RotatePivotsDelayed(Vector3 rotation)
        {
            foreach (var pivot in _charactersPivotes)
            {
                pivot.localRotation = Quaternion.Euler(rotation);
                await Awaitable.WaitForSecondsAsync(_pivotRotationDelay);
            }
        }

        public void AddCharacter(Transform character)
        {
            if (_characters.Contains(character)) return;
            
            _characters.Add(character);
            _currentPivotIndex++;
        }

        public void PositionAndRotationCharacter()
        {
            for (int i = 0; i < _characters.Count; i++)
            {
                _characters[i].SetPositionAndRotation(
                    _charactersPivotes[i].position,
                    _charactersPivotes[i].rotation);
            }
        }
    }
}