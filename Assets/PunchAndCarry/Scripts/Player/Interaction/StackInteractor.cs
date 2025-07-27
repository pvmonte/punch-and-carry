using System.Collections.Generic;
using PunchAndCarry.Scripts.Enemy;
using PunchAndCarry.Scripts.MoneySystem;
using UnityEngine;

namespace PunchAndCarry.Scripts.Player.Interaction
{
    public class StackInteractor : MonoBehaviour
    {
        private InteractionColliderController _interaction;
        [SerializeField] private EnemyStack _stack;

        void Start()
        {
            _interaction = GetComponent<InteractionColliderController>();
            _interaction.OnCollideEvent += Interaction_OnCollideEvent;
        }

        private void Interaction_OnCollideEvent(IInteractionCollidable collidable)
        {
            var type = collidable.GetType();
            if (type != typeof(SellPoint) && type != typeof(PickupCollider)) return;

            ((IInteractionCollidable<EnemyStack>)collidable).Collide(_stack);
        }
    }
}