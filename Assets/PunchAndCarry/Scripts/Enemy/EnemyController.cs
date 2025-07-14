using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace PunchAndCarry.Scripts.Enemy
{
    public class EnemyController : MonoBehaviour , IPunchable
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private Collider _collider;
        
        public event Action<Transform> OnPunchedEvent;
        
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            _animator.enabled = true;
            _collider.enabled = true;
        }

        public void Punched(Transform puncherPosition)
        {
            _animator.enabled = false;
            _collider.enabled = false;
            OnPunchedEvent?.Invoke(puncherPosition);
        }
    }
}