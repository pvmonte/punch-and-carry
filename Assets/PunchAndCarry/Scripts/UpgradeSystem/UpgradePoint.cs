using System;
using PunchAndCarry.Scripts.MoneySystem;
using UnityEngine;

namespace PunchAndCarry.Scripts.UpgradeSystem
{
    public class UpgradePoint : MonoBehaviour , IInteractionCollidable<LevelUpController> , IInteractionDispatcher
    {
        public event Action OnInteraction;

        public void Collide(LevelUpController levelUpController)
        {
            int upgradePrice = levelUpController.UpgradePrice;
            bool success = Bag.TrySpend(upgradePrice);
            
            if(!success) return;
            
            levelUpController.Upgrade();
            OnInteraction?.Invoke();
        }
    }
}
