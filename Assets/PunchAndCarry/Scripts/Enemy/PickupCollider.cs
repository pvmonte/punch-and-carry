using System;
using PunchAndCarry.Scripts.Player;
using UnityEngine;

namespace PunchAndCarry.Scripts.Enemy
{
    public class PickupCollider : MonoBehaviour , IInteractionCollidable
    {
        [SerializeField] private EnemyController _controller;
        [SerializeField] private Transform _hips;

        private void Update()
        {
            transform.position = _hips.position;
        }

        public void Collide(PlayerController player)
        {
            if (player.EnemyStack.IsFull) return;
            
            _controller.Pickup(player.EnemyStack);
        }
    }
}