using UnityEngine;

namespace PunchAndCarry.Scripts.UpgradeSystem
{
    public class UpgradePoint : MonoBehaviour , IInteractionCollidable
    {
        public void Collide(PlayerController player)
        {
            int upgradePrice = player.LevelController.UpgradePrice;
            bool success = player.Bag.TrySpend(upgradePrice);
            
            if(!success) return;
            
            player.LevelController.Upgrade();
        }
    }
}
