using System;
using PunchAndCarry.Scripts.Enemy;
using UnityEngine;

namespace PunchAndCarry.Scripts.Player
{
    public class CollectorCollider : MonoBehaviour
    {
        [SerializeField] private PlayerController _controller;
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out IInteractionCollidable collidable))
            {
                collidable.Collide(_controller);
            }
        }
    }
}
