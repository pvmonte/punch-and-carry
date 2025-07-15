using UnityEngine;

namespace PunchAndCarry.Scripts.Enemy
{
    public class PickupCollider : MonoBehaviour
    {
        [SerializeField] private EnemyController _controller;

        public void PickUp(Transform stack)
        {
            _controller.Pickup(stack);
        }
    }
}
