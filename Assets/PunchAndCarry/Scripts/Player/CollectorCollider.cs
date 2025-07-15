using System;
using PunchAndCarry.Scripts.Enemy;
using UnityEngine;

namespace PunchAndCarry.Scripts.Player
{
    public class CollectorCollider : MonoBehaviour
    {
        [SerializeField] private EnemyStack _stackReference;
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out PickupCollider pickupCollider))
            {
                pickupCollider.PickUp(_stackReference);
            }
        }
    }
}
