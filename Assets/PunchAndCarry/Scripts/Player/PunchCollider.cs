using System;
using PunchAndCarry.Scripts.Enemy;
using UnityEngine;

namespace PunchAndCarry.Scripts.Player
{
    public class PunchCollider : MonoBehaviour
    {
        public event Action OnPunchEvent;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.TryGetComponent(out IPunchable punchable))
            {
                punchable.Punched(transform);
                OnPunchEvent?.Invoke();
            }
        }
    }
}
