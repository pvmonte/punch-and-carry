using System;
using UnityEngine;

namespace PunchAndCarry.Scripts.MoneySystem
{
    public class LevelBag : MonoBehaviour
    {
        private int _money;
        
        public event Action<int> OnChangeMoneyAmountEvent;

        public void Earn(int value)
        {
            Inventory.Money += value;
            _money = Inventory.Money;
            OnChangeMoneyAmountEvent?.Invoke(_money);
        }

        public void Spend(int value)
        {
            if (value < _money) return;  
            
            Inventory.Money -= value;
            _money = Inventory.Money;
            OnChangeMoneyAmountEvent?.Invoke(_money);
        }
    }
}
