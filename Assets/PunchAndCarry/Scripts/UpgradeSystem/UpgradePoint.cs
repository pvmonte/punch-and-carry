using System;
using UnityEngine;

namespace PunchAndCarry.Scripts.UpgradeSystem
{
    public class UpgradePoint : MonoBehaviour , IInteractionCollidable , IInteractionDispatcher
    {
        public event Action OnInteraction;

        public void Collide(PlayerController player)
        {
            int upgradePrice = player.LevelController.UpgradePrice;
            bool success = player.Bag.TrySpend(upgradePrice);
            
            if(!success) return;
            
            player.LevelController.Upgrade();
            OnInteraction?.Invoke();
        }
    }
}
