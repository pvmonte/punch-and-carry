using System;
using UnityEngine;

namespace PunchAndCarry.Scripts.Player.Interaction
{
    public class InteractionColliderController : MonoBehaviour
    {
        public event Action<IInteractionCollidable> OnCollideEvent;
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out IInteractionCollidable collidable))
            {
                OnCollideEvent?.Invoke(collidable);
            }
        }
    }
}
