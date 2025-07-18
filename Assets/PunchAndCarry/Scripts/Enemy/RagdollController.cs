using System;
using UnityEngine;

namespace PunchAndCarry.Scripts.Enemy
{
    public class RagdollController : MonoBehaviour
    {
        [SerializeField] private EnemyController _enemyController;
        [SerializeField] private Rigidbody[] _rigidbodies;
        [SerializeField] private Collider[] _colliders;

        [SerializeField] private Transform _hipsTransform;
        [SerializeField] private float _force = 50;

        private void Start()
        {
            DisableRagdoll();
            
            _enemyController.OnPunchedEvent += OnPunched;
            _enemyController.OnStartPickUpEvent += DisableRagdoll;
            _enemyController.OnStartPickUpEvent += ReassembleToRoot;
        }

        private async void OnPunched(Transform puncherPosition)
        {
            EnableRagdoll();

            var puncherVector = puncherPosition.forward * _force;
            puncherVector.y = 10;
            _rigidbodies[0].AddForce(puncherVector, ForceMode.Impulse);

            await WaitForBodyToStop();
            
            ReassembleToRoot();
        }
        
        private void EnableRagdoll()
        {
            for (var i = 0; i < _rigidbodies.Length; i++)
            {
                _rigidbodies[i].isKinematic = false;
                _colliders[i].enabled = true;
            }
        }

        private void DisableRagdoll()
        {
            for (var i = 0; i < _rigidbodies.Length; i++)
            {
                _rigidbodies[i].isKinematic = true;
                _colliders[i].enabled = false;
            }
        }

        private void DisableAllColliders()
        {
            DisableRagdoll();
        }

        private void ReassembleToRoot()
        {
            var transformPosition = _hipsTransform.position;
            transformPosition.y = 0;
            transform.position = transformPosition;
            _hipsTransform.localPosition = Vector3.zero;
            _enemyController.EnablePickUpCollider();
        }

        private async Awaitable WaitForBodyToStop()
        {
            await Awaitable.WaitForSecondsAsync(.5f);
            
            while (_rigidbodies[0].linearVelocity is { x: > 0.05f, z: > 0.05f })
            {
                await Awaitable.NextFrameAsync();
            }
        }

        private void OnDestroy()
        {
            _enemyController.OnPunchedEvent -= OnPunched;
            _enemyController.OnStartPickUpEvent -= DisableRagdoll;
            _enemyController.OnStartPickUpEvent -= ReassembleToRoot;
        }
    }
}
