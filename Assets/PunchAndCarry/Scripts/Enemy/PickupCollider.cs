using System;
using PunchAndCarry.Scripts.Player;
using UnityEngine;

namespace PunchAndCarry.Scripts.Enemy
{
    public class PickupCollider : MonoBehaviour , IInteractionCollidable<EnemyStack>
    {
        [SerializeField] private EnemyController _controller;
        [SerializeField] private Transform _hips;
        
        private void Update()
        {
            transform.position = _hips.position;
        }

        public void Collide(EnemyStack stack)
        {
            if (stack.IsFull) return;
            
            _controller.OnPickup();
            stack.PickUp(_controller.transform);
        }

    }
}