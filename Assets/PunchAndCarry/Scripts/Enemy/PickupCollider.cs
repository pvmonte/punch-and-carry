using System;
using PunchAndCarry.Scripts.Player;
using UnityEngine;

namespace PunchAndCarry.Scripts.Enemy
{
    public class PickupCollider : MonoBehaviour , IStackCollidable
    {
        [SerializeField] private EnemyController _controller;
        [SerializeField] private Transform _hips;

        private void Update()
        {
            transform.position = _hips.position;
        }

        public void Collide(EnemyStack stack)
        {
            _controller.Pickup(stack);
        }
    }
}

public interface IStackCollidable
{
    public void Collide(EnemyStack stack);
}
