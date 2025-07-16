using System;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Serialization;

namespace PunchAndCarry.Scripts.Player
{
    public class EnemyStack : MonoBehaviour
    {
        [SerializeField] private PlayerMovement _movement;
        [SerializeField] private List<Transform> _charactersPivots;
        [SerializeField] private Vector3 _pivotsOffset = new Vector3(0, 1, 0);

        [SerializeField] private float _rotationSpeed = 0.35f;
        [SerializeField] private float _pivotRotationDelay = 0.125f;

        private Quaternion _targetRotation;

        private int _currentPivotIndex = 0;
        public Transform CurrentPivot => _charactersPivots[_currentPivotIndex];

        private List<Transform> _characters = new ();
        public int StackCount => _characters.Count;
        public bool IsFull => _characters.Count == _charactersPivots.Count;

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
            for (var i = 0; i < _charactersPivots.Count; i++)
            {
                var pivot = _charactersPivots[i];
                pivot.localRotation = Quaternion.Euler(rotation);
                await Awaitable.WaitForSecondsAsync(_pivotRotationDelay);
            }
        }

        public void PushCharacter(Transform character)
        {
            if (_characters.Contains(character)) return;
            if (_characters.Count == _charactersPivots.Count) return;
            
            _characters.Add(character);
            _currentPivotIndex++;
        }

        public Transform PopCharacter()
        {
            var last = _characters[^1];
            _characters.Remove(last);
            _currentPivotIndex--;
            return last;
        }

        public void PositionAndRotationCharacter()
        {
            for (int i = 0; i < _characters.Count; i++)
            {
                _characters[i].SetPositionAndRotation(
                    _charactersPivots[i].position,
                    _charactersPivots[i].rotation);
            }
        }

        public void Upgrade()
        {
            var pivot = _charactersPivots[^1];
            var newPivot = Instantiate(pivot, _pivotsOffset, Quaternion.identity , pivot);
            _charactersPivots.Add(newPivot);
        }
    }
}