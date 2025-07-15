using System;
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

        public async void Pickup(Transform stack)
        {
            float lerp = 0;
            Vector3 startPosition = transform.localPosition;
            
            while (lerp < 1)
            {
                lerp += Time.deltaTime;
                transform.position = Vector3.Lerp(startPosition, stack.position, lerp);
                await Awaitable.NextFrameAsync();
            }
        }
    }
}