using System;
using PunchAndCarry.Scripts.Player;
using UnityEngine;

namespace PunchAndCarry.Scripts.Enemy
{
    public class PickupCollider : MonoBehaviour
    {
        [SerializeField] private EnemyController _controller;
        [SerializeField] private Transform _hips;

        private void Update()
        {
            transform.position = _hips.position;
        }

        public void PickUp(EnemyStack stack)
        {
            _controller.Pickup(stack);
        }
    }
}
