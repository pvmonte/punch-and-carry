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
        }

        private void OnPunched(Transform puncherPosition)
        {
            EnableRagdoll();

            var puncherVector = puncherPosition.forward * _force;
            puncherVector.y = 10;
            _rigidbodies[0].AddForce(puncherVector, ForceMode.Impulse);
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

        private void ReassembleToRoot()
        {
            transform.position = _hipsTransform.position;
            _hipsTransform.position = Vector3.zero;
        }
    }
}
