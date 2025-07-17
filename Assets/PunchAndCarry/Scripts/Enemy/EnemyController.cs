using System;
using PunchAndCarry.Scripts.Player;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

namespace PunchAndCarry.Scripts.Enemy
{
    public class EnemyController : MonoBehaviour , IPunchable
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private Collider _collider;
        [SerializeField] private Transform _pickupCollider;
        
        public event Action<Transform> OnPunchedEvent;
        public event Action OnStartPickUpEvent;
        
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

        public void EnablePickUpCollider()
        {
            _pickupCollider.gameObject.SetActive(true);
        }

        public void Pickup()
        {
            OnStartPickUpEvent?.Invoke();
            _animator.enabled = true;
            _pickupCollider.gameObject.SetActive(false);
        }
    }
}