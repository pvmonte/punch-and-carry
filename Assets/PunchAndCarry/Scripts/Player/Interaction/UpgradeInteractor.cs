using PunchAndCarry.Scripts.UpgradeSystem;
using UnityEngine;
using UnityEngine.Serialization;

namespace PunchAndCarry.Scripts.Player.Interaction
{
    public class UpgradeInteractor : MonoBehaviour
    {
        private InteractionColliderController _interaction;
        private LevelUpController _levelUpController;

        void Start()
        {
            _interaction = GetComponent<InteractionColliderController>();
            _levelUpController = GetComponent<LevelUpController>();
            _interaction.OnCollideEvent += Interaction_OnCollideEvent;
        }

        private void Interaction_OnCollideEvent(IInteractionCollidable collidable)
        {
            if (collidable.GetType() != typeof(UpgradePoint)) return;

            ((IInteractionCollidable<LevelUpController>)collidable).Collide(_levelUpController);
        }
    }
}
