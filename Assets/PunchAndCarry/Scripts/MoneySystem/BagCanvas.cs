using System;
using TMPro;
using UnityEngine;

namespace PunchAndCarry.Scripts.MoneySystem
{
    public class BagCanvas : MonoBehaviour
    {
        [SerializeField] private LevelBag _bag;
        [SerializeField] private TMP_Text _moneyValue;

        private void Start()
        {
            _bag.OnChangeMoneyAmountEvent += Bag_OnChangeMoneyAmountEvent;
        }

        private void Bag_OnChangeMoneyAmountEvent(int value)
        {
            _moneyValue.text = value.ToString();
        }
    }
}
