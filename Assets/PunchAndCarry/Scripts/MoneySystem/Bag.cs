using System;
using UnityEngine;

namespace PunchAndCarry.Scripts.MoneySystem
{
    public static class Bag
    {
        public static int Money { get; private set; }
        
        public static event Action<int> OnChangeMoneyAmountEvent;

        public static void Earn(int value)
        {
            Inventory.Money += value;
            Money = Inventory.Money;
            OnChangeMoneyAmountEvent?.Invoke(Money);
        }

        public static bool TrySpend(int value)
        {
            if (value > Money) return false;  
            
            Inventory.Money -= value;
            Money = Inventory.Money;
            OnChangeMoneyAmountEvent?.Invoke(Money);
            return true;
        }
    }
}
