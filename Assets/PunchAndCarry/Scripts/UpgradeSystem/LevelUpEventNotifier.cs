using System;
using PunchAndCarry.Scripts.Player;
using UnityEngine;

namespace PunchAndCarry.Scripts.UpgradeSystem
{
    public class LevelUpEventNotifier : MonoBehaviour
    {
        [SerializeField] private LevelUpController _levelUpController;
        [SerializeField] private EnemyStack _enemyStack;
        [SerializeField] private PlayerMaterialController _materialController;
        
        private void Start()
        {
            _levelUpController.OnLevelUp += LevelUpController_OnLevelUp;
        }

        private void LevelUpController_OnLevelUp(int level)
        {
            _enemyStack.Upgrade();
            _materialController.ChangeToRandomColor();
        }

        private void OnDestroy()
        {
            _levelUpController.OnLevelUp -= LevelUpController_OnLevelUp;
        }
    }
}