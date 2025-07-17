using System;
using PunchAndCarry.Scripts.Player;
using UnityEngine;
using Random = UnityEngine.Random;

namespace PunchAndCarry.Scripts.UpgradeSystem
{
    public class PlayerLevelController : MonoBehaviour
    {
        [SerializeField] private EnemyStack _enemyStack;
        [SerializeField] private Material _playerMaterial;
        [field: SerializeField] public int UpgradePrice { get; private set; } = 200;
        [field: SerializeField] public int UpgradeIncrement { get; private set; } = 200;
        
        private int level = 1;
        
        public event Action<int> OnLevelUp; 

        public void Upgrade()
        {
            level++;
            UpgradePrice += UpgradeIncrement;
            _enemyStack.Upgrade();
            _playerMaterial.color = Random.ColorHSV(0, 1, 0, 1, 1, 1);
            OnLevelUp?.Invoke(level);
        }
    }
}
