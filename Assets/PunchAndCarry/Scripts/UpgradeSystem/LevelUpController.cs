using System;
using UnityEngine;

namespace PunchAndCarry.Scripts.UpgradeSystem
{
    public class LevelUpController : MonoBehaviour
    {
        [field: SerializeField] public int UpgradePrice { get; private set; } = 200;
        [field: SerializeField] public int UpgradeIncrement { get; private set; } = 200;
        
        private int level = 1;
        
        public event Action<int> OnLevelUp;

        public void Upgrade()
        {
            level++;
            UpgradePrice += UpgradeIncrement;
            
            OnLevelUp?.Invoke(level);
        }
    }
}
